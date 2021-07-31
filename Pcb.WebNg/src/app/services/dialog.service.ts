import { Injectable } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Router } from '@angular/router';
import { ComponentBase } from '@components/base/base.component.base';
import { Ingredient } from '@models/ingredient';
import { MeasurementModel } from '@models/ingredient-model';
import { MessageStatus, StatusUpdate } from '@models/message.model';
import { ReferenceItemFull } from '@models/reference.model';
import { BehaviorSubject, Observable } from 'rxjs';
import { ConfirmDialogComponent } from '../dialogs/dialog-confirm/confirm.component';
import { DialogIngredientMatchComponent } from '../dialogs/dialog-ingredient-match/dialog-ingredient-match.component';
import { DialogNewIngredientComponent } from '../dialogs/dialog-new-ingredient/dialog-new-ingredient.component';

@Injectable()
export class DialogService extends ComponentBase {
	/** Broadcasting variable */
	private statusUpdate = new BehaviorSubject<StatusUpdate>({
		status: MessageStatus.None,
		message: '',
		persist: false
	});
	currentStatus = this.statusUpdate.asObservable();

	constructor(private dialog: MatDialog, private matSnackBar: MatSnackBar, private router: Router) {
		super();
	}

	/** Opens Material UI dialog boxes with given parameters */
	createDialog<T>(data: any, component: any, width: string = '60%'): Observable<T> {
		const dialogRef = this.dialog.open(component, {
			width,
			data,
			position: { top: '50px' }
		});

		return dialogRef.afterClosed();
	}

	/** Returns the last value of statusUpdate when this function is called */
	getStatus() {
		return this.statusUpdate.getValue();
	}

	/** Opens a confirm dialog */
	confirm(status: MessageStatus, title: string, message: string, buttonText: string = 'Confirm'): Observable<boolean> {
		const data = { status, title, message, buttonText };
		return this.createDialog<boolean>(data, ConfirmDialogComponent);
	}

	/** Opens an alert dialog */
	alert(heading: string, err: any, confirmButton: string = 'Okay'): Observable<void> {
		// if error message if of type HttpErrorResponse then it will have a message
		const message = !!err.message ? err.message : err;
		const data = { status: MessageStatus.Error, heading, message, confirmButton };
		return this.createDialog<void>(data, ConfirmDialogComponent);
	}

	/**
	 * Opens a new Ingredient Dialog
	 * @param foodGroup Reference data for the food Groups.
	 * @param measurements Reference Data for measurements (used in conversions).
	 * @param ingredientStateRef Reference Data for the ingredient States (i.e. solid, liquid)
	 * @returns Observable of the new ingredient
	 */
	newIngredientDialog(
		foodGroup: ReferenceItemFull[],
		measurements: MeasurementModel[],
		ingredientStateRef: ReferenceItemFull[]
	): Observable<Ingredient> {
		return this.createDialog<Ingredient>({ foodGroup, measurements, ingredientStateRef }, DialogNewIngredientComponent);
	}

	/**
	 * Opens a dialog to match the ingredients with the Usda Food id and populate the nutrients / vitamins / minerals.
	 * @param ingredient The ingredient to edit.
	 * @param foodGroup The refData for FoodGroup to match with.
	 * @returns Observable of the updated ingredient
	 */
	matchIngredientDialog(ingredient: Ingredient, foodGroup: ReferenceItemFull[]): Observable<Ingredient> {
		return this.createDialog<Ingredient>({ ingredient, foodGroup }, DialogIngredientMatchComponent);
	}

	/** Closes all dialogs */
	closeAll() {
		this.dialog.closeAll();
	}

	/** Opens a snackbar */
	snackBar(status: MessageStatus, message: string, durationTime: number = 3000) {
		this.matSnackBar.open(message, 'X', {
			duration: durationTime,
			verticalPosition: 'top',
			panelClass: [status]
		});
	}
}
