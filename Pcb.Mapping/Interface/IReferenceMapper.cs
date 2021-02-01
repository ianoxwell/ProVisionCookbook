using Pcb.Database.Context.Models;
using Pcb.Dto.Reference;

namespace Pcb.Mapping.Interface
{
    public interface IReferenceMapper
    {
        AllergyWarning MapRefToAllergyWarning(ReferenceItemEx dto);
        CuisineType MapRefToCuisineType(ReferenceItemEx dto);
        DishTag MapRefToDishTag(ReferenceItemEx dto);
        DishType MapRefToDishType(ReferenceItemEx dto);
        Equipment MapRefToEquipment(ReferenceItemEx dto);
        HealthLabel MapRefToHealthLabel(ReferenceItemEx dto);
        IngredientFoodGroup MapRefToIngredientFoodGroup(ReferenceItemEx dto);
        IngredientState MapRefToIngredientState(ReferenceItemEx dto);
        LogLevel MapRefToLogLevel(ReferenceItemEx dto);
        PermissionGroup MapRefToPermissionGroup(ReferenceItemEx dto);

        MeasurementUnit MapRefToMeasurementUnit(ReferenceItemMeasurement dto);
    }
}
