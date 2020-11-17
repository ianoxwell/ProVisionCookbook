using Pcb.Dto.Reference;
using System;

namespace Pcb.Dto.Ingredient
{
	public class RawFoodDto
	{
		public int Id { get; set; }
		public int UsdaFoodId { get; set; }
		public string Name { get; set; }
		public int? Calories { get; set; }
		public int? PralScore { get; set; }

		public NutritionFactsDto NutritionFacts { get; set; }
		public CommonMineralsDto CommonMinerals { get; set; }
		public CommonVitaminsDto CommonVitamins { get; set; }

		public byte[] RowVer { get; set; }


		public DateTimeOffset CreatedAt { get; set; }
		public ReferenceItemEx FoodGroup { get; set; }
	}
}
