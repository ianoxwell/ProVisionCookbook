using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Pcb.Common;
using Pcb.Configuration;
using Pcb.Database;
using Pcb.Database.Context;
using Pcb.Database.Context.Models;
using Pcb.Dto.Ingredient;
using Pcb.Mapping.Interface;
using Pcb.Security;
using Pcb.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pcb.Service.Implementations
{
	internal class IngredientService : ServiceBase<PcbDbContext>, IIngredientService
	{
		private IPcbSecurityService SecurityService { get; }

		private IIngredientMapper IngredientMapper { get; }
		public IngredientService(
			IPcbSecurityService securityService,
			IPcbConfiguration configurationService,
			IIngredientMapper ingredientMapper,
			ILogger<IngredientService> logger)
			: base(configurationService, logger)
		{
			SecurityService = securityService;
			IngredientMapper = ingredientMapper;
		}

		public async Task<PagedResult<IngredientDto>> SearchIngredients(
			int pageSize = 25,
			int page = 1,
			string sort = "name",
			string order = "asc",
			string filter = "")
		{
			var p = page > 0 ? page : 0;
			using (var _db = GetReadOnlyDbContext())
			{
				var skip = p * pageSize;
				var ingredientArray = _db.Ingredient
					.Skip(skip)
					.Take(pageSize)
					.Where(l => string.IsNullOrEmpty(filter) ||
								l.Name.Contains(filter) ||
								l.PriceBrandName.Contains(filter) ||
								l.PriceStoreName.Contains(filter));

				ingredientArray = order.Equals("asc", StringComparison.OrdinalIgnoreCase)
					? ingredientArray.OrderByMember(sort)
					: ingredientArray.OrderByMemberDescending(sort);

				var finishedIngredientArray = await ingredientArray
					.Include(x => x.FoodGroup)
					.Include(x => x.IngredientConversions).ThenInclude(x => x.MeasurementBaseUnit)
					.Include(x => x.IngredientConversions).ThenInclude(x => x.MeasurementConvertUnit)
					.Include(x => x.IngredientConversions).ThenInclude(x => x.IngredientBaseConversionState)
					.Include(x => x.IngredientConversions).ThenInclude(x => x.IngredientConvertConversionState)
					.Include(x => x.IngredientAllergyWarning).ThenInclude(x => x.AllergyWarning)
					.Include(x => x.IngredientNutrition)
					.ToListAsync();

				PagedResult<IngredientDto> pagedIngredientResult = new PagedResult<IngredientDto>
				{
					TotalCount = await _db.Ingredient.CountAsync()
				};
				foreach (var ingredient in finishedIngredientArray)
				{
					pagedIngredientResult.Items.Add(IngredientMapper.MapIngredientToDto(ingredient));
				}
				return pagedIngredientResult;
			}
		}

		public async Task<IngredientDto> CreateIngredient(IngredientDto dto)
		{
			using var _db = GetReadWriteDbContext();
			var mapped = IngredientMapper.MapDtoToIngredient(dto);
			_db.Ingredient.Add(mapped);
			await _db.SaveChangesAsync();
			return await ReadSingleIngredient(mapped.Id);
		}

		public async Task<IngredientDto> ReadSingleIngredient(int ingredientId)
		{
			using (var _db = GetReadOnlyDbContext())
			{
				Ingredient ingredientObj = await _db.Ingredient
					.Where(x => x.Id == ingredientId)
					.Include(x => x.FoodGroup)
					.Include(x => x.IngredientConversions).ThenInclude(x => x.MeasurementBaseUnit)
					.Include(x => x.IngredientConversions).ThenInclude(x => x.MeasurementConvertUnit)
					.Include(x => x.IngredientConversions).ThenInclude(x => x.IngredientBaseConversionState)
					.Include(x => x.IngredientConversions).ThenInclude(x => x.IngredientConvertConversionState)
					.Include(x => x.IngredientAllergyWarning).ThenInclude(x => x.AllergyWarning)
					.Include(x => x.IngredientNutrition)
					.Include(x => x.RecipeIngredientList).ThenInclude(y => y.Recipe)
					.FirstOrDefaultAsync();


				return IngredientMapper.MapIngredientToDto(ingredientObj);
			}
		}


		public async Task<IngredientDto> UpdateIngredient(int ingredientId, IngredientDto dto)
		{
			if (dto == null || ingredientId != dto.Id) { return null; }
			using var _db = GetReadWriteDbContext();
			// Find the ingredient first
			var ingredientObj = await _db.Ingredient
				.Where(x => x.Id == ingredientId)
				 .Include(x => x.IngredientConversions).ThenInclude(x => x.MeasurementBaseUnit)
				.Include(x => x.IngredientConversions).ThenInclude(x => x.MeasurementConvertUnit)
				.Include(x => x.IngredientConversions).ThenInclude(x => x.IngredientBaseConversionState)
				.Include(x => x.IngredientConversions).ThenInclude(x => x.IngredientConvertConversionState)
				.Include(x => x.IngredientAllergyWarning).ThenInclude(x => x.AllergyWarning)
				.Include(x => x.IngredientNutrition)
				.FirstOrDefaultAsync();

			ingredientObj = IngredientMapper.UpdateIngredientWithDto(ingredientObj, dto);
			await _db.SaveChangesAsync();

			return await ReadSingleIngredient(ingredientId);
		}

		public async Task<IngredientDto> DeleteIngredient(int ingredientId)
		{
			// Get the DB Context
			using var _db = GetReadWriteDbContext();
			// Find the ingredient first
			var ingredientObj = await _db.Ingredient
				.Where(x => x.Id == ingredientId)
				.Include(x => x.FoodGroup)
				.Include(x => x.IngredientConversions).ThenInclude(x => x.MeasurementBaseUnit)
				.Include(x => x.IngredientConversions).ThenInclude(x => x.MeasurementConvertUnit)
				.Include(x => x.IngredientConversions).ThenInclude(x => x.IngredientBaseConversionState)
				.Include(x => x.IngredientConversions).ThenInclude(x => x.IngredientConvertConversionState)
				.Include(x => x.IngredientAllergyWarning).ThenInclude(x => x.AllergyWarning)
				.Include(x => x.IngredientNutrition)
				.FirstOrDefaultAsync();

			if (ingredientObj == null)
			{
				return null;
			}

			// Remove and Save the changes
			_db.Ingredient.Remove(ingredientObj);
			await _db.SaveChangesAsync();

			// return the ingredientObj mapped
			return IngredientMapper.MapIngredientToDto(ingredientObj);
		}

		public async Task<List<SuggestedIngredientDto>> SuggestedIngredient(string filter = "", int pageSize = 10)
		{
			using var _db = GetReadOnlyDbContext();
			var ingList = await _db.Ingredient
				.Take(pageSize)
				.Where(l => string.IsNullOrEmpty(filter) ||
							l.Name.Contains(filter))
				.Select(p => new { p.Id, p.Name })
				.OrderByMemberDescending("Name")
				.ToListAsync();
			var suggestionList = new List<SuggestedIngredientDto>();
			foreach (var suggestion in ingList)
			{
				suggestionList.Add(new SuggestedIngredientDto
				{
					Id = suggestion.Id,
					Name = suggestion.Name
				});
			}
			return suggestionList;
		}

		public bool IngredientNameExists(string name, int ingredientId = 0)
		{
			using var _db = GetReadOnlyDbContext();
			Ingredient value = _db.Ingredient.FirstOrDefault(a => a.Name.ToLower().Trim() == name.ToLower().Trim());
			return (value == null || value.Id == ingredientId);
		}



	}
}
