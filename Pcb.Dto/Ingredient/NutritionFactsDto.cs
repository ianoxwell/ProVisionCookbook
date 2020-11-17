namespace Pcb.Dto.Ingredient
{
	public class NutritionFactsDto
	{
		public int? Calories { get; set; }
		public int? TotalFat { get; set; }
		public int? SaturatedFat { get; set; }
		public int? MonoUnsaturatedFat { get; set; }
		public int? PolyUnsaturatedFat { get; set; }
		public int? TransFat { get; set; }
		public int Omega3s { get; set; }
		public int Omega6s { get; set; }
		public decimal? Omega3to6Ratio { get; set; }
		public int? Cholesterol { get; set; }
		public int? TotalCarbohydrate { get; set; }
		public int? DietaryFiber { get; set; }
		public int? TotalSugars { get; set; }
		public int? Protein { get; set; }
		public int? Water { get; set; }

	}
}
