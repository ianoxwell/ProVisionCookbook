using Pcb.Common.Enums;
using Pcb.Dto.Recipes;
using Pcb.Dto.Reference;
using System;
using System.Collections.Generic;

namespace Pcb.Dto.Ingredient
{
	public class IngredientDto
	{
		public int Id { get; set; }
		public int? UsdaFoodId { get; set; }
		public string Name { get; set; }
		public string LinkUrl { get; set; }
		public int? PralScore { get; set; }
		public MeasurementType? PurchasedBy { get; set; }

		public PriceDto Price { get; set; }
		public NutritionFactsDto NutritionFacts { get; set; }
		public CommonMineralsDto CommonMinerals { get; set; }
		public CommonVitaminsDto CommonVitamins { get; set; }

		public byte[] RowVer { get; set; }


		public DateTimeOffset CreatedAt { get; set; }
		public int? ParentId { get; set; }
		public ReferenceItemEx FoodGroup { get; set; }
		public int? IngredientStateId { get; set; } // spoonacular field consistency e.g. solid
		public List<ReferenceItemEx> Allergies { get; set; }
		public List<IngredientConversionDto> IngredientConversions { get; set; }
		public List<ShortRecipeDto> Recipes { get; set; }
	}
}
