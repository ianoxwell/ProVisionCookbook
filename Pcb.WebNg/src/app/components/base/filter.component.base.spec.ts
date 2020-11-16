import { waitForAsync, ComponentFixture, TestBed } from '@angular/core/testing';
import { BaseFilterComponent } from './filter.component.base';
import { FormBuilder } from '@angular/forms';

class MockFilterComponentBase extends BaseFilterComponent {}

describe('BaseFilterComponent', () => {
	let component: BaseFilterComponent;
	let fixture: ComponentFixture<BaseFilterComponent>;

	const formBuilder: FormBuilder = new FormBuilder();

	beforeEach(waitForAsync(() => {
		TestBed.configureTestingModule({
			declarations: [ BaseFilterComponent ],
			providers: [ 	{ provide: FormBuilder, useValue: formBuilder }, ]
		})
		.compileComponents();
	}));

	beforeEach(() => {
		fixture = TestBed.createComponent(MockFilterComponentBase);
		component = fixture.componentInstance;
		component.filterGroup = { filters: '' };
		fixture.detectChanges();
	});

	it('should create', () => {
		expect(component).toBeTruthy();
	});
});
