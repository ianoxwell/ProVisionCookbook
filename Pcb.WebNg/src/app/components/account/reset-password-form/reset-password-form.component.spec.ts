/* tslint:disable:no-unused-variable */
import { waitForAsync, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { ResetPasswordFormComponent } from './reset-password-form.component';

describe('ResetPasswordFormComponent', () => {
	let component: ResetPasswordFormComponent;
	let fixture: ComponentFixture<ResetPasswordFormComponent>;

	beforeEach(waitForAsync(() => {
		TestBed.configureTestingModule({
		declarations: [ ResetPasswordFormComponent ]
		})
		.compileComponents();
	}));

	beforeEach(() => {
		fixture = TestBed.createComponent(ResetPasswordFormComponent);
		component = fixture.componentInstance;
		fixture.detectChanges();
	});

	it('should create', () => {
		expect(component).toBeTruthy();
	});
});
