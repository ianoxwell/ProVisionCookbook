import { waitForAsync, ComponentFixture, TestBed } from '@angular/core/testing';

import { EditCommonVitaminsComponent } from './edit-common-vitamins.component';

describe('EditCommonVitaminsComponent', () => {
	let component: EditCommonVitaminsComponent;
	let fixture: ComponentFixture<EditCommonVitaminsComponent>;

	beforeEach(waitForAsync(() => {
		TestBed.configureTestingModule({
			declarations: [ EditCommonVitaminsComponent ]
		}).compileComponents();
	}));

	beforeEach(() => {
		fixture = TestBed.createComponent(EditCommonMineralsComponent);
		component = fixture.componentInstance;
		fixture.detectChanges();
	});

	it('should create', () => {
		expect(component).toBeTruthy();
	});
});
