using Pcb.Database.Context.Models;
using Pcb.Dto.Ingredient;
using Pcb.Dto.Reference;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pcb.Mapping.Interface
{
	public interface IRawFoodMapper
	{
		ReferenceItemEx MapIngredientFoodGroupToDto(IngredientFoodGroup map);

		RawFoodDto MapRawFoodUsdaToDto(RawFoodUsda ingredientObj);

		RawFoodUsda MapDtoToRawFoodUsda(RawFoodDto dto);
	}
}
