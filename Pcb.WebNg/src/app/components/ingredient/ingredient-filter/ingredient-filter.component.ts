import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { FormGroup, FormBuilder } from '@angular/forms';

import { IngredientFilterObject } from '@models/common.model';
import { ComponentBase } from '@components/base/base.component.base';


import { debounceTime, tap, takeUntil } from 'rxjs/operators';
import { AllergyArray, ParentTypes } from '@models/static-variables';

@Component({
  selector: 'app-ingredient-filter',
  templateUrl: './ingredient-filter.component.html',
  styleUrls: ['./ingredient-filter.component.scss']
})
export class IngredientFilterComponent extends ComponentBase implements OnInit {
	searchForm: FormGroup;
	@Input() filterQuery: IngredientFilterObject;
	@Output() filterChanged = new EventEmitter<IngredientFilterObject>();

	allergyArray = AllergyArray;
	parentTypes = ParentTypes;

	constructor(private fb: FormBuilder) {
		super();
		this.createForm();
	}

	ngOnInit() {
		this.searchForm.valueChanges.pipe(
			debounceTime(500),
			tap((values: IngredientFilterObject) => {
				Object.keys(this.searchForm.getRawValue()).forEach(key => {
					if (values[key]) {
						this.filterQuery[key] = values[key];
					}
				});
				this.filterChanged.emit(this.filterQuery);
			}),
			takeUntil(this.ngUnsubscribe)
		).subscribe();
	}

	createForm(): void {
		this.searchForm = this.fb.group({
			name: '',
			type: [],
			parent: '',
			allergies: [],
			purchasedBy: ''
		});
	}

	clearFilterTerms() {
		this.searchForm.reset();
		this.filterQuery = this.searchForm.getRawValue();
		this.filterChanged.emit(this.filterQuery);
	}

}
