/**
 * Provisioner's CookBook Api
 * This is the API for the Provisioner's CookBook Project
 *
 * OpenAPI spec version: 1.0.0-oas3
 * Contact: ianoxwell@gmail.com
 *
 * NOTE: This class is auto generated by the swagger code generator program.
 * https://github.com/swagger-api/swagger-codegen.git
 * Do not edit the class manually.
 */

import {Conversion} from './conversion';
import { ICaloricBreakdown, ICommonMinerals, ICommonVitamins, INutritionFacts, PriceModel } from './ingredient-model';
import {Nutrition} from './nutrition';
import {Recipe} from './recipe';
import {ReferenceItemFull} from './reference.model';

export interface Ingredient {
	allergies: Array<ReferenceItemFull>;
	caloricBreakdown: ICaloricBreakdown;
	calories: number;
	commonMinerals: ICommonMinerals;
	commonVitamins: ICommonVitamins;
	foodGroup: ReferenceItemFull;
	id: number;
	ingredientConversions?: Array<Conversion>;
	ingredientStateId?: number;
	linkUrl: string;
	name: string;
	nutritionFacts: INutritionFacts;
	parentId: number;
	pralScore?: number;
	price: PriceModel,
	purchasedBy?: IngredientNameSpace.PurchasedByEnum;
	recipes: [{
		id: number;
		name: string;
		teaser: string;
	}]
	usdaFoodId: string;
	image?: string;
	updatedAt?: string | Date;
	createdAt?: string | Date;
}

export enum PurchasedBy {
	Volume,
	Weight,
	Item
}
// tslint:disable-next-line: no-namespace
export namespace IngredientNameSpace {
	export type PurchasedByEnum = 'weight' | 'volume' | 'individual' | 'bunch';
	export const PurchasedByEnum = {
		Weight: 'weight' as PurchasedByEnum,
		Volume: 'volume' as PurchasedByEnum,
		Individual: 'individual' as PurchasedByEnum,
		Bunch: 'bunch' as PurchasedByEnum
	};
}