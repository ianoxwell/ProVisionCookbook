import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import {Observable} from 'rxjs';

import { Recipe, Recipes } from '../models/recipe';
import { FilterQuery } from '@models/filterQuery';
import { environment } from 'src/environments/environment';
import { Suggestions } from '@models/suggestion';


@Injectable({
  providedIn: 'root'
})
export class RecipeRestService {
  private defaultHeader = new HttpHeaders()
  .set('Content-Type', 'application/json;odata=verbose')
  .set('Accept', 'application/json;odata=verbose');
  private apiURL = environment.apiUrl + environment.apiVersion;

  constructor(
	private httpClient: HttpClient
  ) { }
  public getRecipe(filterQuery: FilterQuery): Observable<Recipes> {
	if (!filterQuery) {
		filterQuery = {
			orderby: 'name',
			order: 'asc',
			perPage: 50,
			page: 0
		};
	}
	// sanity checks
	if (filterQuery.perPage < 1) {
		filterQuery.perPage = 25;
	}
	if (filterQuery.page < 0) {
		filterQuery.page = 0;
	}
	let queryString = `?pageSize=${filterQuery.perPage}&page=${(filterQuery.page) * filterQuery.perPage}&sort=${filterQuery.orderby}&`;
	if (filterQuery.order) { queryString += `order=${filterQuery.order}`}
	if (filterQuery.name) { queryString += `filter=${filterQuery.name}&`; }
	queryString = queryString.slice(0, -1);
	return this.httpClient.get<Recipes>(`${this.apiURL}recipe/search${queryString}`, {headers: this.defaultHeader});
  }

 	// don't currently have this - but good idea
	public getRecipeRandom(): Observable<Recipe> {
		return this.httpClient.get<Recipe>(this.apiURL + 'recipe/random', {headers: this.defaultHeader});
	}

	public getRecipeSuggestion(queryString: string): Observable<Suggestions> {
		return this.httpClient.get<Suggestions>(this.apiURL + 'recipe/suggestion' + queryString, {headers: this.defaultHeader});
	}

	public getRecipeById(itemId: string): Observable<Recipe> {
		return this.httpClient.get<Recipe>(this.apiURL + 'recipe/' + itemId, {headers: this.defaultHeader});
	}

	public createRecipe(newItem: Recipe): Observable<Recipe> {
		return this.httpClient.post<Recipe>(this.apiURL + 'recipes', newItem, {headers: this.defaultHeader});
	}

	public updateRecipe(itemId: string, update: any): Observable<Recipe> {
		return this.httpClient.put<Recipe>(this.apiURL + 'recipe/' + itemId, update,
			{headers: this.defaultHeader});
	}

	public deleteRecipe(itemID: string): Observable<Recipe> {
		return this.httpClient.delete<Recipe>(this.apiURL + 'recipe/' + itemID, {headers: this.defaultHeader});
	}

}
