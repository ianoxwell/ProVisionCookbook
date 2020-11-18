import { Component, Input, OnInit } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { IngredientNameSpace } from '@models/ingredient';
import { ReferenceAll } from '@models/reference.model';
import { ValidationMessages } from '@models/static-variables';

@Component({
  selector: 'app-edit-ingredient-basic',
  templateUrl: './edit-ingredient-basic.component.html',
  styleUrls: ['./edit-ingredient-basic.component.scss']
})
export class EditIngredientBasicComponent implements OnInit {
	@Input() refData: ReferenceAll;
	@Input() ingredientForm: FormGroup;
	validationMessages = ValidationMessages;
	purchasedByEnum =  Object.values(IngredientNameSpace.PurchasedByEnum).map((item: string, id: number) => ({id, item}));
	constructor() { }

	ngOnInit() {
	}
	get nameControl() { return this.ingredientForm.get('name'); }

}
