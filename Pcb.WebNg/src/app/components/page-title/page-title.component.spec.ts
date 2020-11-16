/* tslint:disable:no-unused-variable */
import { waitForAsync, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { PageTitleComponent } from './page-title.component';

describe('PageTitleComponent', () => {
	let component: PageTitleComponent;
	let fixture: ComponentFixture<PageTitleComponent>;

	beforeEach(waitForAsync(() => {
		TestBed.configureTestingModule({
		declarations: [ PageTitleComponent ]
		})
		.compileComponents();
	}));

	beforeEach(() => {
		fixture = TestBed.createComponent(PageTitleComponent);
		component = fixture.componentInstance;
		fixture.detectChanges();
	});

	it('should create', () => {
		expect(component).toBeTruthy();
	});
});
