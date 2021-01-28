import { Location } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ComponentBase } from '@components/base/base.component.base';
import { PagedResult } from '@models/common.model';
import { IRecipeFilterQuery, RecipeFilterQuery } from '@models/filter-queries.model';
import { Ingredient } from '@models/ingredient';
import { IngredientList } from '@models/ingredient-list.model';
import { MeasurementModel } from '@models/ingredient-model';
import { ISpoonConversion, ISpoonFoodRaw } from '@models/raw-food-ingredient.model';
import { Recipe } from '@models/recipe';
import { ReferenceAll, ReferenceItemFull } from '@models/reference.model';
import { IEquipmentIngredient, IExtendedIngredients, IRawReturnedRecipes, ISpoonacularRecipeModel } from '@models/spoonacular-recipe.model';
import { User } from '@models/user';
import { ToTitleCasePipe } from '@pipes/title-case.pipe';
import { DialogService } from '@services/dialog.service';
import { IngredientConstructService } from '@services/ingredient-construct.service';
import { RefDataService } from '@services/ref-data.service';
import { RestIngredientService } from '@services/rest-ingredient.service';
import { RestRecipeService } from '@services/rest-recipe.service';
import { StateService } from '@services/state.service';
import { UserProfileService } from '@services/user-profile.service';
import { combineLatest, forkJoin, Observable, of } from 'rxjs';
import { catchError, filter, first, switchMap, takeUntil, tap } from 'rxjs/operators';

@Component({
	selector: 'app-recipes',
	templateUrl: './recipes.component.html',
	styleUrls: ['./recipes.component.scss']
})
export class RecipesComponent extends ComponentBase implements OnInit {
	recipes: Recipe[] = [];
	refDataAll: ReferenceAll;
	measurementRef: MeasurementModel[];
	isLoading = false;
	selectedRecipe: Recipe;
	selectedIndex = 0;
	selectedTab = 0; // controls the selectedIndex of the mat-tab-group
	isNew = true; // edit or new ingredient;

	currentPath: string;
	filterQuery: IRecipeFilterQuery;
	dataLength: number;
	cookBookUserProfile: User;

	constructor(
		private restRecipeService: RestRecipeService,
		private route: ActivatedRoute,
		private restIngredientService: RestIngredientService,
		private location: Location,
		private userProfileService: UserProfileService,
		private toTitleCase: ToTitleCasePipe,
		private dialogService: DialogService,
		private stateService: StateService,
		private ingredientConstructService: IngredientConstructService,
		private refDataService: RefDataService
	) {
		super();
	}

	ngOnInit(): void {
		this.userProfileService.currentData.subscribe(profile => (this.cookBookUserProfile = profile));
		this.routeParamSubscribe();
		this.listenFilterQueryChanges();
		this.getAllReferences();
	}

	listenFilterQueryChanges(): void {
		this.stateService
			.getRecipeFilterQuery()
			.pipe(
				switchMap((result: IRecipeFilterQuery) => {
					this.filterQuery = result;
					return this.getRecipes();
				}),
				takeUntil(this.ngUnsubscribe)
			)
			.subscribe();
	}
	// paused at the moment till the filtering is sorted
	routeParamSubscribe(): void {
		this.route.params
			.pipe(
				tap(params => {
					this.currentPath = this.route.snapshot.routeConfig.path;
					if (params.recipeId) {
						this.loadRecipeSelect(params.recipeId);
					}
				}),
				takeUntil(this.ngUnsubscribe)
			)
			.subscribe();
	}

	/** listens to refDataService to populate the referenceData, called from init, disposed off after first response */
	getAllReferences(): void {
		combineLatest([this.refDataService.getAllReferences(), this.refDataService.getMeasurements()])
			.pipe(
				first(),
				tap(([refAll, measure]: [ReferenceAll, MeasurementModel[]]) => {
					this.refDataAll = refAll;
					this.measurementRef = measure;
				})
			)
			.subscribe();
	}

	loadRecipeSelect(itemId: string) {
		this.restRecipeService
			.getRecipeById(itemId)
			.pipe(
				switchMap(singleRecipe => {
					this.selectedTab = 1;
					this.selectedRecipe = singleRecipe;
					console.log('the recipe', this.selectedRecipe);
					return this.getRecipes();
				}),
				catchError(err => {
					console.log('Error', err);
					return [];
				}),
				takeUntil(this.ngUnsubscribe)
			)
			.subscribe();
	}

	changeRecipe(event: { direction: string; id: string }) {
		if (this.selectedIndex === 0 && event.direction === 'prev') {
			this.selectedIndex = this.recipes.length - 1;
		} else if (this.selectedIndex === this.recipes.length - 1 && event.direction === 'next') {
			this.selectedIndex = 0;
		} else if (event.direction === 'prev') {
			this.selectedIndex--;
		} else {
			this.selectedIndex++;
		}
		this.selectedRecipe = this.recipes[this.selectedIndex];
		this.location.replaceState(`savoury/recipes/item/${this.selectedRecipe.id}`);
	}

	onFilterChange(ev: RecipeFilterQuery) {
		console.log('here is the filter change', ev);
	}

	getRecipes(): Observable<PagedResult<Recipe>> {
		this.isLoading = true;
		this.dataLength = 0;
		return this.restRecipeService.getRecipe(this.filterQuery).pipe(
			catchError(err => {
				this.dialogService.alert('Error getting recipes', err);
				return of({ items: [], totalCount: 0 });
			}),
			tap(() => {
				this.isLoading = false;
			}),
			filter((result: PagedResult<Recipe>) => result.totalCount > 0),
			tap((recipeResults: PagedResult<Recipe>) => {
				this.dataLength = recipeResults.totalCount;
				this.recipes = recipeResults.items;
			})
		);
	}

	createOrEdit(action: string) {
		console.log('new maybe', action);
	}

	selectThisRecipe(recipe: Recipe, i: number) {
		// set the selectedRecipe and the selectedIndex
		this.selectedRecipe = recipe;
		this.selectedIndex = i;
		// change the tab to the recipe
		this.changeTab(1);
	}

	changeTab(event: any) {
		this.selectedTab = event;
		if (this.selectedTab === 0) {
			this.selectedRecipe = null;
			this.location.replaceState('savoury/recipes/browse');
		} else {
			this.location.replaceState(`savoury/recipes/item/${this.selectedRecipe.id}`);
		}
	}

	createIngredient(spoonIngredient: IExtendedIngredients): Observable<Ingredient> {
		let newIngredient: Ingredient;
		let spoon: ISpoonFoodRaw;
		return this.restIngredientService.getSpoonacularIngredient(spoonIngredient.id).pipe(
			switchMap((spoonRaw: ISpoonFoodRaw) => {
				spoon = spoonRaw;
				const unitFrom = spoonRaw.possibleUnits.includes('cup') ? 'cup' : 'piece';
				return this.restIngredientService.getSpoonConversion(spoonRaw.name, unitFrom, 1, 'grams');
			}),
			switchMap((spoonConversions: ISpoonConversion) => {
				const foodGroupItem = this.refDataAll.IngredientFoodGroup.find(
					(fg: ReferenceItemFull) => spoon.aisle.indexOf(fg.altTitle) > 0
				);
				let foodGroup: number = this.refDataAll.IngredientFoodGroup.find((fg: ReferenceItemFull) => fg.title === 'NULL').id;
				if (!!foodGroupItem) {
					foodGroup = foodGroupItem.id;
				}
				newIngredient = this.ingredientConstructService.createNewIngredient(
					{ name: this.toTitleCase.transform(spoon.name), foodGroup },
					spoon,
					[spoonConversions],
					this.refDataAll.IngredientFoodGroup,
					this.refDataAll.IngredientState,
					this.measurementRef
				);
				return this.restIngredientService.createIngredient(newIngredient);
			})
		);
	}

	recipeMapping(recipe: ISpoonacularRecipeModel, allIngredients: Ingredient[]): Recipe {
		const findIngredient = (spoonId: number): Ingredient => {
			return allIngredients.find((ing: Ingredient) => ing.linkUrl === spoonId);
		};
		const findReferenceItem = (title: string, refData: ReferenceItemFull[]): ReferenceItemFull => {
			return refData.find((item: ReferenceItemFull) => title.toLowerCase() === item.title.toLowerCase());
		};
		const newRecipe: Recipe = {
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
			createByUserId: this.cookBookUserProfile.id, // logged in user.
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
		recipe.extendedIngredients.forEach((ingredient: IExtendedIngredients, index: number) => {
			const ingredientId: number = findIngredient(ingredient.id).id;
			const wholeNumberRound = 10;
			const roundTwoPlaces = 100;
			if (ingredientId) {
				const quantity =
					ingredient.measures.metric.amount > wholeNumberRound
						? Math.round(ingredient.measures.metric.amount)
						: Math.round(ingredient.measures.metric.amount * roundTwoPlaces) / roundTwoPlaces;
				const newIngredientItem: IngredientList = {
					ingredientId,
					spoonacularId: ingredient.id,
					ingredientName: this.toTitleCase.transform(ingredient.name),
					text: ingredient.originalName,
					preference: index,
					quantity,
					measurementUnit: this.ingredientConstructService.findMeasureModel(
						ingredient.measures.metric.unitShort,
						this.measurementRef
					),
					ingredientState: findReferenceItem(ingredient.consistency, this.refDataAll.IngredientState)
				};
				newRecipe.recipeIngredientLists.push(newIngredientItem);
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
				const ingredientId: number = findIngredient(item.id)?.id;
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
		this.refDataAll.DishTag.forEach((tag: ReferenceItemFull) => {
			console.log(
				'there might be a dishTag ',
				tag.title,
				tag.altTitle,
				recipe[tag.altTitle],
				!!tag.altTitle && recipe[tag.altTitle] && recipe[tag.altTitle] === true
			);
			if (!!tag.altTitle && recipe[tag.altTitle] && recipe[tag.altTitle] === true) {
				console.log('this is a dishTag');
				newRecipe.recipeDishTags.push(tag);
			}
		});
		recipe.dishTypes.forEach((dish: string) => {
			const dishType = findReferenceItem(dish, this.refDataAll.DishType);
			if (!!dishType) {
				newRecipe.recipeDishTypes.push(dishType);
			} else {
				console.log('could not find this dish type', dish, this.refDataAll.DishType);
			}
		})
		recipe.cuisines.forEach((type: string) => {
			const cuisineType = findReferenceItem(type, this.refDataAll.CuisineType);
			if (!!cuisineType) {
				newRecipe.recipeCuisineTypes.push(cuisineType);
			} else {
				console.log('could not find this cuisine', type, this.refDataAll.CuisineType);
			}
		});
		this.refDataAll.HealthLabel.forEach((diet: ReferenceItemFull) => {
			if (!!diet.altTitle && recipe[diet.altTitle] && recipe[diet.altTitle] === true) {
				newRecipe.recipeHealthLabels.push(diet);
			}
		});
		console.log('newRecipe to be written', newRecipe);
		return newRecipe;
	}
	getSpoonAcularRecipe(count: number) {
		let spoonRecipes: ISpoonacularRecipeModel[] = [];
		const ingredientList: IExtendedIngredients[] = [];
		const ingredientListFull: Ingredient[] = [];
		this.restIngredientService
			.getRandomSpoonacularRecipe(count)
			.pipe(
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
					// TODO add a match ingredient to USDA method to ingredients page
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
							ingredientMap$.push(this.createIngredient(listItem));
						}
					});
					return forkJoin(ingredientMap$);
				}),
				switchMap((allIngredients: Ingredient[]) => {
					ingredientListFull.push(...allIngredients);
					console.log('this should be the ingredients created plus existing...', ingredientListFull);
					const mappedRecipes$: Observable<Recipe>[] = spoonRecipes.map((recipe: ISpoonacularRecipeModel) =>
						this.restRecipeService.createRecipe(this.recipeMapping(recipe, ingredientListFull))
					);
					return forkJoin(mappedRecipes$);
				}),
				tap((results: Recipe[]) => {
					console.log('finally got to the end', results);
				})
			)
			.subscribe();
	}
}
