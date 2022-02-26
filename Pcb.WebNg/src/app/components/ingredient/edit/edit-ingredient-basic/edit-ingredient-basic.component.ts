import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
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
	@Input() refData!: ReferenceAll;
	@Input() ingredientForm!: FormGroup;
	@Input() selectedIngredient: Ingredient | null = null;
	@Output() updatedIngredient = new EventEmitter<Ingredient>();
	validationMessages = ValidationMessages;
	purchasedByEnum = Object.values(IngredientNameSpace.PurchasedByEnum).map((item: string, id: number) => ({ id, item }));
	constructor(private dialogService: DialogService) {}

	ngOnInit() {}
	get nameControl(): FormControl {
		return this.ingredientForm.get('name') as FormControl;
	}
	get usdaFoodId(): FormControl {
		return this.ingredientForm.get('usdaFoodId') as FormControl;
	}

	/** Fires a dialog to attempt to match and update ingredient from the rawUsdaFood database */
	matchUsda(): void {
		if (!this.refData.IngredientFoodGroup || !this.selectedIngredient) {
			return;
		}

		this.dialogService
			.matchIngredientDialog(this.selectedIngredient, this.refData.IngredientFoodGroup)
			.pipe(
				first(),
				tap((result: Ingredient) => this.updatedIngredient.emit(result))
			)
			.subscribe();
	}
}
