namespace Pcb.Dto.Reference
{
    /// <summary>
    /// CPT reference types.
    /// Enum name must match context entity name.
    /// PLEASE
    /// - keep these in alpha order
    /// - sync changes to reference.models.ts
    /// </summary>
    public enum ReferenceType
    {        
        AllergyWarning = 1,
        CuisineType,
        DishTag,
        DishType,
        HealthLabel,
        IngredientParentType,
        IngredientState,
        LogLevel,
        PermissionGroup
    }
}
