import { Injectable } from '@angular/core';
import { IngredientFilterObject } from '@models/common.model';
import { FilterQuery } from '@models/filterQuery';
import { BehaviorSubject, Observable } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable({
	providedIn: 'root'
})
export class StateService {
	private recipeFilterQuery$ = new BehaviorSubject<FilterQuery>({
		orderby: 'name',
		order: 'asc',
		perPage: environment.resultsPerPage,
		page: 0
	});
	private ingredientFilterQuery$ = new BehaviorSubject<IngredientFilterObject>({ name: '' });

	getRecipeFilterQuery(): Observable<FilterQuery> {
		return this.recipeFilterQuery$.asObservable();
	}

	setRecipeFilterQuery(query: FilterQuery): void {
		this.recipeFilterQuery$.next(query);
	}

	getIngredientFilterQuery(): Observable<IngredientFilterObject> {
		return this.ingredientFilterQuery$.asObservable();
	}

	setIngredientFilterQuery(query: IngredientFilterObject): void {
		this.ingredientFilterQuery$.next(query);
	}
}
