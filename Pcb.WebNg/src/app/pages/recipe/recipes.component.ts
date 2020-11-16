import { Component, OnInit } from '@angular/core';
import { Location } from '@angular/common';
import { ActivatedRoute } from '@angular/router';
import { Store, select } from '@ngrx/store';
import { Observable, of } from 'rxjs';
import { filter, takeUntil, catchError, tap, switchMap } from 'rxjs/operators';

import { Recipe, Recipes } from '@models/recipe';
import { RecipeRestService} from '@services/recipe-rest.service';
import { RestService} from '@services/rest-service.service';
import { FilterQuery } from '@models/filterQuery';
import * as fromStore from '@store/reducers';
import * as filterPayloadActions from '../../store/action/filter-payload.actions';
import { ComponentBase } from '@components/base/base.component.base';
import { User } from '@models/user';
import { UserProfileService } from '@services/user-profile.service';
import { ToTitleCasePipe } from '@pipes/title-case.pipe';
import { MessageService } from '@services/message.service';
import { MessageStatus } from '@models/message.models';
import { DialogService } from '@services/dialog.service';


@Component({
  selector: 'app-recipes',
  templateUrl: './recipes.component.html',
  styleUrls: ['./recipes.component.scss']
})
export class RecipesComponent extends ComponentBase implements OnInit {
	recipes: Recipe[] = [];
	isLoading = true;
	selectedRecipe: Recipe;
	selectedIndex = 0;
	selectedTab = 0; // controls the selectedIndex of the mat-tab-group
	isNew = true; // edit or new ingredient;

	currentPath: string;
	filterQuery: FilterQuery;
	dataLength: number;
	ngrxFilterQuery$: Observable<any>;
	cookBookUserProfile: User;

	constructor(
			private recipeRestService: RecipeRestService,
			private route: ActivatedRoute,
			private restService: RestService,
			private location: Location,
			private store: Store<fromStore.State>,
			private userProfileService: UserProfileService,
			private toTitleCase: ToTitleCasePipe,
			private messageService: MessageService,
			private dialogService: DialogService
		) { super(); }

	ngOnInit(): void {
		this.userProfileService.currentData.subscribe(profile => this.cookBookUserProfile = profile);
		this.routeParamSubscribe();
		this.store.pipe(
			select(fromStore.getFilterQuery),
			filter(val => val !== undefined),
			tap((filterQ: FilterQuery) => {
				this.filterQuery = { ...filterQ};
				console.log('hopefully this does not loop', this.filterQuery);
			}),
			switchMap(() => this.getRecipes()),
			takeUntil(this.ngUnsubscribe)
		).subscribe();
	}
	showToast() {
		this.messageService.add({
			severity: MessageStatus.Information,
			summary: 'Authentication Failed',
			detail: 'API Key or URL is invalid.',
			life: 12000
		});
	}
	// paused at the moment till the filtering is sorted
	routeParamSubscribe(): void {
		this.route.params.pipe(
			tap(params => {
				this.currentPath = this.route.snapshot.routeConfig.path;
				if (params.recipeId) {
					this.loadRecipeSelect(params.recipeId);
				}
			}),
			takeUntil(this.ngUnsubscribe)
		).subscribe();
	}

	loadRecipeSelect(itemId: string) {
		this.recipeRestService.getRecipeById(itemId).pipe(
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
			takeUntil(this.ngUnsubscribe),
		).subscribe();
	}

	changeRecipe(event: {direction: string, id: string}) {
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
		this.location.replaceState(`savoury/recipes/item/${this.selectedRecipe._id}`);
	}

	onFilterChange(ev: FilterQuery) {
		console.log('here is the filter change', ev);
		this.store.dispatch({type: filterPayloadActions.FilterPayloadActionTypes.SetFilterPayLoad, payload: ev});
	}

	getRecipes(): Observable<Recipes> {
		this.isLoading = true;
		return this.recipeRestService.getRecipe(this.filterQuery).pipe(
			catchError(err => {
				this.dialogService.alert('Error getting recipes', err);
				this.dataLength = 0;
				return of({items: [], total: 0});
			}),
			tap(() => this.isLoading = false),
			filter(result => result.total > 0),
			tap((recipeResults: Recipes) => {
				this.dataLength = recipeResults.total;
				this.recipes = recipeResults.items;
			}),
			takeUntil(this.ngUnsubscribe),
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
			this.location.replaceState(`savoury/recipes/item/${this.selectedRecipe._id}`);
		}
	}

	// todo temp - remove shortly
	getSpoonAcularRecipe() {
		this.restService.getRandomSpoonacularRecipe()
		.subscribe(recipeResult => {
			console.log('a result', recipeResult);
			recipeResult.recipes.map(recipe => {
			const newRecipe: Recipe = {
				name: recipe.title,
				numberOfServings: recipe.servings,
				readyInMinutes: recipe.readyInMinutes,
				instructions: recipe.instructions,
				recipeType: recipe.dishTypes,
				cuisineType: recipe.cuisines,
				sourceOfRecipe: recipe.sourceUrl,
				creditsText: recipe.creditsText,
				picture: [{
				title: recipe.title,
				fileLink: recipe.image,
				positionPic: 'left'
				}],
				ingredientLists: [],
				steppedInstructions: [],
				equipmentRequired: [],
				tags: [],
				healthLabels: []
			};
			recipe.extendedIngredients.forEach((ingredient, index) => {
				newRecipe.ingredientLists.push({
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
				newRecipe.steppedInstructions[newRecipe.steppedInstructions.length - 1]
				.ingredients.push(this.toTitleCase.transform(item.name));
				});
				steep.equipment.forEach(item => {
				newRecipe.steppedInstructions[newRecipe.steppedInstructions.length - 1]
				.equipment.push(this.toTitleCase.transform(item.name));
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
				newRecipe.tags.push(tag);
				}
			});
			healthLabelList.map(diet => {
				if (recipe[diet] && recipe[diet] === true) {
				newRecipe.healthLabels.push(diet);
				}
			});
			console.log('newRecipe to be written', newRecipe);
			this.recipeRestService.createRecipe(newRecipe)
				.subscribe(returnedRecipe => {
				console.log('New Recipe has been written', returnedRecipe);
				});
			});
		});
	}

}
