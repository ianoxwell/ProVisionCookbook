/**
 * Provisioners CookBook Api
 * This is the API for the Provisioner's CookBook Project
 *
 * OpenAPI spec version: 1.0.0-oas3
 * Contact: ianoxwell@gmail.com
 *
 * NOTE: This class is auto generated by the swagger code generator program.
 * https://github.com/swagger-api/swagger-codegen.git
 * Do not edit the class manually.
 */
import { ApiLinks } from './apiLinks';
// import { SteppedInstructions } from './stepped-instructions';
import { History } from './history';
import { IngredientList } from './ingredientList';
import { Picture } from './picture';
import { RecipeCreatedByUser } from './recipeCreatedByUser';
import { StepByStepInstructions } from './stepByStepInstructions';
import { RatingReviews } from './ratingsReview';


export interface Recipe {
	_id?: string;
	/**
	 * unique name of the recipe
	 */
	name: string;
	/**
	 * short text description
	 */
	teaser?: string;
	/**
	 * Number of people or servings the recipe will make
	 */
	numberOfServings: number;
	/**
	 * calculated field from average prices
	 */
	priceEstimate?: number;
	/**
	 * calculated field of price / number of servings
	 */
	priceServing?: number;
	ingredientLists?: Array<IngredientList>;
	equipmentRequired?: Array<string>;
	/**
	 * amount of time in minutes to prepare everything estimate
	 */
	prepTime?: number;
	/**
	 * amount of time in minutes to cook the recipe
	 */
	cookTime?: number;
	/**
	 * amount of time in minutes to cook the recipe
	 */
	readyInMinutes?: number;
	/**
	 * string can be very long it appears
	 */
	instructions: string;
	steppedInstructions?: Array<StepByStepInstructions>;
	/**
	 * more than one type possible - breakfast, lunch, dinner snack, sauce, base
	 */
	recipeType?: Array<string>;
	tags?: Array<string>;
	/**
	 * low sugar, paleo, sugar free
	 */
	healthLabels?: Array<string>;
	/**
	 * mexican, chinese, european, tudor, etc
	 */
	cuisineType?: Array<string>;
	allergyWarnings?: Array<string>;
	createdByUser?: RecipeCreatedByUser;
	/**
	 * eg CWA Cookbook 2015 or student/teacher/import created or website url
	 */
	sourceOfRecipe?: string;
	creditsText?: string;
	numberStars?: number;
	numberReviews?: number;
	numberFavourites?: number;
	numberOfTimesCooked?: number;
	picture?: Array<Picture>;
	/**
	 * all the events that occur for the recipe - ie created, edited, booked etc
	 */
	history?: Array<History>;
	ratings?: Array<RatingReviews>;
	links?: ApiLinks;
	updatedAt?: string | Date;
	createdAt?: string | Date;
	__v?: number; // mongodb equivalent of rowVer
}

export interface Recipes {
	items: Recipe[];
	total: number;
}