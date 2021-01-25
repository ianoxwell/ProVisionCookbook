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
	IngredientFoodGroup,
	IngredientState,
	LogLevel,
	PermissionGroup
}

export enum ReferenceDetail {
	Basic = 1,
	Full
}

export interface ReferenceItem { id: number; title: string; }
export interface ReferenceItemFull extends ReferenceItem {
	symbol: string;
	summary: string;
	sortOrder: number;
	createdAt: Date;
	rowVer: string;
}

/**
 * Note in alphabetical order - add to when references change
 */
export interface ReferenceAll {
	AllergyWarning?: ReferenceItemFull[];
	CuisineType?: ReferenceItemFull[];
	DishTag?: ReferenceItemFull[];
	DishType?: ReferenceItemFull[];
	HealthLabel?: ReferenceItemFull[];
	IngredientFoodGroup?: ReferenceItemFull[];
	IngredientState?: ReferenceItemFull[];
	LogLevel?: ReferenceItemFull[];
	PermissionGroup?: ReferenceItemFull[];
}