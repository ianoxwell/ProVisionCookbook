import { Component, Input, OnInit } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { Ingredient, IngredientNameSpace } from '@models/ingredient';
import { ReferenceAll } from '@models/reference.model';
import { ValidationMessages } from '@models/static-variables';
import { DialogService } from '@services/dialog.service';
import { first, tap } from 'rxjs/operators';

@Component({
	selector: 'app-edit-ingredient-basic',
	templateUrl: './edit-ingredient-basic.component.html',
	styleUrls: ['./edit-ingredient-basic.component.scss']
})
export class EditIngredientBasicComponent implements OnInit {
	@Input() refData: ReferenceAll;
	@Input() ingredientForm: FormGroup;
	@Input() selectedIngredient: Ingredient;
	validationMessages = ValidationMessages;
	purchasedByEnum = Object.values(IngredientNameSpace.PurchasedByEnum).map((item: string, id: number) => ({ id, item }));
	constructor(private dialogService: DialogService) {}

	ngOnInit() {}
	get nameControl() {
		return this.ingredientForm.get('name');
	}
	get usdaFoodId() {
		return this.ingredientForm.get('usdaFoodId');
	}

	/** Fires a dialog to attempt to match and update ingredient from the rawUsdaFood database */
	matchUsda(): void {
		this.dialogService
			.matchIngredientDialog(this.selectedIngredient, this.refData.IngredientFoodGroup)
			.pipe(
				first(),
				tap((result: any) => console.log('we got a dialog result', result))
			)
			.subscribe();
	}
}
