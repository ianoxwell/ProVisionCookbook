import { Injectable } from '@angular/core';
import { Conversion } from '@models/conversion';
import { Ingredient } from '@models/ingredient';
import { Price } from '@models/price';
// import { IngredientModel, ConversionModel, PriceModel } from './ingredient-model';

@Injectable({
  providedIn: 'root'
})
export class IngredientConstructService {
  constructor() { }
  public createNewIngredient(ingredient: any, newItem?: boolean): Ingredient {
	const returnItem = {} as Ingredient;
	if (!Array.isArray(ingredient)) {
	  console.log('where did this come from createNewIngredient');
	  return {} as Ingredient;
	} else {
	  ingredient.map((item) => {
		returnItem[item.key] = item.value;
	  });
	  if (newItem === true && (!returnItem.name || !returnItem.foodGroup || !returnItem.purchasedBy )) {
		return {} as Ingredient;
	  } else {
		return returnItem;
	  }
	}
	// return {
	//   _id: null,
	//   name: 'Wholemeal Flour',
	//   parent: 'Flour',
	//   allergies: ['Gluten', 'Starch'],
	//   purchasedBy: 'kg',
	//   createdOn: Date.now(),
	//   modifiedOn: Date.now(),
	//   averagePrice: 0,
	//   prices: [
	//     {
	//       brandName: 'HomeBrand',
	//       price: 1.5,
	//       quantity: 1,
	//       measurement: 'kg',
	//       storeName: 'Coles',
	//       lastChecked: Date.now(),
	//       apiLink: null
	//     },
	//     {
	//       brandName: 'Luka',
	//       price: 16.20,
	//       quantity: 2,
	//       measurement: 'kg',
	//       storeName: 'Woolworths',
	//       lastChecked: Date.now(),
	//       apiLink: null
	//     }
	//   ],
	//   conversions: [
	//     {
	//       measureA: 'kg',
	//       quantityA: 0.4,
	//       stateA: 'boiled',
	//       measureB: 'cup',
	//       quantityB: 1,
	//       stateB: 'mashed',
	//       preference: 0
	//     }
	//   ]
	// };
  }
  public prices(price: any, newItem?: boolean): Price | string {
	// expect convert to be an array returned from dialog-ingredient.component or a partial object
	// {key: newKey, value: newValue, changeType: 'sub', subDocName: 'prices', subId: docSubId}
	const returnPrice = {} as Price;
	let errorText = 'Missing Field - ';
	if (!Array.isArray(price)) {
	  if (!newItem) {
		returnPrice._id = price._id;
	  }
	  (price.brandName) ? returnPrice.brandName = price.brandName : errorText = errorText + 'brandName';
	  (price.price) ? returnPrice.price = price.price : errorText = errorText + 'price';
	  (price.quantity) ? returnPrice.quantity = price.quantity : errorText = errorText + 'quantity';
	  (price.measurement) ? returnPrice.measurement = price.measurement : errorText = errorText + 'measurement';
	  (price.storeName) ? returnPrice.storeName = price.storeName : returnPrice.storeName = '';
	  (price.lastChecked) ? returnPrice.lastChecked = price.lastChecked : returnPrice.lastChecked = Date.now();
	  (price.apiLink) ? returnPrice.apiLink = price.apiLink : returnPrice.apiLink = '';
	  return (errorText === 'Missing Field - ') ? returnPrice : errorText;
	} else {
	  price.map((item) => {
		returnPrice[item.key] = item.value;
	  });
	  if (!newItem) {
		returnPrice._id = price[0].subId;
	  }
	  if (newItem === true && (!returnPrice.brandName || !returnPrice.price || !returnPrice.quantity || !returnPrice.measurement)) {
		return errorText + 'unable to create new Price';
	  } else {
		return returnPrice;
	  }
	}
  }
public conversions(convert: any, newItem?: boolean): Conversion | string {
	// expect convert to be an array returned from dialog-ingredient.component or a partial object
	// {key: newKey, value: newValue, changeType: 'sub', subDocName: 'conversions', subId: docSubId}
	const returnConvert = {} as Conversion;
	let errorText = 'Missing Field - ';
	if (!Array.isArray(convert)) {
	  if (!newItem) {
		returnConvert._id = convert._id;
	  }
	  (convert.measureA) ? returnConvert.measureA = convert.measureA : errorText = errorText + 'measureA';
	  (convert.stateA) ? returnConvert.stateA = convert.stateA : returnConvert.stateA = '';
	  (convert.quantityA) ? returnConvert.quantityA = convert.quantityA : errorText = errorText + 'quantityA';
	  (convert.measureB) ? returnConvert.measureB = convert.measureB : errorText = errorText + 'measureB';
	  (convert.stateB) ? returnConvert.stateB = convert.stateB : returnConvert.stateB = '';
	  (convert.quantityB) ? returnConvert.quantityB = convert.quantityA : errorText = errorText + 'quantityB';
	  (convert.preference) ? returnConvert.preference = convert.preference : returnConvert.preference = 0;
	  return (errorText === 'Missing Field - ') ? returnConvert : errorText;
	} else {
	  convert.map((item) => {
		returnConvert[item.key] = item.value;
	  });
	  if (!newItem) {
		returnConvert._id = convert[0].subId;
	  }
	  // last check to ensure that the required items are completed
	  if (newItem === true && (!returnConvert.measureA || !returnConvert.quantityA ||
		!returnConvert.measureB || !returnConvert.quantityB)) {
		return errorText + 'unable to create new Price';
	  } else {
		return returnConvert;
	  }
	}
  }
}
