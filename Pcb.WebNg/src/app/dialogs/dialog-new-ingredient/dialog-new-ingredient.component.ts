import { Component, Inject, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { ComponentBase } from '@components/base/base.component.base';
import { Ingredient } from '@models/ingredient';
import { MeasurementModel } from '@models/ingredient-model';
import {
	IRawFoodIngredient,
	IRawFoodSuggestion,
	ISpoonConversion,
	ISpoonFoodRaw,
	ISpoonSuggestions
} from '@models/raw-food-ingredient.model';
import { ReferenceItemFull } from '@models/reference.model';
import { IngredientConstructService } from '@services/ingredient-construct.service';
import { IngredientEditFormService } from '@services/ingredient-edit-form.service';
import { RestService } from '@services/rest-service.service';
import { BehaviorSubject, combineLatest, Observable, of } from 'rxjs';
import { debounceTime, filter, first, switchMap, takeUntil, tap } from 'rxjs/operators';

@Component({
  selector: 'app-dialog-new-ingredient',
  templateUrl: './dialog-new-ingredient.component.html',
  styleUrls: ['./dialog-new-ingredient.component.scss']
})

// done check that ingredient name is available in ingredientsDB
// TODO trigger search on food group changing
// TODO edit the DTO and create a transform object to give full data for RawFood Ingredient Model
// TODO Make Table so that item is selectable - header Match Nutrient Data with USDA database
// TODO Button to complete fields from Spoonacular - after USDA food is selected?
// TODO Make similar table from Spoonacular showing potential suggestion matches for ingredient
// TODO If no matches found from USDA get nutrient data from Spoonacular
// TODO Add origin to the dialog (eg recipeImport || ingredients)
// TODO Create new Ingredient from all the relevant information and if origin was ingredients navigate to the editable ingredient
export class DialogNewIngredientComponent extends ComponentBase implements OnInit {
	form: FormGroup;
	filterRawSuggestions$: Observable<IRawFoodSuggestion[]> = of([]);
	rawFoodFilter$ = new BehaviorSubject<string>(null);

	isFoodNameAvailable: boolean = null;
	isCheckingFoodName = false;

	usdaFoodMatched: IRawFoodIngredient = null;
	spoonFoodSuggestions: ISpoonSuggestions[];
	spoonFoodMatched: ISpoonFoodRaw;
	spoonConversion: ISpoonConversion[] = [];
	newIngredient: Ingredient;

	constructor(
		public dialogRef: MatDialogRef<DialogNewIngredientComponent>,
		@Inject(MAT_DIALOG_DATA) public data: {
			foodGroup: ReferenceItemFull[],
			ingredientStateRef: ReferenceItemFull[],
			measurements: MeasurementModel[] },
		private fb: FormBuilder,
		private ingredientEditFormService: IngredientEditFormService,
		private ingredientConstructService: IngredientConstructService,
		private ingredientRestService: RestService
	) {
		super();
		dialogRef.disableClose = true;
	}


	ngOnInit() {
		this.form = this.createForm();
		this.filterRawSuggestions$ = combineLatest([
			this.rawName.valueChanges,
			this.foodGroup.valueChanges
		])
		.pipe(
			debounceTime(200),
			filter(([item, foodId]: [string, number]) => !!item),
			switchMap(([rawFood, foodGroupId]: [string, number]) => {
				if (rawFood.length > 2) {
					this.checkNameExists(rawFood);
				} else {
					this.isFoodNameAvailable = null;
				}
				const formRaw = this.form.getRawValue();
				return this.ingredientRestService.getRawFoodSuggestion(rawFood, 20, foodGroupId);
			}),
		);
	}

	get rawName(): FormControl { return this.form.get('name') as FormControl; }
	get foodGroup(): FormControl { return this.form.get('foodGroup') as FormControl; }
	createForm(): FormGroup {
		return this.fb.group({
			name: ['', [Validators.required]],
			foodGroup: null
		});
	}
	onFilterChange(ev: string): void {
		this.rawFoodFilter$.next(ev);

	}

	selectItem(item: IRawFoodSuggestion): void {
		console.log('selected this item', item);
		this.ingredientRestService.getRawFoodById(item.usdaId).pipe(
			first(),
			tap((result: IRawFoodIngredient) => {
				console.log('raw food matched', result);
				this.usdaFoodMatched = result;
			})
		).subscribe();
	}
	onSaveItem() {
		console.log('proceeding with starting a new doc', this.form.getRawValue(),
			this.usdaFoodMatched, this.spoonFoodMatched, this.spoonConversion, this.data);
		this.newIngredient = this.ingredientConstructService.createNewIngredient(
			this.form.getRawValue(),
			this.usdaFoodMatched,
			this.spoonFoodMatched,
			this.spoonConversion,
			this.data.foodGroup,
			this.data.ingredientStateRef,
			this.data.measurements);
		console.log('this.newIngredient', this.newIngredient);
		this.dialogRef.close(this.newIngredient);
	}

	checkNameExists(name: string): void {
		this.isCheckingFoodName = true;
		this.isFoodNameAvailable = null;
		this.ingredientRestService.checkFoodNameExists(name).pipe(
			first(),
			tap((result: boolean) => {
				this.isCheckingFoodName = false;
				this.isFoodNameAvailable = !result;
			})
		).subscribe();
	}

	findSpoonSuggestionsOnline(): void {
		this.ingredientRestService.getSpoonacularSuggestions(this.rawName.value).pipe(
			first(),
			tap((result: ISpoonSuggestions[]) => {
				this.spoonFoodSuggestions = result;
			})
		).subscribe();
	}

	selectSpoonItem(spoonSuggestion: ISpoonSuggestions): void {
		this.ingredientRestService.getSpoonacularIngredient(spoonSuggestion.id.toString()).pipe(
			switchMap((result: ISpoonFoodRaw) => {
				this.spoonFoodMatched = result;
				// const unitFrom: string = result.shoppingListUnits[0];
				// const unitFromRef = this.data.measurements
				// 	.find((measure: MeasurementModel)	=> measure.title.toLowerCase() === unitFrom || measure.shortName.toLowerCase() === unitFrom);
				const unitFrom = result.possibleUnits.includes('cup') ? 'cup' : 'piece';
				return this.ingredientRestService.getSpoonConversion(result.name, unitFrom, 1, 'grams');
			}),
			tap((convertResult: ISpoonConversion) => {
				this.spoonConversion.push(convertResult);
				console.log('spoon finished', this.spoonFoodMatched, this.spoonConversion);
			}),
			takeUntil(this.ngUnsubscribe)
		).subscribe();
	}

}
