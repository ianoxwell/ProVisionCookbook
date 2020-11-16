/**
 * Provisioners CookBook Api
 * This is the API for the Provisioner's CookBook Project
 *
 * OpenAPI spec version: 1.0.0-oas3
 * Contact: ianoxwell@gmail.com
 *
 * NOTE: This class is auto generated by the swagger code generator program.
 * https://github.com/swagger-api/swagger-codegen.git
 * Do not edit the class manually.
 */
import { ApiLinks } from './apiLinks';

export interface IngredientList {
	_id?: string;
	/**
	 * The mongo ID of the ingredient to use
	 */
	ingredientId?: string;
	ingredientName: string;
	/**
	 * if stored as 0.5, 0.75 convert to symbol / fraction when displaying - 0.66 = 1/3
	 */
	quantity?: number;
	/**
	 * pinch, cup, kg, grams etc
	 */
	unit?: string;
	/**
	 * each or whole, sliced, shredded, blank
	 */
	state?: string;
	/**
	 * optional field to replace ingredient name - not used in any calculations
	 */
	text?: string;
	allergies?: Array<string>;
	/**
	 * to order / shift around the ingredients
	 */
	preference?: number;
	links?: ApiLinks;
}