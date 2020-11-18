using Pcb.Database.Context.Models;
using Pcb.Dto.Ingredient;
using Pcb.Dto.Recipes;
using Pcb.Dto.Reference;
using Pcb.Mapping.Interface;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Pcb.Mapping.Implementation
{
	public class IngredientMapper : IIngredientMapper
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
		public ReferenceItemEx MapIngredientStateToDto(IngredientState map)
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

		public ReferenceItemMeasurement MapMeasurementToDto(MeasurementUnit measurementObj)
		{
			if (measurementObj == null) { return null; }
			ReferenceItemMeasurement measurementUnit = new ReferenceItemMeasurement
			{
				Id = measurementObj.Id,
				Title = measurementObj.Title,
				MeasurementType = measurementObj.MeasurementType,
				ShortName = measurementObj.ShortName,
				AltShortName = measurementObj.AltShortName,
				ConvertsToId = measurementObj.ConvertsToId,
				Quantity = measurementObj.Quantity,
				CountryCode = measurementObj.CountryCode
			};
			return measurementUnit;
		}

		public List<ReferenceItemEx> MapAllergyWarningToList(IEnumerable<IngredientAllergyWarning> map)
		{
			if (map == null) { return null; }
			List<ReferenceItemEx> warningList = new List<ReferenceItemEx>();
			foreach (var warning in map.ToList())
			{
				warningList.Add(new ReferenceItemEx
				{
					Id = warning.AllergyWarning.Id,
					Title = warning.AllergyWarning.Title,
					Summary = warning.AllergyWarning.Summary,
					Symbol = warning.AllergyWarning.Symbol,
					RowVer = warning.AllergyWarning.RowVer,
					SortOrder = null,
					CreatedAt = warning.AllergyWarning.CreatedAt

				});

			}
			return warningList;
		}

		public List<IngredientConversionDto> MapIngredientConversionToDtoList(IEnumerable<IngredientConversion> map)
		{
			if (map == null) { return null; }
			List<IngredientConversionDto> convertList = new List<IngredientConversionDto>();
			foreach (var item in map.ToList())
			{

				convertList.Add(new IngredientConversionDto
				{
					Id = item.Id,
					IngredientId = item.IngredientId,
					BaseState = MapIngredientStateToDto(item.IngredientBaseConversionState),
					BaseMeasurementUnit = MapMeasurementToDto(item.MeasurementBaseUnit),
					BaseQuantity = item.BaseQuantity,
					ConvertToState = MapIngredientStateToDto(item.IngredientConvertConversionState),
					ConvertToMeasurementUnit = MapMeasurementToDto(item.MeasurementConvertUnit),
					ConvertToQuantity = item.ConvertToQuantity,
					RowVer = item.RowVer,
					CreatedAt = item.CreatedAt

				});
			}
			return convertList;
		}

		public IngredientDto MapIngredientToDto(Ingredient ingredientObj)
		{
			if (ingredientObj == null) { return null; }
			return new IngredientDto
			{
				Id = ingredientObj.Id,
				UsdaFoodId = ingredientObj.UsdaFoodId,
				Name = ingredientObj.Name,
				LinkUrl = ingredientObj.LinkUrl,
				PurchasedBy = ingredientObj.PurchasedBy,
				PralScore = ingredientObj.PralScore,
				IngredientStateId = ingredientObj.IngredientStateId,
				Price = new PriceDto()
				{
					BrandName = ingredientObj.PriceBrandName,
					Price = ingredientObj.PriceDollar,
					Quantity = ingredientObj.PriceQuantity,
					Measurement = ingredientObj.PriceMeasurement,
					StoreName = ingredientObj.PriceStoreName,
					ApiLink = ingredientObj.PriceApiLink,
				},
				NutritionFacts = new NutritionFactsDto
				{
					Calories = ingredientObj.Calories,
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
				FoodGroup = MapIngredientFoodGroupToDto(ingredientObj.FoodGroup),
				Allergies = MapAllergyWarningToList(ingredientObj.IngredientAllergyWarning),
				IngredientConversions = MapIngredientConversionToDtoList(ingredientObj.IngredientConversions),
				Recipes = MapRecipeToShortDto(ingredientObj.RecipeIngredientList)
			};
		}

		private List<ShortRecipeDto> MapRecipeToShortDto(IEnumerable<RecipeIngredientList> map)
		{
			if (map == null) { return null; }
			List<ShortRecipeDto> convertList = new List<ShortRecipeDto>();
			foreach (var item in map.ToList())
			{
				convertList.Add(new ShortRecipeDto()
				{
					Id = item.Recipe.Id,
					Name = item.Recipe.Name,
					Teaser = item.Recipe.Teaser,
				});
			}

			return convertList;
		}
		public Ingredient MapDtoToIngredient(IngredientDto dto)
		{
			if (dto == null) { return null; }
			return new Ingredient
			{
				Id = dto.Id,
				UsdaFoodId = dto.UsdaFoodId,
				Name = dto.Name,
				LinkUrl = dto.LinkUrl,
				PurchasedBy = dto.PurchasedBy,
				PralScore = dto.PralScore,
				IngredientStateId = dto.IngredientStateId,

				// Nutrition Facts
				Calories = dto.NutritionFacts.Calories,
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

				// Pricing
				PriceBrandName = dto.Price.BrandName,
				PriceDollar = dto.Price.Price,
				PriceQuantity = dto.Price.Quantity,
				PriceMeasurement = dto.Price.Measurement,
				PriceApiLink = dto.Price.ApiLink,
				PriceStoreName = dto.Price.StoreName,

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
				IngredientAllergyWarning = dto.Allergies.Select(x => MapDtoToIngredientAllergyWarningMapping(x, dto.Id)).ToList(),
				IngredientConversions = dto.IngredientConversions.Select(x => MapDtoToIngredientConversionMapping(x, dto.Id)).ToList(),
			};
		}

		public Ingredient UpdateIngredientWithDto(Ingredient updateObj, IngredientDto dto)
		{
			if (dto == null || updateObj == null) { return null; }
			updateObj.Name = dto.Name;
			updateObj.UsdaFoodId = dto.UsdaFoodId;
			updateObj.LinkUrl = dto.LinkUrl;
			updateObj.PurchasedBy = dto.PurchasedBy;
			updateObj.PralScore = dto.PralScore;
			updateObj.IngredientStateId = dto.IngredientStateId;

			// Nutrition Facts
			updateObj.Calories = dto.NutritionFacts.Calories;
			updateObj.Protein = dto.NutritionFacts.Protein;
			updateObj.Fat = dto.NutritionFacts.TotalFat;
			updateObj.Carbohydrate = dto.NutritionFacts.TotalCarbohydrate;
			updateObj.Water = dto.NutritionFacts.Water;
			updateObj.SaturatedFat = dto.NutritionFacts.SaturatedFat;
			updateObj.TransFattyAcids = dto.NutritionFacts.TransFat;
			updateObj.Omega3s = dto.NutritionFacts.Omega3s;
			updateObj.Omega6s = dto.NutritionFacts.Omega6s;
			updateObj.FattyAcidsTotalMonounsaturated = dto.NutritionFacts.MonoUnsaturatedFat;
			updateObj.FattyAcidsTotalPolyunsaturated = dto.NutritionFacts.PolyUnsaturatedFat;
			updateObj.Cholesterol = dto.NutritionFacts.Cholesterol;
			updateObj.Fiber = dto.NutritionFacts.DietaryFiber;
			updateObj.Sugars = dto.NutritionFacts.TotalSugars;

			// Pricing
			updateObj.PriceBrandName = dto.Price.BrandName;
			updateObj.PriceDollar = dto.Price.Price;
			updateObj.PriceQuantity = dto.Price.Quantity;
			updateObj.PriceMeasurement = dto.Price.Measurement;
			updateObj.PriceApiLink = dto.Price.ApiLink;
			updateObj.PriceStoreName = dto.Price.StoreName;

			// Minerals
			updateObj.Calcium = dto.CommonMinerals.Calcium;
			updateObj.IronFe = dto.CommonMinerals.IronFe;
			updateObj.PotassiumK = dto.CommonMinerals.PotassiumK;
			updateObj.Sodium = dto.CommonMinerals.Sodium;
			updateObj.Magnesium = dto.CommonMinerals.Magnesium;
			updateObj.ZincZn = dto.CommonMinerals.ZincZn;
			updateObj.CopperCu = dto.CommonMinerals.CopperCu;
			updateObj.Manganese = dto.CommonMinerals.Manganese;
			updateObj.SeleniumSe = dto.CommonMinerals.SeleniumSe;
			updateObj.FluorideF = dto.CommonMinerals.FluorideF;

			// Common Vitamins
			updateObj.VitaminAIu = dto.CommonVitamins.VitaminAIu;
			updateObj.VitaminARae = dto.CommonVitamins.VitaminARae;

			updateObj.ThiaminB1 = dto.CommonVitamins.ThiaminB1;
			updateObj.RiboflavinB2 = dto.CommonVitamins.RiboflavinB2;
			updateObj.NiacinB3 = dto.CommonVitamins.NiacinB3;
			updateObj.PantothenicAcidB5 = dto.CommonVitamins.PantothenicAcidB5;
			updateObj.VitaminB6 = dto.CommonVitamins.VitaminB6;
			updateObj.FolateB9 = dto.CommonVitamins.FolateB9;
			updateObj.VitaminB12 = dto.CommonVitamins.VitaminB12;

			updateObj.VitaminC = dto.CommonVitamins.VitaminC;
			updateObj.VitaminD = dto.CommonVitamins.VitaminD;
			updateObj.VitaminDIu = dto.CommonVitamins.VitaminDIu;
			updateObj.VitaminE = dto.CommonVitamins.VitaminE;
			updateObj.VitaminK = dto.CommonVitamins.VitaminK;

			updateObj.FolateDfe = dto.CommonVitamins.FolateDfe;
			updateObj.FolicAcid = dto.CommonVitamins.FolicAcid;
			updateObj.FoodFolate = dto.CommonVitamins.FoodFolate;

			updateObj.FoodGroupId = dto.FoodGroup.Id;

			updateObj.IngredientAllergyWarning = dto.Allergies.Select(x => MapDtoToIngredientAllergyWarningMapping(x, dto.Id)).ToList();
			updateObj.IngredientConversions = dto.IngredientConversions.Select(x => MapDtoToIngredientConversionMapping(x, dto.Id)).ToList();

			return updateObj;
		}

		private IngredientAllergyWarning MapDtoToIngredientAllergyWarningMapping(IReferenceItemEx map, int ingredientId)
		{
			if (map == null) { return null; }
			return new IngredientAllergyWarning
			{
				IngredientId = ingredientId,
				AllergyWarningId = map.Id
			};
		}

		private IngredientConversion MapDtoToIngredientConversionMapping(IngredientConversionDto map, int ingredientId)
		{
			if (map == null || ingredientId == 0) { return null; }
			return new IngredientConversion
			{
				IngredientId = ingredientId,
				BaseStateId = map.BaseState.Id,
				BaseMeasurementUnitId = map.BaseMeasurementUnit.Id,
				BaseQuantity = map.BaseQuantity,
				ConvertToStateId = map.ConvertToState.Id,
				ConvertToMeasurementUnitId = map.ConvertToMeasurementUnit.Id,
				ConvertToQuantity = map.ConvertToQuantity,
			};
		}


	}
}
