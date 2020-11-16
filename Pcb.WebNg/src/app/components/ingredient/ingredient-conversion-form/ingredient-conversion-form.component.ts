import { Component, OnInit, EventEmitter, Input, Output } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { IdValuePair } from '@models/common.model';
import { MeasurementModel } from '@models/ingredient-model';

@Component({
  selector: 'app-ingredient-conversion-form',
  templateUrl: './ingredient-conversion-form.component.html',
  styleUrls: ['./ingredient-conversion-form.component.scss']
})
export class IngredientConversionFormComponent implements OnInit {
	@Input() convert: FormGroup;
	@Input() ingredientState: IdValuePair[];
	@Input() measurements: MeasurementModel[];
	@Output() markAsDirty = new EventEmitter<void>();
	@Output() deleteItem = new EventEmitter<void>();

  constructor() { }

  ngOnInit(): void {
  }

}
