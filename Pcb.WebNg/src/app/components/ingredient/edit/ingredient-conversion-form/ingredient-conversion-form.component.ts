import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { MeasurementModel } from '@models/ingredient-model';
import { ReferenceItemFull } from '@models/reference.model';

@Component({
  selector: 'app-ingredient-conversion-form',
  templateUrl: './ingredient-conversion-form.component.html',
  styleUrls: ['./ingredient-conversion-form.component.scss']
})
export class IngredientConversionFormComponent implements OnInit {
	@Input() convert: FormGroup;
	@Input() ingredientState: ReferenceItemFull[];
	@Input() measurements: MeasurementModel[];
	@Output() markAsDirty = new EventEmitter<void>();
	@Output() deleteItem = new EventEmitter<void>();

  constructor() { }

  ngOnInit(): void {
	  console.log('convert form', this.convert.getRawValue(), this.ingredientState);
  }

}
