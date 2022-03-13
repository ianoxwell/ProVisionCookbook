import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { IMeasurement } from '@models/ingredient/ingredient-model';
import { IReferenceItemFull } from '@models/reference.model';

@Component({
  selector: 'app-ingredient-conversion-form',
  templateUrl: './ingredient-conversion-form.component.html',
  styleUrls: ['./ingredient-conversion-form.component.scss']
})
export class IngredientConversionFormComponent implements OnInit {
  @Input() convert: FormGroup = new FormGroup({});
  @Input() ingredientState: IReferenceItemFull[] = [];
  @Input() measurements: IMeasurement[] = [];
  @Output() markAsDirty = new EventEmitter<void>();
  @Output() deleteItem = new EventEmitter<void>();

  constructor() {}

  ngOnInit(): void {}
}
