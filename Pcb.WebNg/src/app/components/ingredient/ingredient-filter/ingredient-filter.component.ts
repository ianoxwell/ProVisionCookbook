import { Component, Input, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { ComponentBase } from '@components/base/base.component.base';
import { IIngredientFilterObject, IngredientFilterObject } from '@models/filter-queries.model';
import { ReferenceAll } from '@models/reference.model';
import { StateService } from '@services/state.service';
import { Observable, of } from 'rxjs';
import { debounceTime, first, map, takeUntil, tap } from 'rxjs/operators';

@Component({
	selector: 'app-ingredient-filter',
	templateUrl: './ingredient-filter.component.html',
	styleUrls: ['./ingredient-filter.component.scss']
})
export class IngredientFilterComponent extends ComponentBase implements OnInit {
	searchForm: FormGroup;
	@Input() refData: ReferenceAll = {};
	filterQuery: IIngredientFilterObject = new IngredientFilterObject();
	isFormReady$: Observable<boolean> = of(false);

	constructor(private fb: FormBuilder, private stateService: StateService) {
		super();
	}

	ngOnInit() {
		this.isFormReady$ = this.listenStateService();
	}

	/**
	 * On init check that the stateService does not hold existing filter items
	 */
	listenStateService(): Observable<boolean> {
		return this.stateService.getIngredientFilterQuery().pipe(
			first(),
			map((filterObj: IngredientFilterObject) => {
				this.filterQuery = filterObj;
				this.searchForm = this.createForm();
				this.listenFormChanges();
				return true;
			})
		);
	}

	/**
	 * Listens for form changes and sets the stateService ingredientFilter object appropriately, disposed of with the component
	 */
	listenFormChanges(): void {
		this.searchForm.valueChanges
			.pipe(
				debounceTime(500),
				tap(() => {
					this.filterQuery = {
						...this.filterQuery,
						...this.searchForm.getRawValue()
					}
					this.stateService.setIngredientFilterQuery(this.filterQuery);
				}),
				takeUntil(this.ngUnsubscribe)
			)
			.subscribe();
	}

	/**
	 * Creates the form after the stateService IngredientFilterQuery returns.
	 * @returns FormGroup for searchForm.
	 */
	createForm(): FormGroup {
		return this.fb.group({
			name: this.filterQuery.name,
			type: this.filterQuery.type,
			parent: this.filterQuery.parent,
			allergies: this.filterQuery.allergies,
			purchasedBy: this.filterQuery.purchasedBy
		});
	}

	/**
	 * Called from the template, resets the form and sets the ingredientFilter state.
	 */
	clearFilterTerms(): void {
		this.searchForm.reset();
		this.stateService.setIngredientFilterQuery(new IngredientFilterObject());
	}
}
