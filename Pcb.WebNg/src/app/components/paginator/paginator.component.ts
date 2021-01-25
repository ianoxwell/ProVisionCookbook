import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { FormBuilder, FormControl, FormGroup } from '@angular/forms';
import { PageEvent } from '@angular/material/paginator';

@Component({
	selector: 'app-paginator',
	templateUrl: './paginator.component.html',
	styleUrls: ['./paginator.component.scss']
})
export class PaginatorComponent implements OnInit {
	/** The current page index. */
	@Input() pageIndex = 0;
	/** Current max number of items to display */
	@Input() pageSize = 25;
	/** Total count of all items to be displayed */
	@Input() length = 0;
	@Input() pageSizeOptions: number[] = [5, 10, 25];
	@Input() hidePageSize = false;
	@Input() showFirstLastButtons = true;
	@Input() horizontalLayout = true;
	/** Event emitted when the paginator changes the page size or page index. */
	@Output() readonly page = new EventEmitter<PageEvent>();

	form: FormGroup = {} as FormGroup;
	constructor( private fb: FormBuilder ) {
		this.form = this.fb.group({
			perPage: this.pageSize
		});
	}

	get perPage(): FormControl {
		return this.form.get('perPage') as FormControl;
	}

	ngOnInit() {}

	/** Advances to the next page if it exists. */
	nextPage(): void {
		if (this.hasNextPage()) {
			this.pageIndex ++;
			this.emitChanges();
		}
	}
	/** Move back to the previous page if it exists. */
	previousPage(): void {
		if (this.hasPreviousPage()) {
			this.pageIndex --;
			this.emitChanges();
		}
	}
	/** Move to the first page if not already there. */
	firstPage(): void {
		this.pageIndex = 0;
		this.emitChanges();
	}
	/** Move to the last page if not already there. */
	lastPage(): void {
		this.pageIndex = this.getNumberOfPages();
		this.emitChanges();
	}
	/** Whether there is a previous page. */
	hasPreviousPage(): boolean {
		return this.pageIndex > 0;
	}
	/** Whether there is a next page. */
	hasNextPage(): boolean {
		return this.length - (this.pageIndex * this.pageSize + this.pageSize) > 0;
	}
	/** Calculate the number of pages */
	getNumberOfPages(): number {
		return this.pageSize > 0 ? Math.ceil(this.length / this.pageSize) : 0;
	};

	emitChanges() {
		this.page.emit({
			pageIndex: this.pageIndex,
			pageSize: this.pageSize,
			length: this.length
		})
	}
}
