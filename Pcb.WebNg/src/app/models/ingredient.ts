import { Conversion } from './conversion';
import { ICommonMinerals, ICommonVitamins, INutritionFacts, PriceModel } from './ingredient-model';
import { ReferenceItemFull } from './reference.model';

export interface Ingredient {
	allergies?: Array<ReferenceItemFull>;
	commonMinerals: ICommonMinerals;
	commonVitamins: ICommonVitamins;
	foodGroup: ReferenceItemFull;
	id: number;
	ingredientConversions?: Array<Conversion>;
	ingredientStateId?: number;
	linkUrl: string;
	name: string;
	nutritionFacts: INutritionFacts;
	parentId?: number;
	pralScore?: number;
	price?: PriceModel,
	purchasedBy?: IngredientNameSpace.PurchasedByEnum;
	recipes?: [{
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
