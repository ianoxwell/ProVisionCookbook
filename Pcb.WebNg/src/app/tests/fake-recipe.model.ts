import { Recipes, Recipe } from '@models/recipe';



export const fakeRecipe1: Recipe =  {
	'numberOfServings': 8,
	'priceEstimate': 0,
	'priceServing': 0,
	'equipmentRequired': [
	  'Sauce Pan',
	  'Blender'
	],
	'recipeType': [
	  'side dish'
	],
	'tags': [],
	'healthLabels': [
	  'vegetarian',
	  'vegan',
	  'glutenFree',
	  'dairyFree',
	  'lowFodmap'
	],
	'cuisineType': [],
	'allergyWarnings': [],
	'numberStars': 0,
	'numberReviews': 0,
	'numberFavourites': 0,
	'numberOfTimesCooked': 0,
	'_id': '5dec9de878c3c100170e3072',
	'name': 'Fresh Strawberry Lemonade',
	'readyInMinutes': 10,
	// tslint:disable-next-line: max-line-length
	'instructions': 'Add  cup sugar and 1 cup water in a small saucepan.\nHeat over medium high heat until sugar is dissolved. Stir occasionally.\nBlend strawberries in a blender with 2 cups of water.\nPour into a large pitcher. Add lemon juice to pitcher.\nAdd 1 cup of water and simple syrup.\nStir to blend.',
	'sourceOfRecipe': 'https://pickfreshfoods.com/fresh-strawberry-lemonade/',
	'creditsText': 'Pick Fresh Foods',
	'picture': [
	  {
		'_id': '5dec9de878c3c100170e3073',
		'title': 'Fresh Strawberry Lemonade',
		'fileLink': 'https://spoonacular.com/recipeImages/1005366-556x370.jpg',
		'positionPic': 'left'
	  }
	],
	'ingredientLists': [
	  {
		'allergies': [],
		'preference': 0,
		'_id': '5dec9de878c3c100170e3078',
		'ingredientId': '5ded8f6aa816a60017606de5',
		'ingredientName': 'Lemon Juice',
		'text': 'fresh lemon juice',
		'quantity': 157.725,
		'unit': 'ml'
	  },
	  {
		'allergies': [],
		'preference': 1,
		'_id': '5dec9de878c3c100170e3077',
		'ingredientId': '5ded8f6aa816a60017606d7f',
		'ingredientName': 'Strawberries',
		'text': 'fresh strawberries',
		'quantity': 453.592,
		'unit': 'g'
	  },
	  {
		'allergies': [],
		'preference': 2,
		'_id': '5dec9de878c3c100170e3076',
		'ingredientId': '5ded8f6aa816a60017606db6',
		'ingredientName': 'Sugar',
		'text': 'sugar',
		'quantity': 78.863,
		'unit': 'ml'
	  },
	  {
		'allergies': [],
		'preference': 3,
		'_id': '5dec9de878c3c100170e3075',
		'ingredientId': '14412',
		'ingredientName': 'Water',
		'text': 'water',
		'quantity': 236.588,
		'unit': 'ml'
	  },
	  {
		'allergies': [],
		'preference': 4,
		'_id': '5dec9de878c3c100170e3074',
		'ingredientId': '14412',
		'ingredientName': 'Water',
		'text': 'water',
		'quantity': 709.764,
		'unit': 'ml'
	  }
	],
	'steppedInstructions': [
	  {
		'ingredients': [
		  'Sugar',
		  'Water'
		],
		'equipment': [
		  'Sauce Pan'
		],
		'_id': '5dec9de878c3c100170e307f',
		'number': 1,
		'step': 'Add  cup sugar and 1 cup water in a small saucepan.'
	  },
	  {
		'ingredients': [
		  'Sugar'
		],
		'equipment': [],
		'_id': '5dec9de878c3c100170e307e',
		'number': 2,
		'step': 'Heat over medium high heat until sugar is dissolved. Stir occasionally.'
	  },
	  {
		'ingredients': [
		  'Strawberries',
		  'Water'
		],
		'equipment': [
		  'Blender'
		],
		'_id': '5dec9de878c3c100170e307d',
		'number': 3,
		'step': 'Blend strawberries in a blender with 2 cups of water.'
	  },
	  {
		'ingredients': [],
		'equipment': [],
		'_id': '5dec9de878c3c100170e307c',
		'number': 4,
		'step': 'Pour into a large pitcher.'
	  },
	  {
		'ingredients': [
		  'Lemon Juice'
		],
		'equipment': [],
		'_id': '5dec9de878c3c100170e307b',
		'number': 5,
		'step': 'Add lemon juice to pitcher.'
	  },
	  {
		'ingredients': [
		  'Water'
		],
		'equipment': [],
		'_id': '5dec9de878c3c100170e307a',
		'number': 6,
		'step': 'Add 1 cup of water and simple syrup.'
	  },
	  {
		'ingredients': [],
		'equipment': [],
		'_id': '5dec9de878c3c100170e3079',
		'number': 7,
		'step': 'Stir to blend.'
	  }
	],
	'history': [],
	'createdAt': '2019-12-08T06:53:28.495Z',
	'updatedAt': '2019-12-09T05:36:06.938Z',
	'__v': 0,
	'ratings': []
  };

export const fakeRecipe2: Recipe = {
	'numberOfServings': 22,
	'priceEstimate': 0,
	'priceServing': 0,
	'equipmentRequired': [
	  'Spatula',
	  'Bowl',
	  'Oven',
	  'Palette Knife',
	  'Oven'
	],
	'recipeType': [
	  'antipasti',
	  'starter',
	  'snack',
	  'appetizer',
	  'antipasto',
	  'hor d\'oeuvre'
	],
	'tags': [],
	'healthLabels': [],
	'cuisineType': [],
	'allergyWarnings': [],
	'numberStars': 0,
	'numberReviews': 0,
	'numberFavourites': 0,
	'numberOfTimesCooked': 0,
	'_id': '5dec9de878c3c100170e3080',
	'name': 'Almond Cookie Bar',
	'readyInMinutes': 45,
	// tslint:disable-next-line: max-line-length
	'instructions': '<ol><li>Beat butter and sugar until light and fluffy.</li><li>In a bowl combine wholemeal flour and plain flour together, then mix in the butter mixture with a rubber spatula and knead gently to a soft dough.</li><li>Turn out the dough on to a flour surface or line with a plastic sheet below and with another plastic sheet on top. Then roll to a square. Chill for at least 1 hour.</li><li>Transfer the dough on a non grease paper and cover with a plastic sheet on top, then roll to dough to about 3mm thick.</li><li>Prick the dough with a fork and bake for about 15-18 minutes until brown at preheated oven 180C and leave biscuit to cool.</li><li>Spread the apricot jam over the top of the biscuit, set aside.</li><li>Mix topping ingredients and spread evenly on the biscuit with a palette knife.</li><li>Bake for 15 minutes until golden.</li><li>Remove cooked biscuit from the oven and leave to cool completely, then cut into bars.</li></ol>',
	'sourceOfRecipe': 'http://www.foodista.com/recipe/F3QRLC6D/almond-cookie-bar',
	'creditsText': 'Foodista.com – The Cooking Encyclopedia Everyone Can Edit',
	'picture': [
	  {
		'_id': '5dec9de878c3c100170e3081',
		'title': 'Almond Cookie Bar',
		'fileLink': 'https://spoonacular.com/recipeImages/632116-556x370.jpg',
		'positionPic': 'left'
	  }
	],
	'ingredientLists': [
	  {
		'allergies': [],
		'preference': 0,
		'_id': '5dec9de878c3c100170e308a',
		'ingredientId': '5ded8f6aa816a60017606d65',
		'ingredientName': 'Almond',
		'text': 'Almond flakes',
		'quantity': 35,
		'unit': 'g'
	  },
	  {
		'allergies': [],
		'preference': 1,
		'_id': '5dec9de878c3c100170e3089',
		'ingredientId': '5ded8f6aa816a60017606d23',
		'ingredientName': 'Apricot Jam',
		'text': 'Apricot Gel/Jam, as needed',
		'quantity': 22,
		'unit': 'servings'
	  },
	  {
		'allergies': [],
		'preference': 2,
		'_id': '5dec9de878c3c100170e3088',
		'ingredientId': '5ded8f6aa816a60017606dc0',
		'ingredientName': 'Brown Sugar',
		'text': 'Brown sugar',
		'quantity': 25,
		'unit': 'g'
	  },
	  {
		'allergies': [],
		'preference': 3,
		'_id': '5dec9de878c3c100170e3087',
		'ingredientId': '5ded8f6aa816a60017606dd2',
		'ingredientName': 'Butter',
		'text': 'Cold butter, cut to cubes',
		'quantity': 50,
		'unit': 'g'
	  },
	  {
		'allergies': [],
		'preference': 4,
		'_id': '5dec9de878c3c100170e3086',
		'ingredientId': '5ded8f6aa816a60017606d99',
		'ingredientName': 'Cookie',
		'text': 'Cookie Base',
		'quantity': 22,
		'unit': 'servings'
	  },
	  {
		'allergies': [],
		'preference': 5,
		'_id': '5dec9de878c3c100170e3085',
		'ingredientId': '5ded8f6aa816a60017606d0b',
		'ingredientName': 'Milk',
		'text': 'Fresh milk',
		'quantity': 1,
		'unit': 'Tbsp'
	  },
	  {
		'allergies': [],
		'preference': 6,
		'_id': '5dec9de878c3c100170e3084',
		'ingredientId': '5ded8f6aa816a60017606d36',
		'ingredientName': 'Oatmeal',
		'text': 'Oatmeal Crushed cornflakes',
		'quantity': 20,
		'unit': 'g'
	  },
	  {
		'allergies': [],
		'preference': 7,
		'_id': '5dec9de878c3c100170e3083',
		'ingredientId': '5ded8f6aa816a60017606d4c',
		'ingredientName': 'Plain Flour',
		'text': 'Plain flour',
		'quantity': 100,
		'unit': 'g'
	  },
	  {
		'allergies': [],
		'preference': 8,
		'_id': '5dec9de878c3c100170e3082',
		'ingredientId': '5ded8f6aa816a60017606cf0',
		'ingredientName': 'Wholemeal Flour',
		'text': 'Wholemeal flour',
		'quantity': 80,
		'unit': 'g'
	  }
	],
	'steppedInstructions': [
	  {
		'ingredients': [
		  'Whole Wheat Flour',
		  'All Purpose Flour',
		  'Butter'
		],
		'equipment': [
		  'Spatula',
		  'Bowl'
		],
		'_id': '5dec9de878c3c100170e3090',
		'number': 1,
		// tslint:disable-next-line: max-line-length
		'step': 'Beat butter and sugar until light and fluffy.In a bowl combine wholemeal flour and plain flour together, then mix in the butter mixture with a rubber spatula and knead gently to a soft dough.Turn out the dough on to a flour surface or line with a plastic sheet below and with another plastic sheet on top. Then roll to a square. Chill for at least 1 hour.'
	  },
	  {
		'ingredients': [],
		'equipment': [
		  'Oven'
		],
		'_id': '5dec9de878c3c100170e308f',
		'number': 2,
		// tslint:disable-next-line: max-line-length
		'step': 'Transfer the dough on a non grease paper and cover with a plastic sheet on top, then roll to dough to about 3mm thick.Prick the dough with a fork and bake for about 15-18 minutes until brown at preheated oven 180C and leave biscuit to cool.'
	  },
	  {
		'ingredients': [
		  'Apricot Jam'
		],
		'equipment': [],
		'_id': '5dec9de878c3c100170e308e',
		'number': 3,
		'step': 'Spread the apricot jam over the top of the biscuit, set aside.'
	  },
	  {
		'ingredients': [],
		'equipment': [
		  'Palette Knife'
		],
		'_id': '5dec9de878c3c100170e308d',
		'number': 4,
		'step': 'Mix topping ingredients and spread evenly on the biscuit with a palette knife.'
	  },
	  {
		'ingredients': [],
		'equipment': [],
		'_id': '5dec9de878c3c100170e308c',
		'number': 5,
		'step': 'Bake for 15 minutes until golden.'
	  },
	  {
		'ingredients': [],
		'equipment': [
		  'Oven'
		],
		'_id': '5dec9de878c3c100170e308b',
		'number': 6,
		'step': 'Remove cooked biscuit from the oven and leave to cool completely, then cut into bars.'
	  }
	],
	'history': [],
	'createdAt': '2019-12-08T06:53:28.523Z',
	'updatedAt': '2019-12-09T05:55:59.710Z',
	'__v': 0,
	'ratings': []
  };

export const fakeRecipeReturn: Recipes = {
	items: [fakeRecipe1, fakeRecipe2],
	total: 2
};

