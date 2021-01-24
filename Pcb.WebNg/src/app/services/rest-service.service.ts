import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { IngredientFilterObject, PagedResult, SortPageObj } from '@models/common.model';
import {
	IRawFoodIngredient,
	IRawFoodSuggestion,
	ISpoonConversion,
	ISpoonFoodRaw,
	ISpoonSuggestions
} from '@models/raw-food-ingredient.model';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Ingredient } from '../models/ingredient';
import { Suggestion } from '../models/suggestion';





@Injectable({
  providedIn: 'root'
})
export class RestService {
	private defaultHeader = new HttpHeaders()
		.set('Content-Type', 'application/json;odata=verbose')
		.set('Accept', 'application/json;odata=verbose');
	private apiUrl = environment.apiUrl + environment.apiVersion;
	private foodUrl = 'https://api.spoonacular.com';
	private foodApiKey = `8dc563dbb7eb4a7c8cf49c913d6fce36`;
	private static handleError(err: any): Promise<any> {
		console.error('Something has gone wrong', err.error);
		return Promise.reject(err.error || err);
	}
	constructor(private httpClient: HttpClient) {

	}

	public getRandomSpoonacularRecipe(): Observable<any> {
		console.log('get spoon random', `${this.foodUrl}/recipes/random?limitLicense=true&number=3&apiKey=${this.foodApiKey}`);
		return this.httpClient.get<any>(
			`${this.foodUrl}/recipes/random?limitLicense=true&number=3&apiKey=${this.foodApiKey}`,
			{ headers: this.defaultHeader });
	}
	public getSpoonacularIngredient(ingredientID: string): Observable<ISpoonFoodRaw> {
		return this.httpClient.get<ISpoonFoodRaw>(
			`${this.foodUrl}/food/ingredients/${ingredientID}/information?amount=100&unit=grams&apiKey=${this.foodApiKey}`,
			{ headers: this.defaultHeader });
	}

	public getSpoonacularSuggestions(foodName: string, limit: number = 5): Observable<ISpoonSuggestions[]> {
		const queryStr = `?query=${foodName}&number=${limit}&metaInformation=true`;
		return this.httpClient.get<ISpoonSuggestions[]>(
			`${this.foodUrl}/food/ingredients/autocomplete${queryStr}&apiKey=${this.foodApiKey}`,
			{ headers: this.defaultHeader });
	}

	public getSpoonConversion(foodName: string, sourceUnit: string, sourceAmount: number, targetUnit: string): Observable<ISpoonConversion> {
		const queryStr = `?ingredientName=${foodName}&sourceUnit=${sourceUnit}&sourceAmount=${sourceAmount}&targetUnit=${targetUnit}`;
		return this.httpClient.get<ISpoonConversion>(
			`${this.foodUrl}/recipes/convert${queryStr}&apiKey=${this.foodApiKey}`,
			{ headers: this.defaultHeader });
	}

		public getIngredient(queryObject: SortPageObj, filterObject: IngredientFilterObject): Observable<PagedResult<Ingredient>> {
			let queryString = '?';
			if (queryObject.pageIndex) { queryString += `page=${queryObject.pageIndex * queryObject.pageSize}&`; }
			if (queryObject.pageSize) { queryString += `pageSize=${queryObject.pageSize}&`; }
			// if (queryObject.active) { queryString += `sort=${queryObject.active}%3D${queryObject.direction}&`; }
			if (queryObject.sort) {
				queryString += `sort=${queryObject.sort}&`;
				if (queryObject.order) { queryString += `order=${queryObject.order}&`; }
			}
			if (filterObject.name) { queryString += `filter=${filterObject.name}&`; }
			queryString = queryString.slice(0, -1);
			return this.httpClient.get<PagedResult<Ingredient>>(`${this.apiUrl}ingredient/search${queryString}`, {headers: this.defaultHeader});
		}

	public getIngredientSuggestion(queryString: string): Observable<Suggestion[]> {
		return this.httpClient.get<Suggestion[]>(this.apiUrl + 'ingredient/suggestion' + queryString, {headers: this.defaultHeader});
	}
	public getIngredientById(ingredientId: number): Observable<Ingredient> {
		return this.httpClient.get<Ingredient>(`${this.apiUrl}ingredient/${ingredientId}`, {headers: this.defaultHeader});
	}
	public createIngredient(ingredient: Ingredient): Observable<Ingredient> {
		return this.httpClient.post<Ingredient>(this.apiUrl + 'ingredient', ingredient,
			{headers: this.defaultHeader});
	}
	public updateIngredient(ingredientId: number, update: any): Observable<Ingredient> {
		return this.httpClient.put<Ingredient>(`${this.apiUrl}ingredient/${ingredientId}`, update,
			{headers: this.defaultHeader});
	}
	public deleteItem(itemID: number): Observable<Ingredient> {
		return this.httpClient.delete<Ingredient>(`${this.apiUrl}ingredient/${itemID}`, {headers: this.defaultHeader});
	}

	public getRawFoodSuggestion(queryString: string, limit: number = 10, foodGroupId: number = 0): Observable<IRawFoodSuggestion[]> {
		let queryStr = `?filter=${queryString}&limit=${limit}`;
		if (foodGroupId > 0) {
			queryStr += `&foodGroupId=${foodGroupId}`
		}
		return this.httpClient.get<IRawFoodSuggestion[]>(`${this.apiUrl}rawfooddata/suggestion${queryStr}`, {headers: this.defaultHeader})
	}

	public getRawFoodById(usdaId: string): Observable<IRawFoodIngredient> {
		return this.httpClient.get<IRawFoodIngredient>(`${this.apiUrl}rawfooddata/${usdaId}`);
	}

	public checkFoodNameExists(filter: string, foodId: number = 0): Observable<boolean> {
		const queryStr = `?filter=${filter}&foodId=${foodId}`;
		return this.httpClient.get<boolean>(`${this.apiUrl}ingredient/check-name${queryStr}`);
	}

}
