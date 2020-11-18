import { ICommonMinerals, ICommonVitamins, INutritionFacts } from './ingredient-model';
import { ReferenceItemFull } from './reference.model';

export interface IRawFoodIngredient {
	commonMinerals: ICommonMinerals;
	commonVitamins: ICommonVitamins;
	foodGroupId: number;
	foodGroup: ReferenceItemFull;
	id: number;
	name: string;
	nutritionFacts: INutritionFacts;
	pralScore?: number;
	usdaFoodId: string;
}