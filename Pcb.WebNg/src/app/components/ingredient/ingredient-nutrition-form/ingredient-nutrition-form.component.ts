import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { NutritionUnits } from '@models/static-variables';


@Component({
  selector: 'app-ingredient-nutrition-form',
  templateUrl: './ingredient-nutrition-form.component.html',
  styleUrls: ['./ingredient-nutrition-form.component.scss']
})
export class IngredientNutritionFormComponent {
	@Input() nutrition: FormGroup;
	@Input() index: number;
	@Output() markAsDirty = new EventEmitter<void>();
	@Output() deleteItem = new EventEmitter<void>();
	nutritionUnits = NutritionUnits;

  	constructor() { }


}
