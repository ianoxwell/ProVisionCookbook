import { Injectable } from '@angular/core';
import { Ingredient } from '@models/ingredient';
import { IngredientList } from '@models/ingredient-list.model';
import { MeasurementModel } from '@models/ingredient-model';
import { ISpoonConversion, ISpoonFoodRaw } from '@models/raw-food-ingredient.model';
import { Recipe } from '@models/recipe.model';
import { ReferenceAll, ReferenceItemFull } from '@models/reference.model';
import { IEquipmentIngredient, IExtendedIngredients, IRawReturnedRecipes, ISpoonacularRecipeModel } from '@models/spoonacular-recipe.model';
import { ToTitleCasePipe } from '@pipes/title-case.pipe';
import { forkJoin, Observable } from 'rxjs';
import { switchMap } from 'rxjs/operators';
import { ConstructIngredientService } from './construct-ingredient.service';
import { RestIngredientService } from './rest-ingredient.service';
import { RestRecipeService } from './rest-recipe.service';

@Injectable({
	providedIn: 'root'
})
export class ConstructRecipeService {
	constructor(
		private restIngredientService: RestIngredientService,
		private constructIngredientService: ConstructIngredientService,
		private toTitleCase: ToTitleCasePipe,
		private restRecipeService: RestRecipeService
	) {}

	/**
	 * Creates / maps the spoonacular extended ingredient and returns an observable to create new ingredient.
	 * @param spoonIngredient The spoonacular extended ingredient.
	 * @param refDataAll All the reference data.
	 * @param measurementRef The measurement ref data.
	 * @returns Observable of ingredient for the switchMap forkJoin
	 */
	createIngredient(
		spoonIngredient: IExtendedIngredients,
		refDataAll: ReferenceAll,
		measurementRef: MeasurementModel[]
	): Observable<Ingredient> {
		let newIngredient: Ingredient;
		let spoon: ISpoonFoodRaw;
		return this.restIngredientService.getSpoonacularIngredient(spoonIngredient.id).pipe(
			switchMap((spoonRaw: ISpoonFoodRaw) => {
				spoon = spoonRaw;
				const unitFrom = spoonRaw.possibleUnits.includes('cup') ? 'cup' : 'piece';
				return this.restIngredientService.getSpoonConversion(spoonRaw.name, unitFrom, 1, 'grams');
			}),
			switchMap((spoonConversions: ISpoonConversion) => {
				const foodGroupItem = refDataAll.IngredientFoodGroup.find((fg: ReferenceItemFull) => spoon.aisle.indexOf(fg.altTitle) > 0);
				let foodGroup: number = refDataAll.IngredientFoodGroup.find((fg: ReferenceItemFull) => fg.title === 'NULL').id;
				if (!!foodGroupItem) {
					foodGroup = foodGroupItem.id;
				}
				newIngredient = this.constructIngredientService.createNewIngredient(
					{ name: this.toTitleCase.transform(spoon.name), foodGroup },
					spoon,
					[spoonConversions],
					refDataAll.IngredientFoodGroup,
					refDataAll.IngredientState,
					measurementRef
				);
				return this.restIngredientService.createIngredient(newIngredient);
			})
		);
	}

	/**
	 * Constructs a new recipe.
	 * @param recipe SpoonacularRecipeModel returned from the api query.
	 * @param userId the user id of the current logged in user.
	 * @returns new recipe.
	 */
	private createNewRecipe(recipe: ISpoonacularRecipeModel, userId: number): Recipe {
		return {
			name: recipe.title,
			numberOfServings: recipe.servings,
			readyInMinutes: recipe.readyInMinutes,
			rawInstructions: recipe.instructions,
			recipeDishTypes: [],
			recipeCuisineTypes: [],
			sourceOfRecipeName: recipe.sourceName,
			sourceOfRecipeLink: recipe.sourceUrl,
			spoonacularId: recipe.id,
			creditsText: recipe.creditsText,
			teaser: recipe.summary,
			createByUserId: userId, // logged in user.
			recipePictures: [
				{
					title: recipe.title,
					fileLink: recipe.image,
					positionPic: 'left'
				}
			],
			recipeIngredientLists: [],
			steppedInstructions: [],
			equipmentRequired: [],
			recipeDishTags: [],
			recipeHealthLabels: []
		};
	}

	/**
	 * Maps the spoonacular extended Ingredient to the local ingredientList item
	 * @param ingredient The spoonacular extended ingredient.
	 * @param index Index of the ingredient to set the preference for the ingredient order.
	 * @param ingredientId The local db id reference.
	 * @param refDataAll All the references.
	 * @param measurementRef The measurement ref item.
	 * @returns Ingredient List Item, ready to be written to db.
	 */
	private createIngredientListItem(
		ingredient: IExtendedIngredients,
		index: number,
		ingredientId: number,
		refDataAll: ReferenceAll,
		measurementRef: MeasurementModel[]
	): IngredientList {
		const wholeNumberRound = 10;
		const roundTwoPlaces = 100;
		const quantity =
			ingredient.measures.metric.amount > wholeNumberRound
				? Math.round(ingredient.measures.metric.amount)
				: Math.round(ingredient.measures.metric.amount * roundTwoPlaces) / roundTwoPlaces;
		return {
			ingredientId,
			spoonacularId: ingredient.id,
			ingredientName: this.toTitleCase.transform(ingredient.name),
			text: ingredient.originalName,
			preference: index,
			quantity,
			measurementUnit: this.constructIngredientService.findMeasureModel(ingredient.measures.metric.unitShort, measurementRef),
			ingredientState: this.findReferenceItem(ingredient.consistency, refDataAll.IngredientState)
		};
	}
	/**
	 * Finds the ingredient within All ingredient list matching on spoonacular unique id.
	 * @param allIngredients The list of all the ingredients for all the recipes that returned from Spoonacular.
	 * @param spoonId The spoonacular id of the ingredient to find.
	 * @returns A single ingredient.
	 */
	private findIngredient(allIngredients: Ingredient[], spoonId: number): Ingredient {
		return allIngredients.find((ing: Ingredient) => ing.linkUrl === spoonId);
	}
	/**
	 * Finds the reference Item from the provided data.
	 * @param title Title of the item to find in the references.
	 * @param refData The reference Data to search through.
	 * @returns a single Reference Item.
	 */
	private findReferenceItem(title: string, refData: ReferenceItemFull[]): ReferenceItemFull {
		return refData.find((item: ReferenceItemFull) => title.toLowerCase() === item.title.toLowerCase());
	}

	/**
	 * Maps the spoonacular recipe through to the local recipe.
	 * @param recipe The Spoonacular recipe.
	 * @param allIngredients All the ingredients for all the recipes.
	 * @param userId Current logged in user id.
	 * @param refDataAll All the references.
	 * @param measurementRef The measurement ref item.
	 * @returns local recipe model.
	 */
	private recipeMapping(
		recipe: ISpoonacularRecipeModel,
		allIngredients: Ingredient[],
		userId: number,
		refDataAll: ReferenceAll,
		measurementRef: MeasurementModel[]
	): Recipe {
		const newRecipe: Recipe = this.createNewRecipe(recipe, userId);
		recipe.extendedIngredients.forEach((ingredient: IExtendedIngredients, index: number) => {
			const ingredientId: number = this.findIngredient(allIngredients, ingredient.id)?.id;
			if (ingredientId) {
				newRecipe.recipeIngredientLists.push(
					this.createIngredientListItem(ingredient, index, ingredientId, refDataAll, measurementRef)
				);
			} else {
				console.log('something messed up', recipe, allIngredients);
			}
		});
		recipe.analyzedInstructions[0].steps.forEach(steep => {
			newRecipe.steppedInstructions.push({
				stepNumber: steep.number,
				stepDescription: steep.step,
				ingredients: [],
				equipment: []
			});
			steep.ingredients.forEach((item: IEquipmentIngredient) => {
				const ingredientId: number = this.findIngredient(allIngredients, item.id)?.id;
				if (!!ingredientId) {
					newRecipe.steppedInstructions[newRecipe.steppedInstructions.length - 1].ingredients.push(ingredientId);
				}
			});
			// steep.equipment.forEach(item => {
			// 	newRecipe.steppedInstructions[newRecipe.steppedInstructions.length - 1].equipment.push(
			// 		this.toTitleCase.transform(item.name)
			// 	);
			// 	// check if the equipment has been added already to the equipment array
			// 	if (newRecipe.equipmentRequired.indexOf(this.toTitleCase.transform(item.name)) === -1) {
			// 		newRecipe.equipmentRequired.push(this.toTitleCase.transform(item.name));
			// 	}
			// });
		});
		refDataAll.DishTag.forEach((tag: ReferenceItemFull) => {
			if (!!tag.altTitle && recipe[tag.altTitle] && recipe[tag.altTitle] === true) {
				newRecipe.recipeDishTags.push(tag);
			}
		});
		refDataAll.HealthLabel.forEach((diet: ReferenceItemFull) => {
			if (!!diet.altTitle && recipe[diet.altTitle] && recipe[diet.altTitle] === true) {
				newRecipe.recipeHealthLabels.push(diet);
			}
		});
		recipe.dishTypes.forEach((dish: string) => {
			const dishType = this.findReferenceItem(dish, refDataAll.DishType);
			if (!!dishType) {
				newRecipe.recipeDishTypes.push(dishType);
			} else {
				console.log('could not find this dish type', dish, refDataAll.DishType);
			}
		});
		recipe.cuisines.forEach((type: string) => {
			const cuisineType = this.findReferenceItem(type, refDataAll.CuisineType);
			if (!!cuisineType) {
				newRecipe.recipeCuisineTypes.push(cuisineType);
			} else {
				console.log('could not find this cuisine', type, refDataAll.CuisineType);
			}
		});
		return newRecipe;
	}

	/**
	 * Gets a number of random spoonacular Recipes.
	 * @param count The number of random recipes to get.
	 * @param userId The id of the currently logged in user
	 * @param refDataAll All the reference data in memory
	 * @param measurementRef The measurement reference data
	 * @returns Observable array of converted recipes
	 */
	getSpoonAcularRecipe(
		count: number,
		userId: number,
		refDataAll: ReferenceAll,
		measurementRef: MeasurementModel[]
	): Observable<Recipe[]> {
		let spoonRecipes: ISpoonacularRecipeModel[] = [];
		const ingredientList: IExtendedIngredients[] = [];
		const ingredientListFull: Ingredient[] = [];
		return this.restIngredientService.getRandomSpoonacularRecipe(count).pipe(
			switchMap((recipeResults: IRawReturnedRecipes) => {
				console.log('a result', recipeResults);
				// TODO probably should check if the recipe exists already - I mean what are the chances right???
				// assign the recipeResults to a locally scoped variable - for use later in the pipe
				spoonRecipes = [...recipeResults.recipes];
				// forEach through Recipes and create array of unique ingredients
				spoonRecipes.forEach((recipe: ISpoonacularRecipeModel) => {
					recipe.extendedIngredients.forEach((ingredient: IExtendedIngredients) => {
						const isInList = ingredientList.some((ingList: IExtendedIngredients) => ingList.id === ingredient.id);
						if (!isInList) {
							ingredientList.push(ingredient);
						}
					});
				});
				// forEach through each ingredient and create an array that checks if ingredient exists
				const ingredientExistMap$: Observable<Ingredient>[] = ingredientList.map((ingredient: IExtendedIngredients) =>
					this.restIngredientService.getIngredientByOtherId(ingredient.id, 'linkUrl')
				);
				return forkJoin(ingredientExistMap$);
			}),
			switchMap((existingIngredients: Ingredient[]) => {
				console.log('any existing ingredients?', existingIngredients);
				// if ingredient exists then add to array
				existingIngredients.forEach((exIng: Ingredient) => {
					if (!!exIng) {
						ingredientListFull.push(exIng);
					}
				});
				// if ingredient doesn't exist then attempt to create it...
				const ingredientMap$: Observable<Ingredient>[] = [];
				ingredientList.forEach((listItem: IExtendedIngredients) => {
					const isInList = ingredientListFull.some((ingredient: Ingredient) => ingredient.linkUrl === listItem.id);
					if (!isInList) {
						ingredientMap$.push(this.createIngredient(listItem, refDataAll, measurementRef));
					}
				});
				return forkJoin(ingredientMap$);
			}),
			switchMap((allIngredients: Ingredient[]) => {
				ingredientListFull.push(...allIngredients);
				console.log('this should be the ingredients created plus existing...', ingredientListFull);
				const mappedRecipes$: Observable<Recipe>[] = spoonRecipes.map((recipe: ISpoonacularRecipeModel) =>
					this.restRecipeService.createRecipe(this.recipeMapping(recipe, ingredientListFull, userId, refDataAll, measurementRef))
				);
				return forkJoin(mappedRecipes$);
			})
		);
	}
}
