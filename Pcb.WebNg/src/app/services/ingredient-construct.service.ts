import { Injectable } from '@angular/core';
import { Conversion } from '@models/conversion';
import { Ingredient } from '@models/ingredient';
import { MeasurementModel } from '@models/ingredient-model';
import { IRawFoodIngredient, ISpoonConversion, ISpoonFoodRaw } from '@models/raw-food-ingredient.model';
import { ReferenceItemFull } from '@models/reference.model';
// import { IngredientModel, ConversionModel, PriceModel } from './ingredient-model';

@Injectable({
	providedIn: 'root'
})
export class IngredientConstructService {
	constructor() {}
	public createNewIngredient(
		basicInfo: { name: string; foodGroup: number },
		usda: IRawFoodIngredient,
		spoon: ISpoonFoodRaw,
		spoonConversions: ISpoonConversion[],
		foodGroupRef: ReferenceItemFull[],
		ingredientStateRef: ReferenceItemFull[],
		measurementRef: MeasurementModel[]
	): Ingredient {
		const ingredientState: ReferenceItemFull = ingredientStateRef.find(
			(state: ReferenceItemFull) => state.title.toLowerCase() === spoon.consistency.toLowerCase()
		);

		return {
			id: 0,
			name: basicInfo.name,
			foodGroup: foodGroupRef.find((food: ReferenceItemFull) => food.id === basicInfo.foodGroup),
			usdaFoodId: usda.id?.toString(),
			pralScore: usda.pralScore,
			//   createdAt: Date.now().toString(),
			//   updatedAt: Date.now().toString(),
			commonMinerals: usda.commonMinerals,
			commonVitamins: usda.commonVitamins,
			nutritionFacts: usda.nutritionFacts,
			linkUrl: spoon.id.toString(),
			ingredientStateId: ingredientState ? ingredientState.id : 0,
			ingredientConversions: this.conversions(spoonConversions, ingredientState, measurementRef)

			// purchasedBy
			// allergies
			// parentId
			// price
		};
	}

	public conversions(convert: ISpoonConversion[], ingredientState: ReferenceItemFull, measure: MeasurementModel[]): Conversion[] {
		// expect convert to be an array returned from dialog-ingredient.component or a partial object
		// {key: newKey, value: newValue, changeType: 'sub', subDocName: 'conversions', subId: docSubId}
		console.log('starting the conversion process', ingredientState, measure);
		const findMeasureModel: (title: string) => MeasurementModel = (title: string) => {
			const measurement = measure.find((m: MeasurementModel) => {
				const success =
					m.title.toLowerCase() === title.toLowerCase() ||
					m.shortName?.toLowerCase() === title.toLowerCase() ||
					m.altShortName?.toLowerCase() === title.toLowerCase();
				console.log('measurement test', title, success);
				return success;
			});
			console.log('correct measurement', measurement);
			return measurement;
		};
		const returnConvert: Conversion[] = convert.map((item: ISpoonConversion, idx: number) => {
			if (item.sourceUnit === '') {
				// convert US to AU cups - approximation based on general results of known items
				item.targetAmount = Math.floor(item.targetAmount / 0.94636);
			}
			return {
				baseState: ingredientState,
				baseMeasurementUnit: findMeasureModel(item.sourceUnit), // [0],
				baseQuantity: 1,
				convertToState: ingredientState,
				convertToMeasurementUnit: findMeasureModel(item.targetUnit),
				convertToQuantity: item.targetAmount,
				answer: item.answer,
				preference: idx
			};
		});
		return returnConvert;
	}
}
