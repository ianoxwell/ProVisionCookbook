import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatIconModule } from '@angular/material/icon';
import { SaveButtonComponent } from './save-button/save-button.component';
import { MatButtonModule } from '@angular/material/button';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';


@NgModule({
	imports: [
		CommonModule,
		MatIconModule,
		MatButtonModule,
		MatProgressSpinnerModule,
	],
	declarations: [
		SaveButtonComponent
	],
	exports: [
		SaveButtonComponent
	]
})

export class SharedComponentModule { }
