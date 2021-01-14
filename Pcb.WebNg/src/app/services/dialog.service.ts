import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { MatDialog } from '@angular/material/dialog';
import { MatSnackBar } from '@angular/material/snack-bar';
import { BehaviorSubject, Observable } from 'rxjs';

import { ComponentBase } from '../components/base/base.component.base';
import { MessageStatus, StatusUpdate } from '../models/message.models';
import { ConfirmDialogComponent } from '../dialogs/dialog-confirm/confirm.component';
import { ReferenceItemFull } from '@models/reference.model';
import { Ingredient } from '@models/ingredient';
import { DialogNewIngredientComponent } from '../dialogs/dialog-new-ingredient/dialog-new-ingredient.component';
import { MeasurementModel } from '@models/ingredient-model';

@Injectable()
export class DialogService extends ComponentBase {

	/** Broadcasting variable */
	private statusUpdate = new BehaviorSubject<StatusUpdate>({
		status: MessageStatus.None,
		message: '',
		persist: false
	});
	currentStatus = this.statusUpdate.asObservable();

	constructor(
		private dialog: MatDialog,
		private matSnackBar: MatSnackBar,
		private router: Router) {
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
		const message = (!!err.message) ? err.message : err;
		const data = { status: MessageStatus.Error, heading, message, confirmButton };
		return this.createDialog<void>(data, ConfirmDialogComponent);
	}

	newIngredientDialog(
		foodGroup: ReferenceItemFull[],
		measurements: MeasurementModel[],
		ingredientStateRef: ReferenceItemFull[] ): Observable<Ingredient> {
			return this.createDialog<Ingredient>({foodGroup, measurements, ingredientStateRef}, DialogNewIngredientComponent);
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
