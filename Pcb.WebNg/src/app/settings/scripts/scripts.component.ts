import { Component, OnInit } from '@angular/core';
import { openAPIJSON, ApiNode } from './openapi';
import { isArray } from 'util';


@Component({
  selector: 'app-scripts',
  templateUrl: './scripts.component.html',
  styleUrls: ['./scripts.component.scss']
})
export class ScriptsComponent implements OnInit {
  tabs: { name: string; contents: string }[];
  private openAPI = openAPIJSON;

  public static capitaliseFirstLetter(word: string): string {
	return word.charAt(0).toUpperCase() + word.slice(1);
  }
  constructor(
	) { }

  queryOrParam(params: any): string {
	if (Array.isArray(params)) {
	  if (params[0].in === 'query') {
		if (params.length > 2) {
		  return `querystring: models.querySearch`;
		} else if (params.length > 1) {
		  return `querystring: models.queryKeyValue`;
		} else {
		  return `querystring: models.querySuggestion`;
		}
	  } else if (params[0].in === 'path') {
		if (params.length === 1) {
		  return `params: models.paramDocID`;
		} else if (params.length === 2) {
		  return `params: models.paramDocIDSub`;
		} else if (params.length === 3) {
		  return `params: models.paramDocIDSubSubD`;
		}
	  }
	}
	return 'Unknown - ERROR';
  }
  lastItem(item: string): string {
	if (item.indexOf('/') > 0) {
	  const splet = item.split('/');
	  return splet[splet.length - 1];
	}
	return item;
  }
  calculateBodySchema(body: any): string {
	if (body.hasOwnProperty('$ref')) {
	  return 'models.' + this.lastItem(body.$ref);
	} else if (body.hasOwnProperty('oneOf')) {
	  let retString = '';
	  body.oneOf.map(item => {
		console.log('item', item.$ref);
		retString += `models.${this.lastItem(item.$ref)} | `;
	  });
	  return retString.substring(0, retString.length - 3);
	}
	return 'Unknown - ERROR';
  }
  calculateResponseSchema(resp: any): string {
	if (resp.hasOwnProperty('$ref')) {
	  return this.lastItem(resp.$ref);
	} else if (resp.hasOwnProperty('items')) {
	  return this.lastItem(resp.items.$ref);
	}
	return 'Unknown - ERROR';
  }
  createRoutes(component: object): string {
	let routeString = `[`;
	const paths = Object.keys(component);
	const re = /{/g;
	const re2 = /}/g;
	// query strings - if the method is GET, in: query, if it has more than one object of array of paramaters then in it querySearch
	// if it only has only one then it is querySuggestion
	// if it is two then it is queryKeyValue
	// if it is in path then the response is params - which must be converted to type object with properties
	paths.map(path => {
	  const methods = Object.keys(component[path]);
	  methods.forEach(method => {
		routeString += `
		{
		  \t // summary: ${component[path][method].summary}
		  \t url: '${path.replace(re, ':').replace(re2, '')}',
		  \t method: '${method.toUpperCase()}',
		  \t schema: {`;
		if (component[path][method].hasOwnProperty('parameters')) {
		  routeString += `
			\t ${ this.queryOrParam(component[path][method].parameters)},`;
		}
		if (component[path][method].hasOwnProperty('requestBody')) {
		  // either 'application/json' has schema -> oneOf [{$ref:}] or schema -> $ref as children
		  routeString += `
			\t body: ${this.calculateBodySchema(component[path][method].requestBody.content['application/json'].schema)},`;
		}
		if (component[path][method].hasOwnProperty('responses')) {
		  routeString += `
			\t responses: {
			   \t 200: models.${this.calculateResponseSchema(component[path][method].responses['200'].content['application/json'].schema)},
			   \t 400: models.Error,
			   \t 401: models.Unauthorized,
			   \t 404: models.NotFound
			\t }
		  \t },`;
		}
		routeString += `
		 \t handler: controllers.${component[path][method].operationId}
		},`;
	  });
	});
	routeString += `
	]`;
	return routeString;
  }
  createHandlers(component: object): string {
	let routeString = ``;
	const paths = Object.keys(component);
	const re = /{/g;
	const re2 = /}/g;
	paths.map(path => {
	  Object.keys(component[path]).forEach(method => {
	  // for (const method in component[path]) {
		routeString += `
		  // summary: ${component[path][method].summary}
		  // tag: ${component[path][method].tags[0]}
		  exports.${component[path][method].operationId} = async (request, reply, next) => {
			try {
				reply
					.code(200)
					.header('Content-Type', 'application/json; charset=utf-8')
					.send({statusCode: 200, message: 'Not Complete yet'});
			} catch (err) {
				throw boom.boomify(err);
			}
		  };
`;
	  });
	});
	return routeString;
  }

  createSubSubArray(component: object): any {
	const newArray = []; // FoodNode = [{ name: 'blank', children: 'yes' }];
	// console.log('first', component);
	if (component.hasOwnProperty('type') || component.hasOwnProperty('content') ) {
	  // console.log('component', component);
	  return component;
	}
	Object.keys(component).forEach(key => {
	  newArray.push({
		name: key,
		children: component[key]
	  });
	});
	return newArray;
  }
  createSubArray(component: object): any {
	const newArray = []; // FoodNode = [{ name: 'blank', children: 'yes' }];
	Object.keys(component).forEach(key => {
	  newArray.push({
		name: key,
		children: this.createSubSubArray(component[key])
	  });
	});
	return newArray;
  }
  createArray(component: any): any {
	const newArray = []; // FoodNode = [{ name: 'blank', children: 'yes' }];
	Object.keys(component).forEach(key => {
	  newArray.push({
		name: key,
		children: this.createSubArray(component[key]),
	  });
	});
	return newArray;
  }
  createSchemaArray(component: any): any {
	const newArray = []; // FoodNode = [{ name: 'blank', children: 'yes' }];
	Object.keys(component).forEach(key => {
	  newArray.push({
		name: key,
		type: (component[key].type),
		properties: (component[key].properties),
	  });
	});
	return newArray;
  }
  createSchema(scheme: { name: string, type: string, properties: any }[]) {
	const newJSON = {};
	scheme.map(item => {
	  if (item.name === 'booking' || item.name === 'ingredient' || item.name === 'recipe' || item.name === 'user') {
		newJSON[item.name] = {
			type: 'object',
			properties: {
			  total: { type: 'number' },
			  items: {
				type: 'array',
				items: {
				  type: item.type,
				  properties: {}
				}
			  }
			}
		};
		Object.keys(item.properties).forEach(key => {
		// for (const key in item.properties) {
		  if (item.properties[key].hasOwnProperty('type')) {
			newJSON[item.name].properties.items.items.properties[key] = { 'type': item.properties[key].type };
			if (item.properties[key].type === 'array') {
			  if (item.properties[key].items.hasOwnProperty('type')) {
				newJSON[item.name].properties.items.items.properties[key].items = { 'type': item.properties[key].items.type };
			  } else if (item.properties[key].items.hasOwnProperty('$ref')) {
				newJSON[item.name].properties.items.items.properties[key].items = item.properties[key].items.$ref;
			  }
			}
		  } else if (item.properties[key].hasOwnProperty('$ref')) {
			newJSON[item.name].properties.items.items.properties[key] = item.properties[key].$ref;
		  }
		});
	  } else {
		newJSON[item.name] = {
		  type: item.type,
		  properties: {}
		};
		Object.keys(item.properties).forEach(key => {
		  if (item.properties[key].hasOwnProperty('type')) {
			newJSON[item.name].properties[key] = { 'type': item.properties[key].type };
			if (item.properties[key].type === 'array') {
			  if (item.properties[key].items.hasOwnProperty('type')) {
				newJSON[item.name].properties[key].items = { 'type': item.properties[key].items.type };
			  } else if (item.properties[key].items.hasOwnProperty('$ref')) {
				newJSON[item.name].properties[key].items = item.properties[key].items.$ref;
			  }
			}
		  } else if (item.properties[key].hasOwnProperty('$ref')) {
			newJSON[item.name].properties[key] = item.properties[key].$ref;
		  }
		});
	  }
	});
	console.log('result', newJSON);
	return newJSON;
  }

  checkArray(item: any): boolean {
	return (Array.isArray(item));
  }
  toJSON(obj: any): string {
	return JSON.stringify(obj);
  }
  matchType(type): string {
	const types = {
	  array: 'Array',
	  buffer: 'Buffer',
	  boolean: 'Boolean',
	  date: 'Date',
	  mixed: 'mongoose.Schema.Types.Mixed',
	  number: 'Number',
	  objectid: 'mongoose.Schema.ObjectId',
	  string: 'String',
	  object: 'Object'
	};
	if (type && type !== undefined && types[type.toLowerCase()]) {
	  return types[type.toLowerCase()];
	}
	return('unknown type ');
}
  createMongoose(schema: object): string {
	// todo add string enum when I find mongoose documentation
	const schemes = Object.keys(schema);
	let requiredItems = [];
	const moduleExports = [];
	let retString = `
'use strict';

const mongoose = require('mongoose');
`;
	schemes.map(item => {
	  if (schema[item].hasOwnProperty('required')) {
		requiredItems = schema[item].required;
	  }
	  if (schema[item].type === 'array') {
		moduleExports.push(item);
	  }
	  if (schema[item].type === 'object') {
		retString += `
const ${item}Schema = new mongoose.Schema({`;
		const props = Object.keys(schema[item].properties);
		props.map(prop => {
		  if (prop !== '_id') {
			retString += `
  ${prop}: `;
			// if property has a type declaration - else a $ref
			if (schema[item].properties[prop].hasOwnProperty('type')) {
			  // if property is a type array then the
			  if (schema[item].properties[prop].type === 'array') {
				if (schema[item].properties[prop].items.hasOwnProperty('$ref')) {
				  retString += `[ ${this.lastItem(schema[item].properties[prop].items.$ref)}Schema ],`;
				} else if (schema[item].properties[prop].items.hasOwnProperty('type')) {
				  retString += `[ ${this.matchType(schema[item].properties[prop].items.type)} ],`;
				}
			  } else {
				// check if the item is a date - Swagger defines a string with format date-time rather than type: date
				if (schema[item].properties[prop].hasOwnProperty('format') && schema[item].properties[prop].format === 'date-time') {
				  retString += `{ type: Date`;
				} else {
				  if (prop === 'preference') { console.log('preference', schema[item].properties[prop]); }
				  retString += `{ type: ${this.matchType(schema[item].properties[prop].type)}`;
				}

				// if required item
				if (requiredItems.indexOf(prop) > -1) {
				  retString += `, required: true`;
				}
				// minimum, maximum, default, x-swagger options
				if (schema[item].properties[prop].hasOwnProperty('minimum')) {
				  retString += `, min: ${schema[item].properties[prop].minimum}`;
				}
				if (schema[item].properties[prop].hasOwnProperty('maximum')) {
				  retString += `, max: ${schema[item].properties[prop].maximum}`;
				}
				if (schema[item].properties[prop].hasOwnProperty('default')) {
				  retString += `, default: ${schema[item].properties[prop].default}`;
				}
				if (schema[item].properties[prop].hasOwnProperty('x-swagger-mongoose')) {
				  if (schema[item].properties[prop]['x-swagger-mongoose'].hasOwnProperty('index')) {
					retString += `, index: true`;
				  }
				  if (schema[item].properties[prop]['x-swagger-mongoose'].hasOwnProperty('unique')) {
					retString += `, unique: true`;
				  }
				}
				retString += ` },`;
				if (schema[item].properties[prop].hasOwnProperty('description')) {
				  retString += ` // ${schema[item].properties[prop].description}`;
				}
			  }
			} else if (schema[item].properties[prop].hasOwnProperty('$ref')) {
			  retString += `${this.lastItem(schema[item].properties[prop].$ref)}Schema,`;
			}

		  }
		});
		// check if timestamps are required
		if (schema[item].hasOwnProperty('x-swagger-mongoose')) {
		  retString += `
 },
 { timestamps: true }
);`;
		} else {
		  retString += `
});
`;
		}
	  }
	});
	if (moduleExports.length > 0) {
	  retString += `
module.exports = {`;
	  moduleExports.map(item => {
		const shortString = item.substring(0, item.length - 1);
		retString += `
		${item}: mongoose.model('${ScriptsComponent.capitaliseFirstLetter(shortString)}', ${shortString}Schema,
		 '${ScriptsComponent.capitaliseFirstLetter(item)}'),`;
	  });
	  retString += `
}`;
	}
	return retString;
  }

  ngOnInit() {
	this.tabs = [
	{
		name: 'Controllers',
		contents: this.createHandlers(this.openAPI.paths)
	},
	{
		name: 'MongooseSchemas',
		contents: this.createMongoose(this.openAPI.components.schemas)
	},
	{
		name: 'RouteString',
		contents: this.createRoutes(this.openAPI.paths)
	},
	{
	name: 'openAPI',
	contents: JSON.stringify(this.openAPI.components.schemas, null, '\n')
	}, ];
}
}
