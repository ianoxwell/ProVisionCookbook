import { Component, OnInit, Inject } from '@angular/core';
import {MAT_DIALOG_DATA, MatDialog, MatDialogRef} from '@angular/material/dialog';

@Component({
  selector: 'app-dialog-error',
  templateUrl: './dialog-error.component.html',
  styleUrls: ['./dialog-error.component.scss']
})
export class DialogErrorComponent implements OnInit {
	constructor(
		public dialogRef: MatDialogRef<DialogErrorComponent>,
		@Inject(MAT_DIALOG_DATA) public data: any
		// errorMessage should be send as {title: 'Unknown Error', content: error message}
		// therefore data.title and data.content
	) { }
	onNoClick(): void {
		this.dialogRef.close();
	}
	ngOnInit() {
		console.log('app-dialog-error, ', this.data);
	}
}
