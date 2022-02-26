import { Conversion } from './conversion';
import { ICommonMinerals, ICommonVitamins, INutritionFacts, PriceModel } from './ingredient-model';
import { ReferenceItemFull } from './reference.model';

export interface Ingredient {
	allergies?: ReferenceItemFull[];
	commonMinerals?: ICommonMinerals;
	commonVitamins?: ICommonVitamins;
	foodGroup?: ReferenceItemFull;
	id?: number;
	ingredientConversions?: Conversion[];
	ingredientStateId?: number;
	linkUrl?: number; // spoonacular id number
	name: string;
	nutritionFacts?: INutritionFacts;
	parentId?: number;
	pralScore?: number;
	price?: PriceModel,
	purchasedBy?: IngredientNameSpace.PurchasedByEnum;
	recipes?: [{
		id: number;
		name: string;
		teaser: string;
	}]
	usdaFoodId?: number;
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
