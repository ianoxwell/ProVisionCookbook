/* tslint:disable:no-unused-variable */
import { waitForAsync, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { IngredientFilterComponent } from './ingredient-filter.component';

describe('IngredientFilterComponent', () => {
	let component: IngredientFilterComponent;
	let fixture: ComponentFixture<IngredientFilterComponent>;

	beforeEach(waitForAsync(() => {
		TestBed.configureTestingModule({
		declarations: [ IngredientFilterComponent ]
		})
		.compileComponents();
	}));

	beforeEach(() => {
		fixture = TestBed.createComponent(IngredientFilterComponent);
		component = fixture.componentInstance;
		fixture.detectChanges();
	});

	it('should create', () => {
		expect(component).toBeTruthy();
	});
});
