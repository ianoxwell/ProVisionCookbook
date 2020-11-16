export interface ApiNode {
  openapi: string;
  info: {
	version: string;
	description: string;
	title: string;
	contact: {
	  name: string;
	  email: string;
	};
  };
  paths: any;
  tags: { name: string; description: string }[];
  servers: { url: string }[];
  components: {
	responses: any;
	schemas: any;
	securitySchemes: any;
  };
}
export const openAPIJSON: ApiNode = {
  'openapi': '3.0.0',
  'info': {
	'version': '1.0.0-oas3',
	'description': 'This is the API for the Provisioner\'s CookBook Project',
	'title': 'Provisioners CookBook Api',
	'contact': {
	  'name': 'Ian Oxwell',
	  'email': 'ianoxwell@gmail.com'
	}
  },
  'paths': {
	'/ingredients': {
	  'get': {
		'tags': [
		  'ingredients'
		],
		'parameters': [
		  {
			'in': 'query',
			'name': 'offset',
			'schema': {
			  'type': 'number',
			  'default': 0
			},
			'description': 'Number of records to skip'
		  },
		  {
			'in': 'query',
			'name': 'limit',
			'schema': {
			  'type': 'number',
			  'default': 25,
			  'minimum': 5,
			  'maximum': 200
			},
			'description': 'Results per page'
		  },
		  {
			'in': 'query',
			'name': 'sort',
			'schema': {
			  'type': 'string',
			  'example': '-name'
			},
			'description': 'Pass sort option field'
		  },
		  {
			'in': 'query',
			'name': 'filter',
			'schema': {
			  'type': 'string'
			},
			'description': 'Simple filtering by field value'
		  },
		  {
			'in': 'query',
			'name': 'match',
			'schema': {
			  'type': 'string'
			},
			'description': 'Searches based on regex'
		  },
		  {
			'in': 'query',
			'name': 'select',
			'schema': {
			  'type': 'string'
			},
			'description': 'Choose to include or exclude fields',
			'example': null
		  }
		],
		'summary': 'Get a specified number of ingredients paginated',
		'description': 'List of Ingredients and their data',
		'operationId': 'ingredientList',
		'responses': {
		  '200': {
			'description': 'successful operation',
			'content': {
			  'application/json': {
				'schema': {
				  'type': 'array',
				  'items': {
					'$ref': '#/components/schemas/ingredient'
				  }
				}
			  }
			}
		  },
		  '401': {
			'$ref': '#/components/responses/Unauthorized'
		  },
		  '404': {
			'$ref': '#/components/responses/NotFound'
		  }
		},
		'security': [
		  {
			'oAuth2AuthCode': [
			  'student',
			  'teacher',
			  'admin'
			]
		  }
		]
	  },
	  'post': {
		'tags': [
		  'ingredients'
		],
		'summary': 'Create a new ingredient',
		'operationId': 'createIngredient',
		'requestBody': {
		  'description': 'The Object containing the new ingredient',
		  'content': {
			'application/json': {
			  'schema': {
				'$ref': '#/components/schemas/ingredient'
			  }
			}
		  }
		},
		'responses': {
		  '200': {
			'description': 'A new ingredient returned',
			'content': {
			  'application/json': {
				'schema': {
				  '$ref': '#/components/schemas/ingredient'
				}
			  }
			}
		  },
		  '401': {
			'$ref': '#/components/responses/Unauthorized'
		  },
		  '404': {
			'$ref': '#/components/responses/NotFound'
		  }
		}
	  }
	},
	'/ingredients/suggestion': {
	  'get': {
		'tags': [
		  'ingredients'
		],
		'summary': 'Returns name responses for autocomplete',
		'operationId': 'ingredientSuggestion',
		'parameters': [
		  {
			'in': 'query',
			'name': 'key',
			'schema': {
			  'type': 'string',
			  'minLength': 2
			},
			'description': 'Start or part of ingredient name'
		  }
		],
		'responses': {
		  '200': {
			'description': 'A list of suggested Ingredients',
			'content': {
			  'application/json': {
				'schema': {
				  'type': 'array',
				  'items': {
					'$ref': '#/components/schemas/suggestion'
				  }
				}
			  }
			}
		  },
		  '401': {
			'$ref': '#/components/responses/Unauthorized'
		  },
		  '404': {
			'$ref': '#/components/responses/NotFound'
		  }
		}
	  }
	},
	'/ingredients/getByName': {
	  'get': {
		'tags': [
		  'ingredients'
		],
		'summary': 'Returns ingredients matching search',
		'operationId': 'ingredientByName',
		'parameters': [
		  {
			'in': 'query',
			'name': 'key',
			'schema': {
			  'type': 'string',
			  'minLength': 2
			},
			'description': 'Field to search upon (name or parent)'
		  },
		  {
			'in': 'query',
			'name': 'value',
			'schema': {
			  'type': 'string',
			  'minLength': 2
			},
			'description': 'The Value to search'
		  }
		],
		'responses': {
		  '200': {
			'description': 'A list of Ingredients',
			'content': {
			  'application/json': {
				'schema': {
				  'type': 'array',
				  'items': {
					'$ref': '#/components/schemas/ingredient'
				  }
				}
			  }
			}
		  },
		  '401': {
			'$ref': '#/components/responses/Unauthorized'
		  },
		  '404': {
			'$ref': '#/components/responses/NotFound'
		  }
		}
	  }
	},
	'/ingredient/{getById}': {
	  'get': {
		'tags': [
		  'ingredients'
		],
		'summary': 'Returns single ingredient matching id',
		'operationId': 'ingredientById',
		'parameters': [
		  {
			'in': 'path',
			'name': 'getById',
			'required': true,
			'schema': {
			  'type': 'string'
			},
			'description': 'MongoDB Id number'
		  }
		],
		'responses': {
		  '200': {
			'description': 'A single ingredient',
			'content': {
			  'application/json': {
				'schema': {
				  '$ref': '#/components/schemas/ingredient'
				}
			  }
			}
		  },
		  '401': {
			'$ref': '#/components/responses/Unauthorized'
		  },
		  '404': {
			'$ref': '#/components/responses/NotFound'
		  }
		}
	  },
	  'put': {
		'tags': [
		  'ingredients'
		],
		'summary': 'Update a single ingredient',
		'operationId': 'updateIngredient',
		'parameters': [
		  {
			'in': 'path',
			'name': 'getById',
			'required': true,
			'schema': {
			  'type': 'string'
			},
			'description': 'MongoDB Id number'
		  }
		],
		'requestBody': {
		  'description': 'The Object containing the updated ingredient fields',
		  'content': {
			'application/json': {
			  'schema': {
				'$ref': '#/components/schemas/ingredient'
			  }
			}
		  },
		  'required': true
		},
		'responses': {
		  '200': {
			'description': 'A new ingredient returned',
			'content': {
			  'application/json': {
				'schema': {
				  '$ref': '#/components/schemas/ingredient'
				}
			  }
			}
		  },
		  '401': {
			'$ref': '#/components/responses/Unauthorized'
		  },
		  '404': {
			'$ref': '#/components/responses/NotFound'
		  }
		}
	  },
	  'delete': {
		'tags': [
		  'ingredients'
		],
		'summary': 'Delete a single ingredient',
		'operationId': 'deleteIngredient',
		'parameters': [
		  {
			'in': 'path',
			'name': 'getById',
			'required': true,
			'schema': {
			  'type': 'string'
			},
			'description': 'MongoDB Id number'
		  }
		],
		'responses': {
		  '200': {
			'description': 'Deleted ingredient returned',
			'content': {
			  'application/json': {
				'schema': {
				  '$ref': '#/components/schemas/ingredient'
				}
			  }
			}
		  },
		  '401': {
			'$ref': '#/components/responses/Unauthorized'
		  },
		  '404': {
			'$ref': '#/components/responses/NotFound'
		  }
		}
	  }
	},
	'/ingredient/{getById}/{subDocument}': {
	  'post': {
		'tags': [
		  'ingredients'
		],
		'summary': 'Create a new sub ingredient',
		'operationId': 'createSubIngredient',
		'parameters': [
		  {
			'in': 'path',
			'name': 'getById',
			'required': true,
			'schema': {
			  'type': 'string'
			},
			'description': 'MongoDB Id number'
		  },
		  {
			'in': 'path',
			'name': 'subDocument',
			'required': true,
			'schema': {
			  'type': 'string',
			  'enum': [
				'prices',
				'conversions'
			  ]
			},
			'description': 'MongoDB Id number'
		  }
		],
		'requestBody': {
		  'description': 'The Object containing the new ingredient',
		  'content': {
			'application/json': {
			  'schema': {
				'oneOf': [
				  {
					'$ref': '#/components/schemas/price'
				  },
				  {
					'$ref': '#/components/schemas/conversion'
				  }
				]
			  }
			}
		  }
		},
		'responses': {
		  '200': {
			'description': 'A new ingredient returned',
			'content': {
			  'application/json': {
				'schema': {
				  '$ref': '#/components/schemas/ingredient'
				}
			  }
			}
		  },
		  '401': {
			'$ref': '#/components/responses/Unauthorized'
		  },
		  '404': {
			'$ref': '#/components/responses/NotFound'
		  }
		}
	  }
	},
	'/ingredient/{getById}/{subDocument}/{subDocumentId}': {
	  'put': {
		'tags': [
		  'ingredients'
		],
		'summary': 'Update a single ingredient subDocument',
		'operationId': 'updateSubIngredient',
		'parameters': [
		  {
			'in': 'path',
			'name': 'getById',
			'required': true,
			'schema': {
			  'type': 'string'
			},
			'description': 'MongoDB Id number'
		  },
		  {
			'in': 'path',
			'name': 'subDocument',
			'required': true,
			'schema': {
			  'type': 'string',
			  'enum': [
				'prices',
				'conversions'
			  ]
			},
			'description': 'MongoDB Id number'
		  },
		  {
			'in': 'path',
			'name': 'subDocumentId',
			'required': true,
			'schema': {
			  'type': 'string'
			},
			'description': 'MongoDB Id number'
		  }
		],
		'requestBody': {
		  'description': 'The Object containing the updated ingredient subDocument',
		  'content': {
			'application/json': {
			  'schema': {
				'oneOf': [
				  {
					'$ref': '#/components/schemas/price'
				  },
				  {
					'$ref': '#/components/schemas/conversion'
				  }
				]
			  }
			}
		  },
		  'required': true
		},
		'responses': {
		  '200': {
			'description': 'A new ingredient returned',
			'content': {
			  'application/json': {
				'schema': {
				  '$ref': '#/components/schemas/ingredient'
				}
			  }
			}
		  },
		  '401': {
			'$ref': '#/components/responses/Unauthorized'
		  },
		  '404': {
			'$ref': '#/components/responses/NotFound'
		  }
		}
	  },
	  'delete': {
		'tags': [
		  'ingredients'
		],
		'summary': 'Delete a single ingredient',
		'operationId': 'deleteSubIngredient',
		'parameters': [
		  {
			'in': 'path',
			'name': 'getById',
			'required': true,
			'schema': {
			  'type': 'string'
			},
			'description': 'MongoDB Id number'
		  },
		  {
			'in': 'path',
			'name': 'subDocument',
			'required': true,
			'schema': {
			  'type': 'string',
			  'enum': [
				'prices',
				'conversions'
			  ]
			},
			'description': 'MongoDB Id number'
		  },
		  {
			'in': 'path',
			'name': 'subDocumentId',
			'required': true,
			'schema': {
			  'type': 'string'
			},
			'description': 'MongoDB Id number'
		  }
		],
		'responses': {
		  '200': {
			'description': 'Deleted ingredient returned',
			'content': {
			  'application/json': {
				'schema': {
				  '$ref': '#/components/schemas/ingredient'
				}
			  }
			}
		  },
		  '401': {
			'$ref': '#/components/responses/Unauthorized'
		  },
		  '404': {
			'$ref': '#/components/responses/NotFound'
		  }
		}
	  }
	},
	'/recipe/{getById}': {
	  'get': {
		'tags': [
		  'recipes'
		],
		'summary': 'Returns single recipe matching id',
		'operationId': 'recipeById',
		'parameters': [
		  {
			'in': 'path',
			'name': 'getById',
			'required': true,
			'schema': {
			  'type': 'string'
			},
			'description': 'MongoDB Id number'
		  }
		],
		'responses': {
		  '200': {
			'description': 'A single recipe',
			'content': {
			  'application/json': {
				'schema': {
				  '$ref': '#/components/schemas/recipe'
				}
			  }
			}
		  },
		  '401': {
			'$ref': '#/components/responses/Unauthorized'
		  },
		  '404': {
			'$ref': '#/components/responses/NotFound'
		  }
		}
	  },
	  'put': {
		'tags': [
		  'recipes'
		],
		'summary': 'Update a single recipe',
		'operationId': 'updateRecipe',
		'parameters': [
		  {
			'in': 'path',
			'name': 'getById',
			'required': true,
			'schema': {
			  'type': 'string'
			},
			'description': 'MongoDB Id number'
		  }
		],
		'requestBody': {
		  'description': 'The Object containing the updated recipe fields',
		  'content': {
			'application/json': {
			  'schema': {
				'$ref': '#/components/schemas/recipe'
			  }
			}
		  },
		  'required': true
		},
		'responses': {
		  '200': {
			'description': 'A new recipe returned',
			'content': {
			  'application/json': {
				'schema': {
				  '$ref': '#/components/schemas/recipe'
				}
			  }
			}
		  },
		  '401': {
			'$ref': '#/components/responses/Unauthorized'
		  },
		  '404': {
			'$ref': '#/components/responses/NotFound'
		  }
		}
	  },
	  'delete': {
		'tags': [
		  'recipes'
		],
		'summary': 'Delete a single recipe',
		'operationId': 'deleteRecipe',
		'parameters': [
		  {
			'in': 'path',
			'name': 'getById',
			'required': true,
			'schema': {
			  'type': 'string'
			},
			'description': 'MongoDB Id number'
		  }
		],
		'responses': {
		  '200': {
			'description': 'Deleted recipe returned',
			'content': {
			  'application/json': {
				'schema': {
				  '$ref': '#/components/schemas/ingredient'
				}
			  }
			}
		  },
		  '401': {
			'$ref': '#/components/responses/Unauthorized'
		  },
		  '404': {
			'$ref': '#/components/responses/NotFound'
		  }
		}
	  }
	},
	'/recipe/{getById}/{subDocument}': {
	  'post': {
		'tags': [
		  'recipes'
		],
		'summary': 'Create a new subDocument in recipe',
		'operationId': 'createSubRecipe',
		'parameters': [
		  {
			'in': 'path',
			'name': 'getById',
			'required': true,
			'schema': {
			  'type': 'string'
			},
			'description': 'MongoDB Id number'
		  },
		  {
			'in': 'path',
			'name': 'subDocument',
			'required': true,
			'schema': {
			  'type': 'string',
			  'enum': [
				'history',
				'ingredientList'
			  ]
			},
			'description': 'MongoDB Id number'
		  }
		],
		'requestBody': {
		  'description': 'The Object containing the new Recipe Subdocument',
		  'content': {
			'application/json': {
			  'schema': {
				'oneOf': [
				  {
					'$ref': '#/components/schemas/history'
				  },
				  {
					'$ref': '#/components/schemas/ingredientList'
				  }
				]
			  }
			}
		  }
		},
		'responses': {
		  '200': {
			'description': 'The complete recipe returned plus the new addition',
			'content': {
			  'application/json': {
				'schema': {
				  '$ref': '#/components/schemas/recipe'
				}
			  }
			}
		  },
		  '401': {
			'$ref': '#/components/responses/Unauthorized'
		  },
		  '404': {
			'$ref': '#/components/responses/NotFound'
		  }
		}
	  }
	},
	'/recipe/{getById}/{subDocument}/{subDocumentId}': {
	  'put': {
		'tags': [
		  'recipes'
		],
		'summary': 'Update a single recipe subDocument',
		'operationId': 'updateSubRecipe',
		'parameters': [
		  {
			'in': 'path',
			'name': 'getById',
			'required': true,
			'schema': {
			  'type': 'string'
			},
			'description': 'MongoDB Id number'
		  },
		  {
			'in': 'path',
			'name': 'subDocument',
			'required': true,
			'schema': {
			  'type': 'string',
			  'enum': [
				'history',
				'ingredientList'
			  ]
			},
			'description': 'MongoDB Id number'
		  },
		  {
			'in': 'path',
			'name': 'subDocumentId',
			'required': true,
			'schema': {
			  'type': 'string'
			},
			'description': 'MongoDB Id number'
		  }
		],
		'requestBody': {
		  'description': 'The Object containing the updated recipe subDocument',
		  'content': {
			'application/json': {
			  'schema': {
				'oneOf': [
				  {
					'$ref': '#/components/schemas/history'
				  },
				  {
					'$ref': '#/components/schemas/ingredientList'
				  }
				]
			  }
			}
		  },
		  'required': true
		},
		'responses': {
		  '200': {
			'description': 'A new recipe returned',
			'content': {
			  'application/json': {
				'schema': {
				  '$ref': '#/components/schemas/recipe'
				}
			  }
			}
		  },
		  '401': {
			'$ref': '#/components/responses/Unauthorized'
		  },
		  '404': {
			'$ref': '#/components/responses/NotFound'
		  }
		}
	  },
	  'delete': {
		'tags': [
		  'recipes'
		],
		'summary': 'Delete a single recipe SubDocument',
		'operationId': 'deleteSubRecipe',
		'parameters': [
		  {
			'in': 'path',
			'name': 'getById',
			'required': true,
			'schema': {
			  'type': 'string'
			},
			'description': 'MongoDB Id number'
		  },
		  {
			'in': 'path',
			'name': 'subDocument',
			'required': true,
			'schema': {
			  'type': 'string',
			  'enum': [
				'history',
				'ingredientList'
			  ]
			},
			'description': 'MongoDB Id number'
		  },
		  {
			'in': 'path',
			'name': 'subDocumentId',
			'required': true,
			'schema': {
			  'type': 'string'
			},
			'description': 'MongoDB Id number'
		  }
		],
		'responses': {
		  '200': {
			'description': 'Complete recipe returned (sans the deleted item)',
			'content': {
			  'application/json': {
				'schema': {
				  '$ref': '#/components/schemas/recipe'
				}
			  }
			}
		  },
		  '401': {
			'$ref': '#/components/responses/Unauthorized'
		  },
		  '404': {
			'$ref': '#/components/responses/NotFound'
		  }
		}
	  }
	},
	'/recipes': {
	  'get': {
		'tags': [
		  'recipes'
		],
		'parameters': [
		  {
			'in': 'query',
			'name': 'page',
			'schema': {
			  'type': 'number',
			  'default': 0
			},
			'description': 'Page number to start at'
		  },
		  {
			'in': 'query',
			'name': 'limit',
			'schema': {
			  'type': 'number',
			  'default': 25,
			  'minimum': 5,
			  'maximum': 200
			},
			'description': 'Results per page'
		  },
		  {
			'in': 'query',
			'name': 'sort',
			'schema': {
			  'type': 'string',
			  'example': 'timeBooked'
			},
			'description': 'Pass sort option field'
		  },
		  {
			'in': 'query',
			'name': 'filter',
			'schema': {
			  'type': 'string'
			},
			'description': 'Simple filtering by field value'
		  },
		  {
			'in': 'query',
			'name': 'match',
			'schema': {
			  'type': 'string'
			},
			'description': 'Searches based on regex'
		  },
		  {
			'in': 'query',
			'name': 'search',
			'schema': {
			  'type': 'string'
			},
			'description': 'Performs search by full text mongodb indexes'
		  }
		],
		'summary': 'Get a specified number of recipes paginated, filtered and sorted',
		'operationId': 'recipeList',
		'responses': {
		  '200': {
			'description': 'successful operation',
			'content': {
			  'application/json': {
				'schema': {
				  'type': 'array',
				  'items': {
					'$ref': '#/components/schemas/recipe'
				  }
				}
			  }
			}
		  },
		  '401': {
			'$ref': '#/components/responses/Unauthorized'
		  }
		},
		'security': [
		  {
			'oAuth2AuthCode': [
			  'student',
			  'teacher',
			  'admin'
			]
		  }
		]
	  },
	  'post': {
		'tags': [
		  'recipes'
		],
		'summary': 'Create a new recipe',
		'operationId': 'createRecipe',
		'requestBody': {
		  'description': 'The Object containing the new recipe',
		  'content': {
			'application/json': {
			  'schema': {
				'$ref': '#/components/schemas/recipe'
			  }
			}
		  }
		},
		'responses': {
		  '200': {
			'description': 'A new recipe returned',
			'content': {
			  'application/json': {
				'schema': {
				  '$ref': '#/components/schemas/recipe'
				}
			  }
			}
		  },
		  '401': {
			'$ref': '#/components/responses/Unauthorized'
		  },
		  '404': {
			'$ref': '#/components/responses/NotFound'
		  }
		}
	  }
	},
	'/recipe/random': {
	  'get': {
		'tags': [
		  'recipes'
		],
		'summary': 'Returns single recipe randomly',
		'operationId': 'randomRecipe',
		'responses': {
		  '200': {
			'description': 'A single recipe',
			'content': {
			  'application/json': {
				'schema': {
				  '$ref': '#/components/schemas/recipe'
				}
			  }
			}
		  },
		  '401': {
			'$ref': '#/components/responses/Unauthorized'
		  },
		  '404': {
			'$ref': '#/components/responses/NotFound'
		  }
		}
	  }
	},
	'/recipes/suggestion': {
	  'get': {
		'tags': [
		  'recipes'
		],
		'summary': 'Returns name responses for autocomplete',
		'operationId': 'recipeSuggestion',
		'parameters': [
		  {
			'in': 'query',
			'name': 'key',
			'schema': {
			  'type': 'string',
			  'minLength': 2
			},
			'description': 'Start or part of recipe name'
		  }
		],
		'responses': {
		  '200': {
			'description': 'A list of recipe suggestions',
			'content': {
			  'application/json': {
				'schema': {
				  'type': 'array',
				  'items': {
					'$ref': '#/components/schemas/suggestion'
				  }
				}
			  }
			}
		  },
		  '401': {
			'$ref': '#/components/responses/Unauthorized'
		  },
		  '404': {
			'$ref': '#/components/responses/NotFound'
		  }
		}
	  }
	},
	'/recipes/getByValue': {
	  'get': {
		'tags': [
		  'recipes'
		],
		'summary': 'Returns recipes matching search',
		'operationId': 'recipeByValue',
		'parameters': [
		  {
			'in': 'query',
			'name': 'key',
			'schema': {
			  'type': 'string',
			  'minLength': 2
			},
			'description': 'Field to search upon (name or recipeType or cuisineType or createdByUser)'
		  },
		  {
			'in': 'query',
			'name': 'value',
			'schema': {
			  'type': 'string',
			  'minLength': 2
			},
			'description': 'The Value to search'
		  }
		],
		'responses': {
		  '200': {
			'description': 'A list of Recipes',
			'content': {
			  'application/json': {
				'schema': {
				  'type': 'array',
				  'items': {
					'$ref': '#/components/schemas/recipe'
				  }
				}
			  }
			}
		  },
		  '401': {
			'$ref': '#/components/responses/Unauthorized'
		  },
		  '404': {
			'$ref': '#/components/responses/NotFound'
		  }
		}
	  }
	},
	'/booking/{getById}': {
	  'get': {
		'tags': [
		  'bookings'
		],
		'summary': 'Returns single booking matching id',
		'operationId': 'bookingById',
		'parameters': [
		  {
			'in': 'path',
			'name': 'getById',
			'required': true,
			'schema': {
			  'type': 'string'
			},
			'description': 'MongoDB Id number'
		  }
		],
		'responses': {
		  '200': {
			'description': 'A single booking',
			'content': {
			  'application/json': {
				'schema': {
				  '$ref': '#/components/schemas/booking'
				}
			  }
			}
		  },
		  '401': {
			'$ref': '#/components/responses/Unauthorized'
		  },
		  '404': {
			'$ref': '#/components/responses/NotFound'
		  }
		}
	  },
	  'put': {
		'tags': [
		  'bookings'
		],
		'summary': 'Update a single booking',
		'operationId': 'updateBooking',
		'parameters': [
		  {
			'in': 'path',
			'name': 'getById',
			'required': true,
			'schema': {
			  'type': 'string'
			},
			'description': 'MongoDB Id number'
		  }
		],
		'requestBody': {
		  'description': 'The Object containing the updated booking fields',
		  'content': {
			'application/json': {
			  'schema': {
				'$ref': '#/components/schemas/booking'
			  }
			}
		  },
		  'required': true
		},
		'responses': {
		  '200': {
			'description': 'A new recipe returned',
			'content': {
			  'application/json': {
				'schema': {
				  '$ref': '#/components/schemas/booking'
				}
			  }
			}
		  },
		  '401': {
			'$ref': '#/components/responses/Unauthorized'
		  },
		  '404': {
			'$ref': '#/components/responses/NotFound'
		  }
		}
	  },
	  'delete': {
		'tags': [
		  'bookings'
		],
		'summary': 'Delete a single booking',
		'operationId': 'deleteBooking',
		'parameters': [
		  {
			'in': 'path',
			'name': 'getById',
			'required': true,
			'schema': {
			  'type': 'string'
			},
			'description': 'MongoDB Id number'
		  }
		],
		'responses': {
		  '200': {
			'description': 'Deleted booking returned',
			'content': {
			  'application/json': {
				'schema': {
				  '$ref': '#/components/schemas/booking'
				}
			  }
			}
		  },
		  '401': {
			'$ref': '#/components/responses/Unauthorized'
		  },
		  '404': {
			'$ref': '#/components/responses/NotFound'
		  }
		}
	  }
	},
	'/bookings': {
	  'get': {
		'tags': [
		  'bookings'
		],
		'parameters': [
		  {
			'in': 'query',
			'name': 'offset',
			'schema': {
			  'type': 'number',
			  'default': 0
			},
			'description': 'Number of records to skip'
		  },
		  {
			'in': 'query',
			'name': 'limit',
			'schema': {
			  'type': 'number',
			  'default': 25,
			  'minimum': 5,
			  'maximum': 200
			},
			'description': 'Results per page'
		  },
		  {
			'in': 'query',
			'name': 'sort',
			'schema': {
			  'type': 'string',
			  'example': 'timeBooked'
			},
			'description': 'Pass sort option field'
		  },
		  {
			'in': 'query',
			'name': 'filter',
			'schema': {
			  'type': 'string'
			},
			'description': 'Simple filtering by field value'
		  }
		],
		'summary': 'Get a specified number of Bookings paginated, filtered and sorted',
		'operationId': 'bookingList',
		'responses': {
		  '200': {
			'description': 'successful operation',
			'content': {
			  'application/json': {
				'schema': {
				  'type': 'array',
				  'items': {
					'$ref': '#/components/schemas/booking'
				  }
				}
			  }
			}
		  },
		  '401': {
			'$ref': '#/components/responses/Unauthorized'
		  },
		  '404': {
			'$ref': '#/components/responses/NotFound'
		  }
		},
		'security': [
		  {
			'oAuth2AuthCode': [
			  'student',
			  'teacher',
			  'admin'
			]
		  }
		]
	  },
	  'post': {
		'tags': [
		  'bookings'
		],
		'summary': 'Create a new Booking',
		'operationId': 'createBookings',
		'requestBody': {
		  'description': 'The Object containing the new Booking',
		  'content': {
			'application/json': {
			  'schema': {
				'$ref': '#/components/schemas/booking'
			  }
			}
		  }
		},
		'responses': {
		  '200': {
			'description': 'A new ingredient returned',
			'content': {
			  'application/json': {
				'schema': {
				  '$ref': '#/components/schemas/booking'
				}
			  }
			}
		  },
		  '401': {
			'$ref': '#/components/responses/Unauthorized'
		  },
		  '404': {
			'$ref': '#/components/responses/NotFound'
		  }
		}
	  }
	},
	'/users': {
	  'get': {
		'tags': [
		  'user'
		],
		'summary': 'Returns users matching search - security limited',
		'operationId': 'userByValue',
		'parameters': [
		  {
			'in': 'query',
			'name': 'offset',
			'schema': {
			  'type': 'number',
			  'default': 0
			},
			'description': 'Number of records to skip'
		  },
		  {
			'in': 'query',
			'name': 'limit',
			'schema': {
			  'type': 'number',
			  'default': 25,
			  'minimum': 5,
			  'maximum': 200
			},
			'description': 'Results per page'
		  },
		  {
			'in': 'query',
			'name': 'sort',
			'schema': {
			  'type': 'string',
			  'example': 'timeBooked'
			},
			'description': 'Pass sort option field'
		  },
		  {
			'in': 'query',
			'name': 'filter',
			'schema': {
			  'type': 'string'
			},
			'description': 'Simple filtering by field value'
		  },
		  {
			'in': 'query',
			'name': 'match',
			'schema': {
			  'type': 'string'
			},
			'description': 'Searches based on regex'
		  }
		],
		'responses': {
		  '200': {
			'description': 'A list of Users',
			'content': {
			  'application/json': {
				'schema': {
				  'type': 'array',
				  'items': {
					'$ref': '#/components/schemas/user'
				  }
				}
			  }
			}
		  },
		  '401': {
			'$ref': '#/components/responses/Unauthorized'
		  },
		  '404': {
			'$ref': '#/components/responses/NotFound'
		  }
		},
		'security': [
		  {
			'oAuth2AuthCode': [
			  'teacher',
			  'admin'
			]
		  }
		]
	  },
	  'post': {
		'tags': [
		  'user'
		],
		'summary': 'Create user',
		'description': 'This is the operation permformed to create user.',
		'operationId': 'createUser',
		'requestBody': {
		  'description': 'Created user object',
		  'content': {
			'application/json': {
			  'schema': {
				'$ref': '#/components/schemas/user'
			  }
			}
		  },
		  'required': true
		},
		'responses': {
		  '200': {
			'description': 'A User',
			'content': {
			  'application/json': {
				'schema': {
				  '$ref': '#/components/schemas/user'
				}
			  }
			}
		  },
		  '401': {
			'$ref': '#/components/responses/Unauthorized'
		  },
		  '404': {
			'$ref': '#/components/responses/NotFound'
		  }
		}
	  }
	},
	'/user/login': {
	  'get': {
		'tags': [
		  'user'
		],
		'summary': 'Logs user into the system',
		'operationId': 'loginUser',
		'parameters': [
		  {
			'name': 'username',
			'in': 'query',
			'description': 'The user name for login',
			'required': true,
			'schema': {
			  'type': 'string'
			}
		  },
		  {
			'name': 'password',
			'in': 'query',
			'description': 'The password for login in clear text',
			'required': true,
			'schema': {
			  'type': 'string'
			}
		  }
		],
		'responses': {
		  '200': {
			'description': 'successful operation',
			'headers': {
			  'X-Rate-Limit': {
				'description': 'calls per hour allowed by the user',
				'schema': {
				  'type': 'integer',
				  'format': 'int32'
				}
			  },
			  'X-Expires-After': {
				'description': 'date in UTC when token expires',
				'schema': {
				  'type': 'string',
				  'format': 'date-time'
				}
			  }
			},
			'content': {
			  'application/json': {
				'schema': {
				  'type': 'string'
				}
			  }
			}
		  },
		  '400': {
			'description': 'Invalid username/password supplied',
			'content': {}
		  }
		}
	  }
	},
	'/user/logout': {
	  'get': {
		'tags': [
		  'user'
		],
		'summary': 'Logs out current logged in user session',
		'operationId': 'logoutUser',
		'responses': {
		  '200': {
			'description': 'A logged out User',
			'content': {
			  'application/json': {
				'schema': {
				  '$ref': '#/components/schemas/user'
				}
			  }
			}
		  },
		  '401': {
			'$ref': '#/components/responses/Unauthorized'
		  },
		  '404': {
			'$ref': '#/components/responses/NotFound'
		  }
		}
	  }
	},
	'/user/{getById}': {
	  'get': {
		'tags': [
		  'user'
		],
		'summary': 'Get user by user name',
		'operationId': 'getUserByName',
		'parameters': [
		  {
			'name': 'getById',
			'in': 'path',
			'description': 'The name that needs to be fetched. Use user1 for testing. ',
			'required': true,
			'schema': {
			  'type': 'string'
			}
		  }
		],
		'responses': {
		  '200': {
			'description': 'successful operation',
			'content': {
			  'application/json': {
				'schema': {
				  '$ref': '#/components/schemas/user'
				}
			  }
			}
		  },
		  '400': {
			'description': 'Invalid username supplied',
			'content': {}
		  },
		  '401': {
			'$ref': '#/components/responses/Unauthorized'
		  },
		  '404': {
			'$ref': '#/components/responses/NotFound'
		  }
		},
		'security': [
		  {
			'oAuth2AuthCode': [
			  'self',
			  'teacher',
			  'admin'
			]
		  }
		]
	  },
	  'put': {
		'tags': [
		  'user'
		],
		'summary': 'Updated user',
		'description': 'This can only be done by the logged in user.',
		'operationId': 'updateUser',
		'parameters': [
		  {
			'name': 'getById',
			'in': 'path',
			'description': 'name that need to be updated',
			'required': true,
			'schema': {
			  'type': 'string'
			}
		  }
		],
		'requestBody': {
		  'description': 'Updated user object',
		  'content': {
			'application/json': {
			  'schema': {
				'$ref': '#/components/schemas/user'
			  }
			}
		  },
		  'required': true
		},
		'responses': {
		  '200': {
			'description': 'successful operation',
			'content': {
			  'application/json': {
				'schema': {
				  '$ref': '#/components/schemas/user'
				}
			  }
			}
		  },
		  '400': {
			'description': 'Invalid username supplied',
			'content': {}
		  },
		  '401': {
			'$ref': '#/components/responses/Unauthorized'
		  },
		  '404': {
			'$ref': '#/components/responses/NotFound'
		  }
		},
		'security': [
		  {
			'oAuth2AuthCode': [
			  'self',
			  'teacher',
			  'admin'
			]
		  }
		]
	  },
	  'delete': {
		'tags': [
		  'user'
		],
		'summary': 'Delete user',
		'description': 'This can only be done by the logged in user.',
		'operationId': 'deleteUser',
		'parameters': [
		  {
			'name': 'getById',
			'in': 'path',
			'description': 'The name that needs to be deleted',
			'required': true,
			'schema': {
			  'type': 'string'
			}
		  }
		],
		'responses': {
		  '200': {
			'description': 'successful operation',
			'content': {
			  'application/json': {
				'schema': {
				  '$ref': '#/components/schemas/user'
				}
			  }
			}
		  },
		  '400': {
			'description': 'Invalid username supplied',
			'content': {}
		  },
		  '401': {
			'$ref': '#/components/responses/Unauthorized'
		  },
		  '404': {
			'$ref': '#/components/responses/NotFound'
		  }
		},
		'security': [
		  {
			'oAuth2AuthCode': [
			  'self',
			  'teacher',
			  'admin'
			]
		  }
		]
	  }
	},
	'/ping': {
	  'get': {
		'tags': [
		  'server'
		],
		'summary': 'Server heartbeat operation',
		'description': 'This operation shows how to override the global security defined above, as we want to open it up for all users.',
		'security': [],
		'responses': {
		  '200': {
			'description': 'A successful ping message',
			'content': {
			  'application/json': {
				'schema': {
				  '$ref': '#/components/schemas/Error'
				}
			  }
			}
		  },
		  '401': {
			'$ref': '#/components/responses/Unauthorized'
		  },
		  '404': {
			'$ref': '#/components/responses/NotFound'
		  }
		}
	  }
	}
  },
  'tags': [
	{
	  'name': 'ingredients',
	  'description': 'All the ingredients you could need'
	},
	{
	  'name': 'recipes',
	  'description': 'Cooking Recipes with conversions'
	},
	{
	  'name': 'bookings',
	  'description': 'Operations around Scheduling a Recipe'
	},
	{
	  'name': 'user',
	  'description': 'Operations about the User'
	},
	{
	  'name': 'server',
	  'description': 'Operations about the server'
	}
  ],
  'servers': [
	{
	  'url': 'http://localhost:3500'
	},
	{
	  'url': 'https://virtserver.swaggerhub.com/ianoxwell/CookBook/1.0.0'
	}
  ],
  'components': {
	'responses': {
	  'NotFound': {
		'description': 'The specified resource was not found',
		'content': {
		  'application/json': {
			'schema': {
			  '$ref': '#/components/schemas/Error'
			}
		  }
		}
	  },
	  'Unauthorized': {
		'description': 'Unauthorized',
		'content': {
		  'application/json': {
			'schema': {
			  '$ref': '#/components/schemas/Error'
			}
		  }
		}
	  }
	},
	'schemas': {
	  'bookings': {
		'type': 'array',
		'items': {
		  '$ref': '#/components/schemas/booking'
		}
	  },
	  'booking': {
		'type': 'object',
		'x-swagger-mongoose': {
		  'schema-options': {
			'timestamps': true
		  }
		},
		'properties': {
		  '_id': {
			'type': 'string',
			'readOnly': true
		  },
		  'recipe': {
			'type': 'object',
			'properties': {
			  'recipe_id': {
				'type': 'string'
			  },
			  'name': {
				'type': 'string',
				'example': 'Chocolate Brownies',
				'description': 'Name of the recipe'
			  }
			}
		  },
		  'timeBooked': {
			'type': 'string',
			'format': 'date-time',
			'description': 'time and date recipe is booked for',
			'x-swagger-mongoose': {
			  'index': 'true'
			}
		  },
		  'schoolName': {
			'type': 'string',
			'example': 'Holy Cross College',
			'description': 'Name of the college to assist in search'
		  },
		  'periodBooked': {
			'type': 'string',
			'example': 'P2',
			'description': 'completing this field disables timeBooked and autopopulates it depending on weekly timetable'
		  },
		  'teachersName': {
			'type': 'object',
			'description': 'With link to real user so we can leverage email',
			'properties': {
			  'teachers_id': {
				'type': 'string'
			  },
			  'fullname': {
				'type': 'string',
				'example': 'James Jameson',
				'description': 'To assist the food technician'
			  }
			}
		  },
		  'roomName': {
			'type': 'string',
			'example': 'FoodTech1',
			'description': 'Further clues as to where the recipe is being booked',
			'x-swagger-mongoose': {
			  'index': 'true'
			}
		  },
		  'studentGroupName': {
			'type': 'string',
			'example': '08Food02',
			'description': 'Future addition of classes linked to teachers maybe?'
		  },
		  'prepNotes': {
			'type': 'string',
			'example': 'The dough for the pizza will need to be let sit to rise 30 min before class',
			'description': 'Notes for the Food technician'
		  }
		}
	  },
	  'conversion': {
		'type': 'object',
		'properties': {
		  '_id': {
			'type': 'string',
			'readOnly': true
		  },
		  'measureA': {
			'type': 'string',
			'example': 'weight or volume or each'
		  },
		  'stateA': {
			'type': 'string',
			'example': 'each or whole'
		  },
		  'quantityA': {
			'type': 'number',
			'example': 1.5,
			'description': 'fractional measurement'
		  },
		  'measureB': {
			'type': 'string',
			'example': 'weight or volume or each'
		  },
		  'stateB': {
			'type': 'string',
			'example': 'grated, sliced, shredded'
		  },
		  'quantityB': {
			'type': 'number',
			'example': 1.5,
			'description': 'fractional measurement'
		  },
		  'preference': {
			'type': 'number',
			'minimum': 0,
			'maximum': 10,
			'description': 'eg flour is usually purchased in kg and used in cups (volume)'
		  }
		}
	  },
	  'price': {
		'required': [
		  'price',
		  'quantity'
		],
		'type': 'object',
		'properties': {
		  '_id': {
			'type': 'string',
			'readOnly': true
		  },
		  'brandName': {
			'type': 'string',
			'example': 'Black and Gold'
		  },
		  'price': {
			'type': 'number',
			'example': 1.95,
			'minimum': 0
		  },
		  'quantity': {
			'type': 'number',
			'example': 1.5,
			'minimum': 0
		  },
		  'measurement': {
			'type': 'string',
			'example': 'kg'
		  },
		  'storeName': {
			'type': 'string',
			'example': 'Coles'
		  },
		  'lastChecked': {
			'type': 'string',
			'format': 'date-time'
		  },
		  'apiLink': {
			'type': 'string',
			'example': 'link to Coles or Woolworths API to update prices more regularly'
		  }
		}
	  },
	  'ingredients': {
		'type': 'array',
		'items': {
		  '$ref': '#/components/schemas/ingredient'
		}
	  },
	  'ingredient': {
		'required': [
		  'name'
		],
		'type': 'object',
		'x-swagger-mongoose': {
		  'schema-options': {
			'timestamps': true
		  }
		},
		'properties': {
		  '_id': {
			'type': 'string',
			'readOnly': true
		  },
		  'name': {
			'type': 'string',
			'example': 'Self-raising flour',
			'x-swagger-mongoose': {
			  'index': 'true',
			  'unique': 'true'
			}
		  },
		  'parent': {
			'type': 'string',
			'example': 'Flour'
		  },
		  'allergies': {
			'type': 'array',
			'items': {
			  'type': 'string',
			  'example': 'nuts, gluten'
			}
		  },
		  'purchasedBy': {
			'type': 'string',
			'description': 'purchased by weight, volume or individual',
			'enum': [
			  'weight',
			  'volume',
			  'individual',
			  'bunch'
			]
		  },
		  'averagePrice': {
			'type': 'array',
			'description': 'The min and max',
			'items': {
			  'type': 'number'
			}
		  },
		  'prices': {
			'type': 'array',
			'description': 'Various prices for different brands and sizes',
			'items': {
			  '$ref': '#/components/schemas/price'
			}
		  },
		  'conversions': {
			'type': 'array',
			'description': 'Conversion numbers from volume to weight etc',
			'items': {
			  '$ref': '#/components/schemas/conversion'
			}
		  },
		  'links': {
			'$ref': '#/components/schemas/apiLinks'
		  }
		}
	  },
	  'history': {
		'type': 'object',
		'x-swagger-mongoose': {
		  'schema-options': {
			'timestamps': true
		  }
		},
		'properties': {
		  '_id': {
			'type': 'string',
			'readOnly': true
		  },
		  'eventDate': {
			'type': 'string',
			'format': 'date-time'
		  },
		  'event': {
			'type': 'string',
			'description': 'event that occurred edit, booked, favourited, created',
			'example': 'edit'
		  },
		  'changeKey': {
			'type': 'string',
			'description': 'used in an update',
			'example': 'recipeId'
		  },
		  'changeFrom': {
			'type': 'string',
			'description': 'used in an update',
			'example': '123abc3'
		  },
		  'changeTo': {
			'type': 'string',
			'description': 'used in an update',
			'example': '123abcd'
		  },
		  'userName': {
			'type': 'string',
			'description': 'polite name of user',
			'example': 'Bob Bobbin'
		  }
		}
	  },
	  'picture': {
		'type': 'object',
		'required': [
		  'fileLink'
		],
		'properties': {
		  '_id': {
			'type': 'string',
			'readOnly': true
		  },
		  'fileId': {
			'type': 'string',
			'description': 'if using GridFS - optional field'
		  },
		  'title': {
			'type': 'string',
			'description': 'if none provided - use the recipe name - to populate the alt text of an img'
		  },
		  'fileLink': {
			'type': 'string',
			'description': 'pure URL location or file_id string if using GridFS'
		  },
		  'positionPic': {
			'type': 'string',
			'description': 'top (banner), left (float left) or right (float right)',
			'example': 'left'
		  }
		}
	  },
	  'ingredientList': {
		'type': 'object',
		'required': [
		  'ingredientID',
		  'ingredientName'
		],
		'properties': {
		  '_id': {
			'type': 'string',
			'readOnly': true
		  },
		  'ingredientId': {
			'type': 'string',
			'description': 'The mongo ID of the ingredient to use'
		  },
		  'ingredientName': {
			'type': 'string',
			'example': 'Self Raising Flour'
		  },
		  'quantity': {
			'type': 'number',
			'description': 'if stored as 0.5, 0.75 convert to symbol / fraction when displaying - 0.66 = 1/3',
			'example': 1.5
		  },
		  'unit': {
			'type': 'string',
			'description': 'pinch, cup, kg, grams etc',
			'example': 'cup'
		  },
		  'state': {
			'type': 'string',
			'description': 'each or whole, sliced, shredded, blank',
			'example': 'lightly packed'
		  },
		  'text': {
			'type': 'string',
			'description': 'optional field to replace ingredient name - not used in any calculations'
		  },
		  'allergies': {
			'type': 'array',
			'items': {
			  'type': 'string'
			}
		  },
		  'preference': {
			'type': 'number',
			'minimum': 0,
			'maximum': 50,
			'default': 0,
			'description': 'to order / shift around the ingredients'
		  },
		  'links': {
			'$ref': '#/components/schemas/apiLinks'
		  }
		}
	  },
	  'recipes': {
		'type': 'array',
		'items': {
		  '$ref': '#/components/schemas/recipe'
		}
	  },
	  'recipe': {
		'type': 'object',
		'x-swagger-mongoose': {
		  'schema-options': {
			'timestamps': true
		  }
		},
		'required': [
		  'name',
		  'method'
		],
		'properties': {
		  '_id': {
			'type': 'string',
			'readOnly': true
		  },
		  'name': {
			'type': 'string',
			'description': 'unique name of the recipe',
			'x-swagger-mongoose': {
			  'index': 'true',
			  'unique': 'true'
			}
		  },
		  'teaser': {
			'type': 'string',
			'description': 'short text description'
		  },
		  'numberOfServings': {
			'type': 'number',
			'description': 'Number of people or servings the recipe will make',
			'default': 1,
			'minimum': 1
		  },
		  'priceEstimate': {
			'type': 'number',
			'description': 'calculated field from average prices',
			'default': 0,
			'minimum': 0
		  },
		  'priceServing': {
			'type': 'number',
			'default': 0,
			'minimum': 0,
			'description': 'calculated field of price / number of servings'
		  },
		  'ingredientLists': {
			'type': 'array',
			'items': {
			  '$ref': '#/components/schemas/ingredientList'
			}
		  },
		  'equipmentRequired': {
			'type': 'array',
			'items': {
			  'type': 'string',
			  'example': 'mixer'
			}
		  },
		  'prepTime': {
			'type': 'number',
			'description': 'amount of time in minutes to prepare everything estimate'
		  },
		  'cookTime': {
			'type': 'number',
			'description': 'amount of time in minutes to cook the recipe'
		  },
		  'method': {
			'type': 'string',
			'description': 'string can be very long it appears'
		  },
		  'recipeType': {
			'type': 'array',
			'items': {
			  'type': 'string'
			},
			'description': 'more than one type possible - breakfast, lunch, dinner snack, sauce, base'
		  },
		  'healthLabels': {
			'type': 'array',
			'items': {
			  'type': 'string'
			},
			'description': 'low sugar, paleo, sugar free'
		  },
		  'cuisineType': {
			'type': 'array',
			'items': {
			  'type': 'string'
			},
			'description': 'mexican, chinese, european, tudor, etc'
		  },
		  'createdByUser': {
			'type': 'object',
			'properties': {
			  'userID': {
				'type': 'string',
				'description': 'used to search through with a name change; also search for user profile on click then nagivateTo'
			  },
			  'userName': {
				'type': 'string',
				'description': 'polite name reference',
				'example': 'Bob Bobin'
			  },
			  'link': {
				'type': 'string',
				'description': 'api link to the user profile'
			  }
			}
		  },
		  'sourceOfRecipe': {
			'type': 'string',
			'description': 'eg CWA Cookbook 2015 or student/teacher/import created or website url'
		  },
		  'picture': {
			'$ref': '#/components/schemas/picture'
		  },
		  'history': {
			'type': 'array',
			'description': 'all the events that occur for the recipe - ie created, edited, booked etc',
			'items': {
			  '$ref': '#/components/schemas/history'
			}
		  },
		  'links': {
			'$ref': '#/components/schemas/apiLinks'
		  }
		}
	  },
	  'users': {
		'type': 'array',
		'items': {
		  '$ref': '#/components/schemas/user'
		}
	  },
	  'user': {
		'type': 'object',
		'x-swagger-mongoose': {
		  'schema-options': {
			'timestamps': true
		  }
		},
		'properties': {
		  '_id': {
			'type': 'string',
			'readOnly': true
		  },
		  'firstName': {
			'type': 'string',
			'example': 'Bob'
		  },
		  'lastName': {
			'type': 'string',
			'example': 'Bobbin'
		  },
		  'fullName': {
			'type': 'string',
			'example': 'Bob Bobbin',
			'description': 'calculated / constructed field'
		  },
		  'email': {
			'type': 'string',
			'example': 'bob@bob.com',
			'format': 'email',
			'x-swagger-mongoose': {
			  'index': 'true',
			  'unique': 'true'
			}
		  },
		  'password': {
			'type': 'string',
			'format': 'password',
			'example': 'abc123'
		  },
		  'role': {
			'type': 'string',
			'description': 'Role taken by user - student, teacher, admin, assistant',
			'example': 'teacher'
		  },
		  'school': {
			'type': 'string',
			'description': 'What school the user is at',
			'example': 'Holy Cross College'
		  },
		  'teacher': {
			'type': 'string',
			'description': 'if a student do they have a teacher - reference to userID',
			'example': 'userIDofTeacher123'
		  },
		  'favouritedRecipes': {
			'type': 'array',
			'items': {
			  'type': 'string'
			}
		  },
		  'subscriptionStatus': {
			'type': 'string',
			'description': 'Status of subscription to service',
			'example': 'expired'
		  },
		  'userStatus': {
			'type': 'number',
			'description': 'User Status',
			'format': 'int32'
		  }
		}
	  },
	  'apiLinks': {
		'type': 'object',
		'properties': {
		  'self': {
			'type': 'string',
			'description': 'direct api link to the ingredient - get',
			'example': '/api/v1/ingredient/123abc'
		  },
		  'parent': {
			'type': 'string',
			'description': 'direct api link to the recipe Schema or to recipe type or to parent of the ingredient - ie flour',
			'example': '/api/v1/recipes/breakfast'
		  }
		}
	  },
	  'suggestion': {
		'type': 'object',
		'properties': {
		  '_id': {
			'type': 'string'
		  },
		  'name': {
			'type': 'string',
			'example': 'Self Raising Flour'
		  }
		}
	  },
	  'Error': {
		'type': 'object',
		'properties': {
		  'statusCode': {
			'type': 'number',
			'example': 404
		  },
		  'error': {
			'type': 'string',
			'example': 'Not Found'
		  },
		  'message': {
			'type': 'string',
			'example': 'Unable to find matching ID'
		  }
		},
		'required': [
		  'statusCode',
		  'error',
		  'message'
		]
	  }
	},
	'securitySchemes': {
	  'oAuth2AuthCode': {
		'type': 'oauth2',
		'flows': {
		  'authorizationCode': {
			'authorizationUrl': '/oauth/authorize',
			'tokenUrl': '/oauth/token',
			'scopes': {
			  'admin': 'Allows read and write to all fields',
			  'teacher': 'Allows read and write to all but admin reserved',
			  'student': 'Only allows read except personal recipes and some user details',
			  'self': 'User only allowed to edit own user profile'
			}
		  }
		}
	  }
	}
  }
};
