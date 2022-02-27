import { ApiLinks } from './apiLinks';
import { History } from './history';
import { IngredientList } from './ingredient-list.model';
import { Picture } from './picture';
import { RatingReviews } from './ratingsReview';
import { RecipeCreatedByUser } from './recipeCreatedByUser';
import { ReferenceItemFull } from './reference.model';
import { StepByStepInstructions } from './stepByStepInstructions';

export interface Recipe {
  id?: number;
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
  numberOfServings?: number;
  /**
   * calculated field from average prices
   */
  priceEstimate?: number;
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
   * calculated field of price / number of servings
   */
  priceServing?: number;
  /**
   * string can be very long it appears
   */
  rawInstructions?: string;
  license?: string;
  createByUserId?: number;
  /**
   * eg CWA Cookbook 2015 or student/teacher/import created or website url
   */
  sourceOfRecipeName?: string;
  sourceOfRecipeLink?: string;
  spoonacularId?: number;
  creditsText?: string;
  numberStars?: number;
  numberReviews?: number;
  numberFavourites?: number;
  numberOfTimesCooked?: number;

  equipmentRequired?: Array<ReferenceItemFull>;

  allergyWarnings?: Array<ReferenceItemFull>;
  /**
   * mexican, chinese, european, tudor, etc
   */
  recipeCuisineTypes?: Array<ReferenceItemFull>;

  /** Very healthy, cheap, popular, sustainable, etc */
  recipeDishTags?: Array<ReferenceItemFull>;
  /**
   * more than one type possible - breakfast, lunch, dinner snack, sauce, base
   */
  recipeDishTypes?: Array<ReferenceItemFull>;
  /**
   * low sugar, paleo, sugar free
   */
  recipeHealthLabels?: Array<ReferenceItemFull>;
  /** analysed Instructions broken down to steps */
  steppedInstructions?: Array<StepByStepInstructions>;
  recipeIngredientLists?: Array<IngredientList>;
  recipePictures?: Array<Picture>;
  recipeReviews?: Array<RatingReviews>;

  createdByUser?: RecipeCreatedByUser;

  /**
   * all the events that occur for the recipe - ie created, edited, booked etc
   */
  history?: Array<History>;
  links?: ApiLinks;
  updatedAt?: string | Date;
  createdAt?: string | Date;
  rowVer?: string;
}
