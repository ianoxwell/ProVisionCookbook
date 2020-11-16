using Pcb.Common.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace Pcb.Database.Context.Models
{
	[Table("Ingredient", Schema = "dbo")]
	public partial class Ingredient
	{
		public int Id { get; set; }
		public int? UsdaFoodId { get; set; }
		[Required]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public string Name { get; set; }
		public string LinkUrl { get; set; }
		public MeasurementType? PurchasedBy { get; set; }
		public int? Calories { get; set; }
		[Column(TypeName = "decimal(18,3)")]
		public int? PralScore { get; set; }
		[Column(TypeName = "decimal(18,2)")]
		public int? Fat { get; set; }
		[Column(TypeName = "decimal(18,2)")]
		public int? Protein { get; set; }
		[Column(TypeName = "decimal(18,2)")]
		public int? Carbohydrate { get; set; }
		public int? NetCarbs { get; set; }
		[Column(TypeName = "decimal(18,2)")]
		public int? Sugars { get; set; }
		[Column(TypeName = "decimal(18,2)")]
		public int? Water { get; set; }
		[Column(TypeName = "decimal(18,2)")]
		public int? Fiber { get; set; }
		public int? Cholesterol { get; set; }
		[Column(TypeName = "decimal(18,3)")]
		public int? SaturatedFat { get; set; }
		[Column(TypeName = "decimal(18,2)")]

		public int Omega3s { get; set; }
		public int Omega6s { get; set; }

		[Column(TypeName = "decimal(18,3)")]
		public int? TransFattyAcids { get; set; }
		public int? FattyAcidsTotalMonounsaturated { get; set; }
		public int? FattyAcidsTotalPolyunsaturated { get; set; }
		public int? FattyAcidsTotalTransMonoenoic { get; set; }
		public int? FattyAcidsTotalTransPolyenoic { get; set; }

		/// <summary>
		/// Minerals
		/// </summary>
		[Column(TypeName = "decimal(18,2)")]

		public int? Calcium { get; set; }
		public int? IronFe { get; set; }
		public int? PotassiumK { get; set; }
		public int? Magnesium { get; set; }
		public int? Sodium { get; set; }
		[Column(TypeName = "decimal(18,2)")]
		public int? ZincZn { get; set; }
		[Column(TypeName = "decimal(18,2)")]
		public int? CopperCu { get; set; }
		[Column(TypeName = "decimal(18,2)")]
		public int? Manganese { get; set; }
		[Column(TypeName = "decimal(18,2)")]
		public int? SeleniumSe { get; set; }
		[Column(TypeName = "decimal(18,2)")]
		public int? FluorideF { get; set; }

		/// <summary>
		/// Vitamins
		/// </summary>
		public int? VitaminAIu { get; set; }
		public int? VitaminARae { get; set; }
		[Column(TypeName = "decimal(18,1)")]
		public int? VitaminC { get; set; }
		[Column(TypeName = "decimal(18,2)")]
		public int? VitaminB12 { get; set; }
		[Column(TypeName = "decimal(18,2)")]
		public int? VitaminD { get; set; }
		[Column(TypeName = "decimal(18,2)")]
		public int? VitaminE { get; set; }
		[Column(TypeName = "decimal(18,3)")]
		public int? ThiaminB1 { get; set; }
		[Column(TypeName = "decimal(18,3)")]
		public int? RiboflavinB2 { get; set; }
		[Column(TypeName = "decimal(18,3)")]
		public int? NiacinB3 { get; set; }
		[Column(TypeName = "decimal(18,3)")]
		public int? PantothenicAcidB5 { get; set; }
		[Column(TypeName = "decimal(18,3)")]
		public int? VitaminB6 { get; set; }
		public int? FolateB9 { get; set; }
		public int? FolicAcid { get; set; }
		public int? FoodFolate { get; set; }
		public int? FolateDfe { get; set; }
		public int? VitaminDIu { get; set; }
		[Column(TypeName = "decimal(18,2)")]
		public int? VitaminK { get; set; }


		/// <summary>
		/// Sugars
		/// </summary>
		[Column(TypeName = "decimal(18,2)")]
		public int? Sucrose { get; set; }
		[Column(TypeName = "decimal(18,2)")]
		public int? GlucoseDextrose { get; set; }
		[Column(TypeName = "decimal(18,2)")]
		public int? Fructose { get; set; }
		[Column(TypeName = "decimal(18,2)")]
		public int? Lactose { get; set; }
		[Column(TypeName = "decimal(18,2)")]
		public int? Maltose { get; set; }
		[Column(TypeName = "decimal(18,2)")]
		public int? Galactose { get; set; }
		public int? Starch { get; set; }
		public int? PhosphorusP { get; set; }




		public int? Alcohol { get; set; }
		public int? Caffeine { get; set; }
		public int? Theobromine { get; set; }

		/// <summary>
		/// Serving descriptions
		/// </summary>
		[Column(TypeName = "decimal(18,2)")]
		public int? ServingWeight1 { get; set; }
		public string ServingDescription1 { get; set; }
		[Column(TypeName = "decimal(18,2)")]
		public int? ServingWeight2 { get; set; }
		public string ServingDescription2 { get; set; }
		[Column(TypeName = "decimal(18,3)")]
		public int? CalorieWeight200 { get; set; }



		/// <summary>
		/// Price Section
		/// </summary>
		public string PriceBrandName { get; set; }
		[Column(TypeName = "decimal(18,2)")]
		[DataType(DataType.Currency)]
		public decimal? PriceDollar { get; set; }
		[Column(TypeName = "decimal(18,2)")]
		public decimal? PriceQuantity { get; set; }
		public MeasurementType? PriceMeasurement { get; set; }
		public string PriceStoreName { get; set; }
		[AllowNull]
		public string PriceApiLink { get; set; }
		public int? FoodGroupId { get; set; }
		public int? IngredientStateId { get; set; }


		[Timestamp]
		public byte[] RowVer { get; set; }


		public DateTimeOffset CreatedAt { get; set; }
		public IngredientFoodGroup FoodGroup { get; set; }
		public ICollection<IngredientConversion> IngredientConversions { get; set; }
		public ICollection<IngredientAllergyWarning> IngredientAllergyWarning { get; set; }
		public ICollection<RecipeIngredientList> RecipeIngredientList { get; set; }
	}
}
