using Pcb.Database.Context.Models;
using Pcb.Dto.Ingredient;
using Pcb.Dto.Reference;
using System.Collections.Generic;

namespace Pcb.Mapping.Interface
{
	public interface IIngredientMapper
	{
		ReferenceItemEx MapIngredientFoodGroupToDto(IngredientFoodGroup map);

		ReferenceItemMeasurement MapMeasurementToDto(MeasurementUnit measurementObj);
		ReferenceItemEx MapIngredientStateToDto(IngredientState map);
		List<ReferenceItemEx> MapAllergyWarningToList(IEnumerable<IngredientAllergyWarning> map);
		List<IngredientConversionDto> MapIngredientConversionToDtoList(IEnumerable<IngredientConversion> map);

		List<IngredientNutritionDto> MapNutritionListToDtoList(IEnumerable<IngredientNutrition> map);
		IngredientDto MapIngredientToDto(Ingredient ingredientObj);
		Ingredient MapDtoToIngredient(IngredientDto dto);
		Ingredient UpdateIngredientWithDto(Ingredient updateObj, IngredientDto dto);
	}
}
