import { waitForAsync, ComponentFixture, TestBed } from '@angular/core/testing';

import { SelectAutoCompleteComponent } from './select-auto-complete.component';
import { ReactiveFormsModule, FormControl, FormsModule } from '@angular/forms';
import { NoopAnimationsModule } from '@angular/platform-browser/animations';
import { MatSelectModule } from '@angular/material/select';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { MatIconModule } from '@angular/material/icon';
import { fakeFacilities } from 'src/app/tests/test-helpers.models';

describe('SelectAutoCompleteComponent', () => {
	let component: SelectAutoCompleteComponent;
	let fixture: ComponentFixture<SelectAutoCompleteComponent>;

	beforeEach(waitForAsync(() => {
		TestBed.configureTestingModule({
			imports: [ReactiveFormsModule,
				FormsModule,
				MatSelectModule,
				MatFormFieldModule,
				MatInputModule,
				MatCheckboxModule,
				MatIconModule,
				NoopAnimationsModule],
			declarations: [ SelectAutoCompleteComponent,   ]
		})
		.compileComponents();
	}));

	beforeEach(() => {
		fixture = TestBed.createComponent(SelectAutoCompleteComponent);
		component = fixture.componentInstance;
		component.control = new FormControl([]);
		component.options = fakeFacilities;
		fixture.detectChanges();
	});

	it('should create', () => {
		expect(component).toBeTruthy();
	});

	describe('ngOnChanges', () => {
		it('should effectively initialise the component', () => {
			component.ngOnChanges();
			expect(component.filteredOptions.length).toEqual(fakeFacilities.length);
			expect(component.control.value.length).toEqual(0);
		});
	});

	it('should filter the list of facilities', () => {
		component.filterItem('Alpha');
		expect(component.filteredOptions.length).toEqual(1);
		expect(component.selectAllChecked).toBeFalse();
	});

	describe('onDisplayString', () => {
		it('should return an empty string when nothing is selected', () => {
			const displayString = component.onDisplayString();
			expect(displayString.length).toEqual(0);
		});
		it('should return a hospital when one item is selected', () => {
			component.control.patchValue([1]);
			const displayString = component.onDisplayString();
			expect(displayString).toEqual('Alpha School');
		});
		it('should return School name +1 others when more than one item is selected', () => {
			component.control.patchValue([1, 58]);
			const displayString = component.onDisplayString();
			expect(displayString).toEqual('Alpha School (+1 others)');
		});
	});
	describe('toggleSelectAll', () => {
		beforeEach(() => {
			component.ngOnChanges();
		});
		it('should select all the facilities', () => {
			component.toggleSelectAll(true);
			expect(component.control.value.length).toEqual(fakeFacilities.length);
		});

		it('should un-select all the facilities', () => {
			component.toggleSelectAll(false);
			expect(component.control.value.length).toEqual(0);
		});
	});


});
