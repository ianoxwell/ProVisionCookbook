import { Component, Input, OnChanges, OnInit, SimpleChanges } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { PageEvent } from '@angular/material/paginator';
import { ComponentBase } from '@components/base/base.component.base';
import { IRecipeFilterQuery, RecipeFilterQuery } from '@models/filter-queries.model';
import { ReferenceAll, ReferenceItemFull } from '@models/reference.model';
import { OrderRecipesBy } from '@models/static-variables';
import { ReferenceService } from '@services/reference.service';
import { StateService } from '@services/state.service';
import { Observable } from 'rxjs';
import { debounceTime, map, takeUntil, tap } from 'rxjs/operators';

@Component({
	selector: 'app-search-bar',
	templateUrl: './search-bar.component.html',
	styleUrls: ['./search-bar.component.scss']
})
export class SearchBarComponent extends ComponentBase implements OnInit, OnChanges {
	searchForm: FormGroup;
	@Input() filterQuery: RecipeFilterQuery;
	@Input() dataLength: number;
	orderRecipesBy = OrderRecipesBy;
	allergyArray$: Observable<ReferenceItemFull[]>;

	constructor(private fb: FormBuilder, private referenceService: ReferenceService, private stateService: StateService) {
		super();
		this.createForm();
	}

	ngOnInit() {
		this.allergyArray$ = this.referenceService.getAllReferences().pipe(
			map((allRef: ReferenceAll) => {
				return allRef.AllergyWarning;
			}),
			takeUntil(this.ngUnsubscribe)
		);
		this.searchForm.valueChanges
			.pipe(
				debounceTime(500),
				tap((values: RecipeFilterQuery) => {
					Object.keys(this.searchForm.getRawValue()).forEach(key => {
						if (values[key]) {
							this.filterQuery[key] = values[key];
						}
					});
					this.filterQuery.page = 0;
					console.log('new value', values, this.filterQuery);
					this.stateService.setRecipeFilterQuery(this.filterQuery);
				}),
				takeUntil(this.ngUnsubscribe)
			)
			.subscribe();
	}

	ngOnChanges(changes: SimpleChanges): void {
		if (!!changes.filterQuery && changes.filterQuery.firstChange) {
			this.patchForm(this.filterQuery);
		}
	}

	// triggers from the MatPaginator - emits the filterQuery object
	pageChange(ev: PageEvent): void {
		console.log('page event', ev);
		if (ev.previousPageIndex !== ev.pageIndex) {
			this.filterQuery.page = ev.pageIndex;
		} else {
			this.filterQuery.page = 0;
			this.filterQuery.perPage = ev.pageSize;
		}
		this.stateService.setRecipeFilterQuery(this.filterQuery);
	}

	patchForm(item: IRecipeFilterQuery) {
		if (!item) {
			item = new RecipeFilterQuery();
		}
		this.searchForm.patchValue({
			name: item.name,
			ingredient: item.ingredient,
			author: item.author,
			totalTime: item.totalTime,
			servingPrice: item.servingPrice, // search priceServing {$le: servingTime}
			recipeCreated: item.recipeCreated, // date number greater than the number set ie today - 7 days
			equipment: item.equipment, // {favouriteFoods: {"$in": ["sushi", "hotdog"]}}
			recipeType: item.recipeType,
			healthLabels: item.healthLabels,
			cuisineType: item.cuisineType,
			allergyWarning: item.allergyWarning, // { "allergyWarnings": { "$not": { "$all": [allergyWarning] } } }
			orderby: item.orderby || 'name',
			perPage: item.perPage || 10,
			page: item.page || 0
		});
	}

	get totalTime() {
		return this.searchForm.get('totalTime');
	}
	get servingPrice() {
		return this.searchForm.get('servingPrice');
	}

	createForm() {
		this.searchForm = this.fb.group({
			name: '',
			ingredient: '',
			author: '',
			totalTime: 0,
			servingPrice: 0, // search priceServing {$le: servingTime}
			recipeCreated: 0, // date number greater than the number set ie today - 7 days
			equipment: [], // {favouriteFoods: {"$in": ["sushi", "hotdog"]}}
			recipeType: [],
			healthLabels: [],
			cuisineType: [],
			allergyWarning: [], // { "allergyWarnings": { "$not": { "$all": [allergyWarning] } } }
			orderby: 'name',
			perPage: 10,
			page: 0
		});
	}

	clearFilterTerms() {
		this.searchForm.reset();
		this.searchForm.patchValue({
			orderby: 'name',
			perPage: 10,
			page: 0
		});
		this.filterQuery = this.searchForm.getRawValue();
		this.stateService.setRecipeFilterQuery(this.filterQuery);
	}
}
