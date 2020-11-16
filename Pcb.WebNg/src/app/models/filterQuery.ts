/**
 * Provisioners CookBook Api
 * This is the API for the Provisioner's CookBook Project
 *
 * OpenAPI spec version: 1.0.0-oas3
 * Contact: ianoxwell@gmail.com
 *
 */

export interface FilterQuery {
	name?: string; // match=name%3D${filterQuery.name}& (indexed search on name)
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
	orderby: string;
	order?: string;
	perPage: number;
	page: number;
}
