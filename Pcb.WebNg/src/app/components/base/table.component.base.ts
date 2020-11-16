import { ComponentBase } from './base.component.base';
import { Component, OnChanges, EventEmitter, Input, Output, ViewChild, SimpleChanges } from '@angular/core';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { PagedResult, SortPageObj, ISortPageObj } from '@models/common.model';
import { Observable } from 'rxjs';

@Component({ template: '' })
export abstract class BaseTableComponent<T = any> extends ComponentBase implements OnChanges {
	@Input() data: PagedResult<T>;
	@Input() sortPageObj: SortPageObj;

	@Output() sortingPageChange = new EventEmitter<ISortPageObj>();
	@Output() updateTableRequest = new EventEmitter();

	@ViewChild(MatPaginator, { static: true }) paginator: MatPaginator;
	@ViewChild(MatSort, {static: true}) sort: MatSort;

	displayedColumns: string[];
	dataSource: MatTableDataSource<T>;
	dataLength: number;

	constructor() { super(); }

	ngOnChanges(change: SimpleChanges): void {
		console.log('table base change', change);
		if (!!change.data && !change.data.firstChange) {
			this.dataSource.data = change.data.currentValue.items;
			this.dataLength =  change.data.currentValue.total;
		}
	}
	// This must be implemented by any subclass
	abstract goto(row: any);

	onSortChange(ev: MatSort): void {
		this.sortPageObj.sort = ev.active;
		this.sortPageObj.order = ev.direction;
		this.sortPageObj.pageIndex = 0;
		this.sortingPageChange.emit(this.sortPageObj);
	}

	onPageChange(pageEvent: PageEvent): void {
		if (pageEvent.pageSize !== this.sortPageObj.pageSize) {
			this.sortPageObj.pageIndex = 0;
			this.sortPageObj.pageSize = pageEvent.pageSize;
		} else {
			this.sortPageObj.pageIndex = pageEvent.pageIndex;
		}
		this.sortingPageChange.emit(this.sortPageObj);
	}

	mouseRow(row: any, inOut: string) {
		if (inOut === 'over') {
			row.mouseRow = true;
		} else {
			row.mouseRow = null;
		}
	}
}
