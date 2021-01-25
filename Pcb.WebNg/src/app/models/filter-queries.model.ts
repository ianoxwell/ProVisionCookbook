import { environment } from 'src/environments/environment';

export interface IBaseFilterObject {
	name: string; // match=name%3D${filterQuery.name}& (indexed search on name)
	orderby: string;
	order?: string;
	perPage: number;
	page: number;
	tabNumber?: number;
}

export interface IIngredientFilterObject extends IBaseFilterObject {
	type?: string[];
	parent?: string;
	allergies?: string[];
	purchasedBy?: string;
}

export class IngredientFilterObject implements IIngredientFilterObject {
	public page: number;
	public perPage: number;
	public orderby: string;
	public order: string;
	public name: string;
	constructor() {
		this.page = 0;
		this.perPage = environment.resultsPerPage;
		this.orderby = 'name';
		this.order = 'asc';
		this.name = '';
	}

}

export interface IRecipeFilterQuery extends IBaseFilterObject {
	ingredient?: string; // &filter=i
	author?: string; // &populate(param)&
	totalTime?: number; // search readyInMinutes: {$le: totalTime}
	servingPrice?: number; // search priceServing {$le: servingTime}
	recipeCreated?: string | Date; // date number greater than the number set ie today - 7 days
	equipment?: Array<string>; // {favouriteFoods: {"$in": ["sushi", "hotdog"]}}
	recipeType?: Array<string>;
	healthLabels?: Array<string>;
	cuisineType?: Array<string>;
	allergyWarning?: Array<string>; // { "allergyWarnings": { "$not": { "$all": [allergyWarning] } } }
}

export class RecipeFilterQuery implements IRecipeFilterQuery {
	public page: number;
	public perPage: number;
	public orderby: string;
	public name: string;
	constructor() {
		this.page = 0;
		this.perPage = environment.resultsPerPage;
		this.orderby = 'name';
		this.name = '';
	}

}