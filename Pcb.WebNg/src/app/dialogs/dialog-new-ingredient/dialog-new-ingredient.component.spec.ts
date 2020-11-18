import { waitForAsync, ComponentFixture, TestBed } from '@angular/core/testing';

import { DialogNewIngredientComponent } from './dialog-new-ingredient.component';

describe('DialogNewIngredientComponent', () => {
	let component: DialogNewIngredientComponent;
	let fixture: ComponentFixture<DialogNewIngredientComponent>;

	beforeEach(waitForAsync(() => {
		TestBed.configureTestingModule({
			declarations: [ DialogNewIngredientComponent ]
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
