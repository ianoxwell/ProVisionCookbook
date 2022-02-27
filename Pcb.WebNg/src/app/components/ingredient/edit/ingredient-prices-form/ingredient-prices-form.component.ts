import { Component, OnInit, Input, EventEmitter, Output } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { MeasurementModel } from '@models/ingredient-model';
import { DecimalTwoPlaces } from '@models/static-variables';

@Component({
  selector: 'app-ingredient-prices-form',
  templateUrl: './ingredient-prices-form.component.html',
  styleUrls: ['./ingredient-prices-form.component.scss']
})
export class IngredientPricesFormComponent {
  @Input() price: FormGroup = new FormGroup({});
  @Input() measurements: MeasurementModel[] = [];
  @Output() markAsDirty = new EventEmitter<void>();

  decimalTwoPlaces = DecimalTwoPlaces;
  constructor() {}
}
