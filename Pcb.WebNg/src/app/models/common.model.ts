/** Generic key/values */
export interface IDictionary<T> {
	[Key: string]: T;
}

export interface BaseDbModel {
	id: number;
	rowVer: string;
	createdAt: Date;
}

export interface Validations { type: string; message: string; }

export interface HourMin { hours: number; minutes: number; }

export interface IdValuePair { id: number | string; value: string | number; }
export interface IdTitlePair { id: number; title: string; }



export interface IngredientPaginator {
	previousPageIndex: number;
	pageIndex: number;
	pageSize: number;
	length: number;
	active?: string;
	direction?: 'asc' | 'desc';
	filter?: string;
}

export interface PagedResult<T> {
	items: T[];
	totalCount: number;
}

export class MessageResult {
	message: string;
	constructor(message: string) {
		this.message = message;
	}
}

export interface IngredientFilterObject {
	name: string;
	type: string[];
	parent: string;
	allergies: string[];
	purchasedBy: string;
}
export interface ISortPageObj {
	sort: string;
	order: string;
	filter?: string;
	pageIndex: number;
	pageSize: number;
}

export class SortPageObj implements ISortPageObj {
	sort = 'name';
	order = 'asc';
	pageIndex = 0;
	pageSize = 25;
	constructor() {}
}

export interface AdminRights {
	globalAdmin: boolean;
	schoolAdmin: IdTitlePair[];
}

export interface IValidationMessages {
	[key: string]: {
		type: string;
		message: string;
	}[];
}

/* Section Enums
 */

export enum CountryCode
{
	AU,
	US,
	ALL
}

export enum MeasurementType
{
	Volume,
	Weight,
	Item
}

export enum NutritionUnit
{
	g,
	mg,
	cal
}

export enum PicturePosition
{
	top,
	left,
	right
}
