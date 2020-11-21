import {AfterViewInit, Component, EventEmitter, Input, OnInit, Output, ViewChild} from '@angular/core';
import { FormArray, FormBuilder, FormControl, FormGroup, Validators} from '@angular/forms';
import { ConversionModel, EditedFieldModel, MeasurementModel} from '@models/ingredient-model';
import {DateTimeService} from '@services/date-time.service';
import {RestService} from '@services/rest-service.service';
import {catchError, takeUntil, tap} from 'rxjs/operators';
import {ComponentBase} from '@components/base/base.component.base';
import {of} from 'rxjs';
import {DialogService} from '@services/dialog.service';
import {MessageStatus} from '@models/message.models';
import {MessageService} from '@services/message.service';
import {HttpErrorResponse} from '@angular/common/http';

import {MatSelect} from '@angular/material/select';

import {Ingredient, IngredientNameSpace} from '@models/ingredient';
import {ReferenceAll, ReferenceItemFull} from '@models/reference.model';
import {Conversion} from '@models/conversion';
import {ValidationMessages} from '@models/static-variables';
import { IngredientEditFormService } from '@services/ingredient-edit-form.service';


@Component({
  selector: 'app-ingredient-edit',
  templateUrl: './ingredient-edit.component.html',
  styleUrls: ['./ingredient-edit.component.scss']
})
// done saving after adding a subDocument - re-write api to pick this up
	// done deleting subDocuments with ID's - can the api also pick this up on save?
// TODO: Warning on leaving screen with edited items
// done: Add in nutrition editor
// done: Add in the recipes this is used in with links
// TODO: Price Calculation
// TODO: New select item component - https://github.com/primefaces/primeng/tree/master/src/app/components/dropdown
// TODO: confirm warning header not working?
// done: Add caloricBreakdown editor
// done: Add matched item id for spoontacular
// TODO: do something with matched item
// TODO: Search / filter is triggering the spinny wheel and shouldn't
		// use flatMap - https://medium.com/swlh/cant-tell-your-flatmaps-from-your-switchmaps-a1f0f497b61a



// Behaviour - edited fields either update or add to array of editedItem, on save this array is then iterated to create
// the IngredientModel for new or sent through to update
export class IngredientEditComponent extends ComponentBase implements OnInit, AfterViewInit {
	@Input() singleIngredient: Ingredient;
	@Input() isNew: boolean;
	@Input() refData: ReferenceAll;
	@Input() measurements: MeasurementModel[];
	@Output() deleteItem = new EventEmitter<Ingredient>();
	@Output() back = new EventEmitter<number>();

	@ViewChild('constanceId', { static: true }) constanceSelect: MatSelect;

	selected: Ingredient;
	ingredientForm: FormGroup;
	// priceForm: FormGroup;
	// conversionsForm: FormGroup;
	editedItem: EditedFieldModel[] = [];
	validationMessages = ValidationMessages;

	// getFormKeys = (controls: FormGroup): string[] => { return Object.keys(controls); }

	// measurementTypes = this.measurements.reduce((types, item) => {
	// 	if (types.includes(item.type)) {
	// 		return types;
	// 	}
	// 	return [...types, item.type];
	// }, []);
	// ingredientState = IngredientState;
	// allergyArray = AllergyArray;
	// parentType = ParentTypes;
	lastChecked: any = {};
	isSavingResults = false;



	constructor(
		private fb: FormBuilder,
		private restService: RestService,
		private dialogService: DialogService,
		private messageService: MessageService,
		private ingredientEditFormService: IngredientEditFormService
	) { super(); }

	ngOnInit() {
		this.selected = this.singleIngredient;
		this.ingredientForm = this.ingredientEditFormService.createForm(this.singleIngredient, this.isNew);
		console.log('raw ingredient form', this.ingredientForm.getRawValue(), this.nutritionFacts.controls);
	}

	ngAfterViewInit(): void {
		// this.constanceSelect.
	}

	whichKeyChanged(oldObject, newObject): any {
		const objectKeys = Object.keys(newObject);
		let value = 0;
		let index = 0;
		const whichKey = objectKeys.find((key: string, ind: number) => {
			if (oldObject[ind] - newObject[key] !== 0) {
				value = oldObject[ind] - newObject[key];
				index = ind;
				return true;
			}
		});
		const values = objectKeys.reduce((o, key: string) => ({ ...o, [key]: value / 2 }), {});
		delete values[whichKey]; // = {[key0]: value / 2, [key1]: value / 2};
		// if half value can be added to each item
		// if half value can't be added to item [0]
		// oldObject, newObject = expected returnObject
		// [100, 0, 0], [70*, 0, 0] = [70*, 15, 15] 30
		// [100, 0, 0], [100, 0, 50*] = [50, 0, 50*] -50
		// [80, 10, 10], [80, 10, 50*] = [50, 0, 50*] -40 (-30, -10) // new
		// [30, 10, 60], [30, 10, 30*] = [45, 25, 30] 15
		// [40, 40, 20], [30*, 40, 20] = [30*, 45, 25] 10
		const valueKeys = Object.keys(values); // expecting 2 items
		if (value < 0) {
				if (newObject[valueKeys[0]] + values[valueKeys[0]] < 0) {
					values[valueKeys[1]] += (values[valueKeys[0]] + newObject[valueKeys[0]]);
					values[valueKeys[0]] = newObject[valueKeys[0]] * -1;
				}
				if (newObject[valueKeys[1]] + values[valueKeys[1]] < 0) {
					values[valueKeys[0]] += (values[valueKeys[1]] + newObject[valueKeys[1]]);
					values[valueKeys[1]] = newObject[valueKeys[1]] * -1;
				}
		}
		return values;
	 }



	// todo modify for new controls - related to conversion?
	// filterMeasurements(id: string): MeasurementModel[] {
	// 	// see static-variables for Measurements
	// 	// return either all measurements or only the opposing types eg measureA is Weight then measureB must be Volume or Each
	// 	// first check if the Control is created and has a value
	// 	if (this.conversionsForm.get('measureAControl_' + id) &&
	// 		isNotNullOrUndefined(this.conversionsForm.get('measureAControl_' + id).value)) {
	// 		// find out the type selected
	// 		const type = this.measurements.filter(measure =>
	// 		measure.shortName === this.conversionsForm.get('measureAControl_' + id).value)[0].type;
	// 		// Return the filtered measurements
	// 		return this.measurements.filter((measure) => measure.type !== type);
	// 	}
	// 	return this.measurements;
	// }

	get foodGroup() { return this.ingredientForm.get('foodGroup'); }
	get allergiesControl() { return this.ingredientForm.get('allergies'); }
	get purchasedByControl() { return this.ingredientForm.get('purchasedBy'); }
	get linkUrl() { return this.ingredientForm.get('linkUrl'); }
	get price() { return this.ingredientForm.get('price') as FormArray; }
	get ingredientConversions() { return this.ingredientForm.get('ingredientConversions') as FormArray; }
	get nutrition() { return this.ingredientForm.get('nutrition') as FormArray; }
	get caloricBreakdown(): FormGroup {return this.ingredientForm.get('caloricBreakdown') as FormGroup; }
	get nutritionFacts(): FormGroup {return this.ingredientForm.get('nutritionFacts') as FormGroup; }
	get commonVitamins(): FormGroup {return this.ingredientForm.get('commonVitamins') as FormGroup; }
	get commonMinerals(): FormGroup {return this.ingredientForm.get('commonMinerals') as FormGroup; }


	markFormClean(): void {
		this.ingredientForm.markAsUntouched();
		this.ingredientForm.markAsPristine();
	}

	onSaveItem(): void {
		this.isSavingResults = true;
		const formRaw = this.ingredientForm.getRawValue();
		const saveObject: Ingredient = {
			id: this.selected.id,
			...formRaw,
		};
		saveObject.allergies = formRaw.allergies.map((id: number) =>
			this.refData.AllergyWarning.find((item: ReferenceItemFull) => item.id === id));
		saveObject.foodGroup = this.refData.IngredientFoodGroup.find((item: ReferenceItemFull) => item.id === formRaw.foodGroup);
		console.log('ingredient form', this.ingredientForm.getRawValue(), this.selected, saveObject);
		// getRawValue evaluates arrays as null if the array is empty
		if (!saveObject.allergies) {
			saveObject.allergies = [];
		}
		const ingredientAPI$ = (this.isNew) ? this.restService.createIngredient(saveObject)
			: this.restService.updateIngredient(this.selected.id, saveObject);
		ingredientAPI$.pipe(
			tap((item: Ingredient) => {
				this.messageService.add({
					severity: MessageStatus.Success,
					summary: 'Save Successful'
				});
				this.markFormClean();
				if (this.isNew) {
					this.selected = item;
					this.ingredientForm = this.ingredientEditFormService.createForm(item, true);
					this.isNew = false;
				}
			}),
			catchError((err: HttpErrorResponse) => {
				this.dialogService.confirm(MessageStatus.Warning, 'Error Saving ingredient', err.message);;
				return of({} as Ingredient);
			}),
			takeUntil(this.ngUnsubscribe)
		).subscribe(() => this.isSavingResults = false);
	}

	refreshData() {
		console.log('get data online');
		this.restService.getSpoonacularIngredient(this.linkUrl.value).pipe(
			tap(returnItem => console.log('not sure what to do yet', returnItem)),
			takeUntil(this.ngUnsubscribe)
		).subscribe();
	}


	deleteSubDocument(subDocument: string, docSubId: string, controlIndex: number) {
		// only deletes on save - just removes it from the formControls
		this[subDocument].removeAt(controlIndex);
		this[subDocument].markAsDirty();
		this[subDocument].markAsTouched();
		this.messageService.add({
			severity: MessageStatus.Success,
			summary: `Removed ${subDocument}`,
			life: 8000
		});
	}

	addSubDocument(subDocument: string) {
		// expected either prices, conversions, or nutrition
		// add a new subDoc to this.selected[subDocument] with an empty model, then create a set of controls based on that
		switch (subDocument) {
			case 'conversions': this.ingredientConversions.push(this.ingredientEditFormService.initConversionFormGroup(new ConversionModel(), true)); break;
			// case 'nutrition': this.nutrition.push(this.initNutritionFormGroup(new NutritionModel(), true)); break;
			default: this.messageService.add({severity: MessageStatus.Warning, summary: `Unidentified subDocument created, ${subDocument}`})
		}
		this[subDocument].markAsDirty();
		this[subDocument].markAsTouched();
	}

	// createSubDocument(ingredientId: string, subDocumentName: string, subDocument: Price | Conversion) {
	// 	this.restService.createSubDocument('ingredient', ingredientId, subDocumentName, subDocument).pipe(
	// 		tap((newSubIngredient: Ingredient) => {
	// 			// this.dataTableComponent.modifyIngredient(newSubIngredient, 'edit');
	// 		}),
	// 		catchError(err => {
	// 			console.log('Error', err);
	// 			this.dialogService.confirm(MessageStatus.Critical, err.name, err);
	// 			return of([]);
	// 		}),
	// 		takeUntil(this.ngUnsubscribe),
	// 	).subscribe();
	// }

	deleteIngredient(docId: string) {
		this.deleteItem.emit(this.selected);
	}

	dragNDrop(event: any) {
		let min = event.currentIndex;
		let max = event.previousIndex;
		let reverse = false;
		if (event.previousIndex < event.currentIndex) {
			min = event.previousIndex;
			max = event.currentIndex;
			reverse = true;
		}
		// quick check to ensure numbers will be in range
		if (min >= 0 && max < this.selected.ingredientConversions.length) {
			// todo there has to be a better way of doing this!
			for (let i = min; i <= max; i++) {
			reverse ? this.selected.ingredientConversions[i].preference-- : this.selected.ingredientConversions[i].preference++;
			// check for repeats and add items to editedItem
			// todo  maybe instead on submit check through the preferences against the original - create change event for each actual change?
			}
			this.selected.ingredientConversions[event.previousIndex].preference = event.currentIndex;
		}
		this.selected.ingredientConversions = [...this.selected.ingredientConversions].sort(DateTimeService.sortByNumber);
	}

}
