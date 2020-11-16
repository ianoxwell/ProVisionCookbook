import { Input, OnInit, EventEmitter, Output, Component } from '@angular/core';
import { FormGroup, FormBuilder } from '@angular/forms';
import { debounce, tap, takeUntil, debounceTime, distinctUntilChanged, map, filter } from 'rxjs/operators';
import { interval } from 'rxjs';

import { ComponentBase } from './base.component.base';

@Component({template: ''})
export abstract class BaseFilterComponent<T = any> extends ComponentBase implements OnInit {
	@Output() filterChange = new EventEmitter<T>();
	// example: IFilterQuery = { keywords: '' }
	@Input() filterGroup: T;

	group: FormGroup;

	constructor(
		private fb: FormBuilder
	) {
		super();
	}

	ngOnInit(): void {
		this.group = this.buildFilterForm();
		this.formDebounce();
	}

	formDebounce(): void {
		this.group.valueChanges.pipe(
			map((query: string) => query ? query.trim() : ''),
			filter(Boolean), // may not need this filter - needs more testing
			debounceTime(500),
			distinctUntilChanged(),
			tap((filterValues: T) => this.filterChange.emit(filterValues)),
			takeUntil(this.ngUnsubscribe),
		).subscribe();
	}

	buildFilterForm(): FormGroup {
		return this.fb.group(this.filterGroup);
	}

	clearFilters(): void {
		this.group.reset();
	}


}
