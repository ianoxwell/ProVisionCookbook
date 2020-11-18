import { Component, Inject, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { ComponentBase } from '@components/base/base.component.base';
import { IRawFoodIngredient } from '@models/rawFoodIngredient.model';
import { ReferenceItem, ReferenceItemFull } from '@models/reference.model';
import { Suggestions } from '@models/suggestion';
import { IngredientEditFormService } from '@services/ingredient-edit-form.service';
import { RestService } from '@services/rest-service.service';
import { BehaviorSubject, Observable, of } from 'rxjs';
import { debounceTime, filter, switchMap, takeUntil, tap } from 'rxjs/operators';

@Component({
  selector: 'app-dialog-new-ingredient',
  templateUrl: './dialog-new-ingredient.component.html',
  styleUrls: ['./dialog-new-ingredient.component.scss']
})

// TODO check that ingredient name is available in ingredientsDB
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
	filterRawSuggestions$: Observable<IRawFoodIngredient[]> = of([]);
	rawFoodFilter$ = new BehaviorSubject<string>(null);

	constructor(
		public dialogRef: MatDialogRef<DialogNewIngredientComponent>,
		@Inject(MAT_DIALOG_DATA) public data: ReferenceItemFull[],
		private fb: FormBuilder,
		private ingredientEditFormService: IngredientEditFormService,
		private ingredientRestService: RestService
	) {
		super();
		dialogRef.disableClose = true;
	}

	ngOnInit() {
		this.form = this.fb.group({
			name: ['', [Validators.required]],
			foodGroup: null
		});
		this.filterRawSuggestions$ = this.form.get('name').valueChanges.pipe(
			debounceTime(200),
			filter((item: string) => !!item),
			switchMap((rawFood: string) => {
				const formRaw = this.form.getRawValue();
				console.log('debounced, switchMap here for the suggestions', rawFood, formRaw);
				return this.ingredientRestService.getRawFoodSuggestion(rawFood, 10, formRaw.foodGroup);
			}),
			tap((x: IRawFoodIngredient[]) => console.log('here we are', x)),
		);
	}
	onFilterChange(ev: string): void {
		console.log('filter ev here', ev);
		this.rawFoodFilter$.next(ev);
	}

	selectItem(item: IRawFoodIngredient): void {
		console.log('selected this item', item);
	}
	onSaveItem() {
		console.log('proceeding with starting a new doc', this.form);
	}

}
