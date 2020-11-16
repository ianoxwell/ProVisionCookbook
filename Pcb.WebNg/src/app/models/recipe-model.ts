export class IngredientListModel {
  // tslint:disable-next-line:variable-name
  _id?: string;
  ingredientId: string;
  ingredientName: string;
  quantity: number; // if stored as 0.5, 0.75 convert to symbol / fraction when displaying - 0.66 = 1/3
  measure: string; // pinch, cup, kg, grams etc
  state: string; // each or whole, sliced, shredded, blank
  allergies: string[];
  preference: number;
}
export class PictureModel {
  fileId: string; // if using GridFS - optional field
  title: string; // if none provided - use the recipe name - to populate the alt text of an <img
  fileLink: string; // pure URL location or file_id string if using GridFS
  positionPic: string;
}
export class HistoryModel {
  // tslint:disable-next-line:variable-name
  _id?: string;
  eventDate: Date;
  event: string; // event that occurred edit, booked, favoured, created
  changeKey: string; // used in an update
  changeFrom: string; // used in an update
  changeTo: string; // used in an update
  userName: string; // polite name of user
}

export class RecipeModel {
  // tslint:disable-next-line:variable-name
  _id?: string;
  name: string; // **
  numberOfServings: number;
  priceEstimate: number; // calculated field
  ingredientLists: IngredientListModel[];
  equipmentRequired: string[]; // pan, ladle, whisk
  method: string; // string can be very long it appears **
  recipeType: string[]; // more than one type possible - breakfast, lunch, dinner snack, sauce, base
  tags: string[]; // low sugar, paleo, sugar free
  createdByUser: {
	userID: string; // used to search through with a name change; also search for user profile on click then navigateTo
	userName: string;
  };
  createdOn: Date;
  modifiedOn: Date;
  sourceOfRecipe: string; // eg CWA Cookbook 2015 or student/teacher/import created
  picture: PictureModel;
  history: HistoryModel[];
}
