import { Location } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ComponentBase } from '@components/base/base.component.base';
import { PagedResult } from '@models/common.model';
import { IRecipeFilterQuery, RecipeFilterQuery } from '@models/filter-queries.model';
import { Recipe } from '@models/recipe';
import { User } from '@models/user';
import { ToTitleCasePipe } from '@pipes/title-case.pipe';
import { DialogService } from '@services/dialog.service';
import { RestIngredientService } from '@services/rest-ingredient.service';
import { RestRecipeService } from '@services/rest-recipe.service';
import { StateService } from '@services/state.service';
import { UserProfileService } from '@services/user-profile.service';
import { Observable, of } from 'rxjs';
import { catchError, filter, switchMap, takeUntil, tap } from 'rxjs/operators';

@Component({
	selector: 'app-recipes',
	templateUrl: './recipes.component.html',
	styleUrls: ['./recipes.component.scss']
})
export class RecipesComponent extends ComponentBase implements OnInit {
	recipes: Recipe[] = [];
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
		private stateService: StateService
	) {
		super();
	}

	ngOnInit(): void {
		this.userProfileService.currentData.subscribe(profile => (this.cookBookUserProfile = profile));
		this.routeParamSubscribe();
		this.listenFilterQueryChanges();
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

	// todo temp - remove shortly
	getSpoonAcularRecipe(count: number) {
		this.restIngredientService.getRandomSpoonacularRecipe(count).subscribe(recipeResult => {
			console.log('a result', recipeResult);
			recipeResult.recipes.map(recipe => {
				const newRecipe: Recipe = {
					name: recipe.title,
					numberOfServings: recipe.servings,
					readyInMinutes: recipe.readyInMinutes,
					rawInstructions: recipe.instructions,
					recipeDishType: recipe.dishTypes,
					recipeCuisineType: recipe.cuisines,
					sourceOfRecipeName: recipe.sourceName,
					sourceOfRecipeLink: recipe.sourceUrl,
					spoonacularId: recipe.id,
					creditsText: recipe.creditsText,
					createByUserId: this.cookBookUserProfile.id,
					recipePicture: [
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
				recipe.extendedIngredients.forEach((ingredient, index) => {
					newRecipe.recipeIngredientLists.push({
						ingredientId: ingredient.id,
						ingredientName: this.toTitleCase.transform(ingredient.name),
						text: ingredient.originalName,
						preference: index,
						quantity: ingredient.measures.metric.amount,
						unit: ingredient.measures.metric.unitShort
					});
				});
				recipe.analyzedInstructions[0].steps.forEach(steep => {
					newRecipe.steppedInstructions.push({
						number: steep.number,
						step: steep.step,
						ingredients: [],
						equipment: []
					});
					steep.ingredients.forEach(item => {
						newRecipe.steppedInstructions[newRecipe.steppedInstructions.length - 1].ingredients.push(
							this.toTitleCase.transform(item.name)
						);
					});
					steep.equipment.forEach(item => {
						newRecipe.steppedInstructions[newRecipe.steppedInstructions.length - 1].equipment.push(
							this.toTitleCase.transform(item.name)
						);
						// check if the equipment has been added already to the equipment array
						if (newRecipe.equipmentRequired.indexOf(this.toTitleCase.transform(item.name)) === -1) {
							newRecipe.equipmentRequired.push(this.toTitleCase.transform(item.name));
						}
					});
				});
				const tagList = ['veryHealthy', 'cheap', 'veryPopular', 'sustainable'];
				const healthLabelList = ['vegetarian', 'vegan', 'glutenFree', 'dairyFree', 'lowFodmap', 'ketogenic', 'whole30'];
				tagList.map(tag => {
					if (recipe[tag] && recipe[tag] === true) {
						newRecipe.recipeDishTags.push(tag);
					}
				});
				healthLabelList.map(diet => {
					if (recipe[diet] && recipe[diet] === true) {
						newRecipe.recipeHealthLabels.push(diet);
					}
				});
				console.log('newRecipe to be written', newRecipe);
				this.restRecipeService.createRecipe(newRecipe).subscribe(returnedRecipe => {
					console.log('New Recipe has been written', returnedRecipe);
				});
			});
		});
	}
}
