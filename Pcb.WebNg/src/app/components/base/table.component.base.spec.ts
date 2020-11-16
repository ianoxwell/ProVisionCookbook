import { waitForAsync, ComponentFixture, TestBed } from '@angular/core/testing';
import { BaseTableComponent } from './table.component.base';
import { SortPageObj } from '@models/common.model';
import { MatSort } from '@angular/material/sort';

// must mock the abstract class to a concrete class
class MockTableComponentBase extends BaseTableComponent {
	goto(row: any): void {
		return;
	}
}

describe('TableComponentBase', () => {
	let component: BaseTableComponent;
	let fixture: ComponentFixture<BaseTableComponent>;

	const fakeEmptyFilterParams: SortPageObj = {
		sort: 'id',
		order: 'asc',
		pageIndex: 0,
		pageSize: 25
	};
	const fakeSortFilterParams: SortPageObj = {
		sort: 'name',
		order: 'desc',
		pageIndex: 0,
		pageSize: 25
	};

	beforeEach(waitForAsync(() => {
		TestBed.configureTestingModule({
		declarations: [ BaseTableComponent ]
		})
		.compileComponents();
	}));

	beforeEach(() => {
		fixture = TestBed.createComponent(MockTableComponentBase);
		component = fixture.componentInstance;
		fixture.detectChanges();
	});

	it('should create', () => {
		expect(component).toBeTruthy();
	});

	describe('Pagination change event', () => {
		beforeEach(() => {
			component.sortPageObj = {...fakeEmptyFilterParams};
		});
		it('should reset the pageIndex if the pageSize has changed', () => {
			component.sortPageObj.pageIndex = 2;
			component.onPageChange({pageSize: 15, pageIndex: 2, previousPageIndex: 2, length: 25});
			expect(component.sortPageObj.pageIndex).toEqual(0);
			expect(component.sortPageObj.pageSize).toEqual(15);
		});
		it('should change the pageIndex on increment of page', () => {
			component.onPageChange({pageSize: 25, pageIndex: 1, previousPageIndex: 0, length: 25});
			expect(component.sortPageObj.pageIndex).toEqual(1);
		});
	});

	it('should modify the filterParams and search on a sorting change', () => {
		component.sortPageObj = fakeEmptyFilterParams;
		component.sortPageObj.pageIndex = 2;
		component.onSortChange({active: 'name', direction: 'desc'} as MatSort);
		expect(component.sortPageObj).toEqual(fakeSortFilterParams);
	});
});
