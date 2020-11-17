/* tslint:disable:no-unused-variable */
import { ComponentFixture, TestBed, waitForAsync } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { EditIngredientBasicComponent } from './edit-ingredient-basic.component';

describe('EditIngredientBasicComponent', () => {
	let component: EditIngredientBasicComponent;
	let fixture: ComponentFixture<EditIngredientBasicComponent>;

	beforeEach(waitForAsync(() => {
		TestBed.configureTestingModule({
		declarations: [ EditIngredientBasicComponent ]
		})
		.compileComponents();
	}));

	beforeEach(() => {
		fixture = TestBed.createComponent(EditIngredientBasicComponent);
		component = fixture.componentInstance;
		fixture.detectChanges();
	});

	it('should create', () => {
		expect(component).toBeTruthy();
	});
});
