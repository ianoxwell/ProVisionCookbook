import { Component, OnInit, Input, EventEmitter, Output } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { MeasurementModel } from '@models/ingredient-model';

@Component({
	selector: 'app-ingredient-prices-form',
	templateUrl: './ingredient-prices-form.component.html',
	styleUrls: ['./ingredient-prices-form.component.scss']
})
export class IngredientPricesFormComponent {
	@Input() price: FormGroup;
	@Input() measurements: MeasurementModel[];
	@Output() markAsDirty = new EventEmitter<void>();
	@Output() deleteItem = new EventEmitter<void>();

	constructor() { }

}
