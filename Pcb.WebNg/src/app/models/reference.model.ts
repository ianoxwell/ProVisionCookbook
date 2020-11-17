/**
 * MET reference types.
 * Enum name must match context entity name.
 * PLEASE:
 * - keep these in alpha order
 * - sync changes to ReferenceType.cs (it's in MET.Dto)
 */
export enum ReferenceType {
	AllergyWarning = 1,
	CuisineType,
	DishTag,
	DishType,
	HealthLabel,
	IngredientFoodType,
	IngredientState,
	LogLevel,
	PermissionGroup
}

export enum ReferenceDetail {
	Basic = 1,
	Full
}

export interface ReferenceItem { id: number | string; title: string; }
export interface ReferenceItemFull extends ReferenceItem {
	symbol: string;
	summary: string;
	sortOrder: number;
	createdAt: Date;
	rowVer: string;
}

export interface ReferenceAll {
	[key: string]: ReferenceItemFull[];
}