import { Component, EventEmitter, Input, OnChanges, Output, SimpleChanges, ViewChild } from '@angular/core';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { ISortPageObj, PagedResult, SortPageObj } from '@models/common.model';
import { ComponentBase } from './base.component.base';

@Component({ template: '' })
export abstract class BaseTableComponent<T = any> extends ComponentBase implements OnChanges {
	@Input() data: PagedResult<T>;
	@Input() sortPageObj: ISortPageObj = new SortPageObj();
	@Output() sortingPageChange = new EventEmitter<ISortPageObj>();
	@Output() updateTableRequest = new EventEmitter();

	@ViewChild(MatPaginator, { static: true }) paginator: MatPaginator;
	@ViewChild(MatSort, {static: true}) sort: MatSort;

	displayedColumns: string[];
	dataSource: MatTableDataSource<T>;
	dataLength: number;

	constructor( ) { super(); }

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
		this.sortPageObj.orderby = ev.active;
		this.sortPageObj.order = ev.direction;
		this.sortPageObj.page = 0;
		this.sortingPageChange.emit(this.sortPageObj);
	}

	onPageChange(pageEvent: PageEvent): void {
		if (pageEvent.pageSize !== this.sortPageObj.perPage) {
			this.sortPageObj.page = 0;
			this.sortPageObj.perPage = pageEvent.pageSize;
		} else {
			this.sortPageObj.page = pageEvent.pageIndex;
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
