import { Location } from '@angular/common';
import { HttpErrorResponse } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { IngredientFilterObject, ISortPageObj, PagedResult, SortPageObj } from '@models/common.model';
import { Ingredient } from '@models/ingredient';
import { MeasurementModel } from '@models/ingredient-model';
import { MessageStatus } from '@models/message.models';
import { ReferenceAll } from '@models/reference.model';
import { User } from '@models/user';
import { DialogService } from '@services/dialog.service';
import { RecipeRestService } from '@services/recipe-rest.service';
import { ReferenceService } from '@services/reference.service';
// import {ConversionModel, EditedFieldModel, IngredientModel, PriceModel} from '../models/ingredient-model';
import { RestService } from '@services/rest-service.service';
import { UserProfileService } from '@services/user-profile.service';
import { combineLatest, Observable, of } from 'rxjs';
import { catchError, first, switchMap, takeUntil, tap } from 'rxjs/operators';
import { ComponentBase } from '../../components/base/base.component.base';


export class EditedFieldModel {
  key: string;
  value: any;
  changeType: string;
  subDocName?: string;
  subId?: string;
}

@Component({
	selector: 'app-ingredients',
	templateUrl: './ingredients.component.html',
	styleUrls: ['./ingredients.component.scss']
})
export class IngredientsComponent extends ComponentBase implements OnInit {
	selectedIngredient$: Observable<Ingredient>;
	selectedTab = 0; // controls the selectedIndex of the mat-tab-group
	isNew = true; // edit or new ingredient;
	cookBookUserProfile$: Observable<User>;
	currentPath: string;
	filterObject: IngredientFilterObject = {
		name: '',
		type: [],
		parent: '',
		allergies: [],
		purchasedBy: ''
	};
	sortPageObj = new SortPageObj();
	data$: Observable<PagedResult<Ingredient>>;
	isLoading: boolean;
	refData: ReferenceAll;
	measurements: MeasurementModel[];

	constructor(
		private restService: RestService,
		private recipeRestService: RecipeRestService,
		private dialogService: DialogService,
		private userProfileService: UserProfileService,
		private location: Location,
		private route: ActivatedRoute,
		private referenceService: ReferenceService
	) { super(); }

	ngOnInit() {
		this.routeParamSubscribe();
		this.cookBookUserProfile$ = this.userProfileService.currentData.pipe(
			takeUntil(this.ngUnsubscribe)
		);
	}

	// async subscription to data$ in the template
	routeParamSubscribe(): void {
		this.data$ = combineLatest([
				this.referenceService.getAllReferences(),
				this.referenceService.getMeasurements()
			]).pipe(
			catchError((err: HttpErrorResponse) => this.dialogService.alert('Http error while attempting to getting references', err)),
			switchMap(([refData, measurements]: [ReferenceAll, MeasurementModel[]]) => {
					this.refData = refData;
					this.measurements = measurements;
					console.log('we have the ref data', refData, measurements);
					return this.route.params;
				}),
			switchMap(params => {
				this.currentPath = this.route.snapshot.routeConfig.path;
				if (params.ingredientId) {
					console.log('Attempting to get single ingredient', params.ingredientId)
					this.selectedIngredient$ = this.getSingleIngredient(params.ingredientId);
				}
				return this.getIngredientList();
			}),
			takeUntil(this.ngUnsubscribe)
		);
	}

	getSingleIngredient(itemId: number): Observable<Ingredient> {
		this.isNew = false;
		console.log('start of the method get single ingredient');
		return this.restService.getIngredientById(itemId).pipe(
			tap((test) => {
				this.selectedTab = 1;
				console.log('setting the tab to 1', test);
			}),
			catchError(err => {
				this.dialogService.confirm(MessageStatus.Critical, 'Error getting ingredient', err);
				return of({} as Ingredient);
			}),
			takeUntil(this.ngUnsubscribe),
		);
	  }

	// load all the ingredients
	// todo add a filter and pagination and only load 50 at a time
	getIngredientList(): Observable<PagedResult<Ingredient>> {
		return this.restService.getIngredient(this.sortPageObj, this.filterObject).pipe(
			catchError(err => {
				this.dialogService.confirm(MessageStatus.Critical, 'Error getting ingredients', err);
				return of({ items: [], totalCount: 0 });
			}),
			takeUntil(this.ngUnsubscribe),
		);
	}

	sortPageChange(pageEvent: ISortPageObj) {
		console.log('there was a sortPage Change heard in ingredients', pageEvent);
		this.sortPageObj = {...pageEvent};
		this.data$ = this.getIngredientList();
	}


	changeTab(event: any) {
		this.selectedTab = event;
		if (this.selectedTab === 0) {
			this.selectedIngredient$ = null;
			this.location.replaceState('/savoury/ingredients');
		}
	}

	onFilterChanged(search: IngredientFilterObject): void {
		console.log('ingredient filter changed', search);
		this.sortPageObj.pageIndex = 0;
		this.filterObject = search;
		this.data$ = this.getIngredientList();
	}

	createOrEdit(editOrNew: string, row?: Ingredient) {
		console.log('CreateOrEdit', editOrNew, row);
		this.isNew = (editOrNew === 'new');
		if (this.isNew) {
			this.dialogService.newIngredientDialog(this.refData.IngredientFoodGroup, this.measurements, this.refData.IngredientState).pipe(
				first(),
				switchMap((result: Ingredient) => {
					console.log('result form dialog', result);
					return this.restService.createIngredient(result);
				}),
				tap((savedResult: Ingredient) => {
					this.isNew = false; // ingredient is no longer "new"
					this.selectedIngredient$ = of(savedResult);
					this.changeTab(1);
				}),
			).subscribe();
			return;
		}
		this.location.replaceState(`/savoury/ingredients/item/${row.id}`);
		this.selectedIngredient$ = this.getSingleIngredient(row.id);
	}
	filterInt(value: string): boolean {
		if (/^[-+]?(\d+|Infinity)$/.test(value)) {
			return true;
		} else {
			return false;
		}
	}
	toTitleCase(phrase: string): string {
		return phrase
			.toLowerCase()
			.split(' ')
			.map(word => word.charAt(0).toUpperCase() + word.slice(1))
			.join(' ');
	}
	// createNewIngredient(result: any): Ingredient {
	// 	const newIngredient: Ingredient = {
	// 		name: this.toTitleCase(result.name),
	// 		// parent: result.aisle,
	// 		// consistency: result.consistency,
	// 		nutrition: [],
	// 		caloricBreakdown: {
	// 		percentProtein: result.nutrition.caloricBreakdown.percentProtein,
	// 		percentFat: result.nutrition.caloricBreakdown.percentFat,
	// 		percentCarbs: result.nutrition.caloricBreakdown.percentCarbs,
	// 		}
	// 	};
	// 	result.nutrition.nutrients.map(item => {
	// 		newIngredient.nutrition.push({
	// 		title: item.title,
	// 		amount: item.amount,
	// 		unit: item.unit,
	// 		percentOfDailyNeeds: item.percentOfDailyNeeds
	// 		});
	// 	});
	// 	return newIngredient;
	// }
//   async getIngredients(recipes) {
	// async await with promises -
	// https://medium.com/@antonioval/making-array-iteration-easy-when-using-async-await-6315c3225838
	// map through the recipes
//    const pArray = recipes.map(async recipe => {
// 		// map through the ingredientLists within the recipe
// 		const ingredArray = recipe.ingredientLists.map(async ingred => {
// 		// if the ingredientID contains only numbers - and if the name does not exist
// 		const checkForIngredient = this.data.items.filter(item => item.name.toLowerCase() === ingred.ingredientName.toLowerCase());
// 		console.log('ingred', ingred.ingredientId);
// 		if (this.filterInt(ingred.ingredientId.toString()) && checkForIngredient.length === 0) {
// 			// fetch ingredients from spoonacular
// 			return await this.restService.getSpoonacularIngredient(ingred.ingredientId)
// 			.subscribe(async result => {
// 			console.log('ingredient result', result);
// 			// chart out the newIngredient
// 			const newIngredient: Ingredient = this.createNewIngredient(result);
// 			// with each return create the ingredient in CookBook and add to the current ingredientList
// 			console.log('newIngredient to be written', newIngredient);
// 			return await this.restService.createIngredient(newIngredient)
// 				.subscribe(async returnedIngredient => {
// 				return await this.recipeRestService
// 				.updateSubRecipe(recipe._id, 'ingredientLists', ingred._id, {ingredientID: returnedIngredient._id})
// 					.subscribe(updatedIngredientList => {
// 					console.log('updated the associated ingredient', updatedIngredientList);
// 					this.data.items.push(updatedIngredientList);
// 					});
// 				});
// 			});
// 		} else {
// 			return null;
// 		}
// 		});
// 		const response = await Promise.all(ingredArray);
// 		console.log('response complete?', response);
// 		return response;
//    });
//    const users = await Promise.all(pArray);
//    console.log('users complete?', users);
//    return users;
//  }
//  async cleanIngredients(recipe: Recipe) {
// 	// map through the ingredientLists within the recipe
// 	const pArray = recipe.ingredientLists.map(async ingred => {
// 		// ingred .ingredientId (needs updating) .ingredientName (if matches loaded this.ingredients.name)
// 		// using the ingred._id and recipe._id to save
// 		const matchingIngredient = this.data.items.filter(item => item.name.toLowerCase() === ingred.ingredientName.toLowerCase());
// 		if (matchingIngredient && matchingIngredient.length > 0 && matchingIngredient[0]._id !== ingred._id) {
// 		console.log('we got a match', recipe.name, matchingIngredient[0]._id, ingred.ingredientName);
// 		return await this.recipeRestService
// 		.updateSubRecipe(recipe._id, 'ingredientLists', ingred._id, {ingredientId: matchingIngredient[0]._id})
// 		.subscribe(updatedIngredientListItem => {
// 				return updatedIngredientListItem;
// 			});
// 		} else {
// 		console.log('no match, returning null');
// 		return null;
// 		}
// 	});
// 	const users = await Promise.all(pArray);
// 	console.log('users complete?', users);
// 	return users;
//  }
  getRecipeList() {
	// load all the recipe ingredients only select ingredientLists
	this.recipeRestService.getRecipe(null)
		.subscribe(recipes => {
		console.log('recipes returned ', recipes, recipes);
		// this.getIngredients(recipes);
		});
  }
//   cleanRecipeIngredients() {
// 	this.recipeRestService.getRecipe(null)
// 	.subscribe(recipes => {
// 		console.log('recipes returned ', recipes);
// 		const pArray = recipes.items.map(recipe => {
// 		console.log('recipe name ', recipe.name);
// 		this.cleanIngredients(recipe);
// 		});
// 	});
//   }

//   showList(ev: number) {
// 	  this.showItem = ev;
// 	  this.selectedRecipe = null;
//   }

}
