using Pcb.Database.Context.Models;
using Pcb.Dto.Ingredient;
using Pcb.Dto.Reference;
using Pcb.Mapping.Interface;
using System;

namespace Pcb.Mapping.Implementation
{
	public class RawFoodMapper : IRawFoodMapper
	{
		public ReferenceItemEx MapIngredientFoodGroupToDto(IngredientFoodGroup map)
		{
			if (map == null) { return null; }
			return new ReferenceItemEx
			{
				Id = map.Id,
				Title = map.Title,
				Summary = map.Summary,
				Symbol = map.Symbol,
				RowVer = map.RowVer,
				SortOrder = null,
				CreatedAt = map.CreatedAt
			};
		}

		public RawFoodDto MapRawFoodUsdaToDto(RawFoodUsda ingredientObj)
		{
			if (ingredientObj == null) { return null; }
			return new RawFoodDto
			{
				Id = ingredientObj.Id,
				UsdaFoodId = ingredientObj.UsdaFoodId,
				Name = ingredientObj.Name,
				Calories = ingredientObj.Calories,
				PralScore = ingredientObj.PralScore,
				NutritionFacts = new NutritionFactsDto
				{
					TotalFat = ingredientObj.Fat,
					SaturatedFat = ingredientObj.SaturatedFat,
					TransFat = ingredientObj.TransFattyAcids,
					Omega3s = ingredientObj.Omega3s,
					Omega6s = ingredientObj.Omega6s,
					Omega3to6Ratio = ingredientObj.Omega6s > 0 ? Math.Round(d: ingredientObj.Omega3s / ingredientObj.Omega6s, 2) : 0,
					MonoUnsaturatedFat = ingredientObj.FattyAcidsTotalMonounsaturated,
					PolyUnsaturatedFat = ingredientObj.FattyAcidsTotalPolyunsaturated,
					Cholesterol = ingredientObj.Cholesterol,
					TotalCarbohydrate = ingredientObj.Carbohydrate,
					DietaryFiber = ingredientObj.Fiber,
					TotalSugars = ingredientObj.Sugars,
					Protein = ingredientObj.Protein,
					Water = ingredientObj.Water
				},
				CommonMinerals = new CommonMineralsDto
				{
					Calcium = ingredientObj.Calcium,
					IronFe = ingredientObj.IronFe,
					PotassiumK = ingredientObj.PotassiumK,
					Sodium = ingredientObj.Sodium,
					Magnesium = ingredientObj.Magnesium,
					ZincZn = ingredientObj.ZincZn,
					CopperCu = ingredientObj.CopperCu,
					Manganese = ingredientObj.Manganese,
					SeleniumSe = ingredientObj.SeleniumSe,
					FluorideF = ingredientObj.FluorideF
				},
				CommonVitamins = new CommonVitaminsDto
				{
					VitaminAIu = ingredientObj.VitaminAIu,
					VitaminARae = ingredientObj.VitaminARae,

					ThiaminB1 = ingredientObj.ThiaminB1,
					RiboflavinB2 = ingredientObj.RiboflavinB2,
					NiacinB3 = ingredientObj.NiacinB3,
					PantothenicAcidB5 = ingredientObj.PantothenicAcidB5,
					VitaminB6 = ingredientObj.VitaminB6,
					FolateB9 = ingredientObj.FolateB9,
					VitaminB12 = ingredientObj.VitaminB12,

					VitaminC = ingredientObj.VitaminC,
					VitaminD = ingredientObj.VitaminD,
					VitaminDIu = ingredientObj.VitaminDIu,
					VitaminE = ingredientObj.VitaminE,
					VitaminK = ingredientObj.VitaminK,

					FolateDfe = ingredientObj.FolateDfe,
					FolicAcid = ingredientObj.FolicAcid,
					FoodFolate = ingredientObj.FoodFolate,
				},

				RowVer = ingredientObj.RowVer,
				CreatedAt = ingredientObj.CreatedAt,
				FoodGroup = MapIngredientFoodGroupToDto(ingredientObj.FoodGroup)
			};
		}


		public RawFoodUsda MapDtoToRawFoodUsda(RawFoodDto dto)
		{
			if (dto == null) { return null; }
			return new RawFoodUsda
			{
				Id = dto.Id,
				UsdaFoodId = dto.UsdaFoodId,
				Name = dto.Name,
				Calories = dto.Calories,
				PralScore = dto.PralScore,

				// Nutrition Facts
				Protein = dto.NutritionFacts.Protein,
				Fat = dto.NutritionFacts.TotalFat,
				Carbohydrate = dto.NutritionFacts.TotalCarbohydrate,
				Water = dto.NutritionFacts.Water,
				SaturatedFat = dto.NutritionFacts.SaturatedFat,
				TransFattyAcids = dto.NutritionFacts.TransFat,
				Omega3s = dto.NutritionFacts.Omega3s,
				Omega6s = dto.NutritionFacts.Omega6s,
				FattyAcidsTotalMonounsaturated = dto.NutritionFacts.MonoUnsaturatedFat,
				FattyAcidsTotalPolyunsaturated = dto.NutritionFacts.PolyUnsaturatedFat,
				Cholesterol = dto.NutritionFacts.Cholesterol,
				Fiber = dto.NutritionFacts.DietaryFiber,
				Sugars = dto.NutritionFacts.TotalSugars,

				// Minerals
				Calcium = dto.CommonMinerals.Calcium,
				IronFe = dto.CommonMinerals.IronFe,
				PotassiumK = dto.CommonMinerals.PotassiumK,
				Sodium = dto.CommonMinerals.Sodium,
				Magnesium = dto.CommonMinerals.Magnesium,
				ZincZn = dto.CommonMinerals.ZincZn,
				CopperCu = dto.CommonMinerals.CopperCu,
				Manganese = dto.CommonMinerals.Manganese,
				SeleniumSe = dto.CommonMinerals.SeleniumSe,
				FluorideF = dto.CommonMinerals.FluorideF,

				// Common Vitamins
				VitaminAIu = dto.CommonVitamins.VitaminAIu,
				VitaminARae = dto.CommonVitamins.VitaminARae,

				ThiaminB1 = dto.CommonVitamins.ThiaminB1,
				RiboflavinB2 = dto.CommonVitamins.RiboflavinB2,
				NiacinB3 = dto.CommonVitamins.NiacinB3,
				PantothenicAcidB5 = dto.CommonVitamins.PantothenicAcidB5,
				VitaminB6 = dto.CommonVitamins.VitaminB6,
				FolateB9 = dto.CommonVitamins.FolateB9,
				VitaminB12 = dto.CommonVitamins.VitaminB12,

				VitaminC = dto.CommonVitamins.VitaminC,
				VitaminD = dto.CommonVitamins.VitaminD,
				VitaminDIu = dto.CommonVitamins.VitaminDIu,
				VitaminE = dto.CommonVitamins.VitaminE,
				VitaminK = dto.CommonVitamins.VitaminK,

				FolateDfe = dto.CommonVitamins.FolateDfe,
				FolicAcid = dto.CommonVitamins.FolicAcid,
				FoodFolate = dto.CommonVitamins.FoodFolate,

				FoodGroupId = dto.FoodGroup.Id,
			};
		}


	}
}
