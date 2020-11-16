using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Pcb.Common;
using Pcb.Configuration;
using Pcb.Database;
using Pcb.Database.Context;
using Pcb.Database.Context.Models;
using Pcb.Dto.Ingredient;
using Pcb.Dto.Recipes;
using Pcb.Mapping.Interface;
using Pcb.Security;
using Pcb.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pcb.Service.Implementations
{
    internal class RecipeService : ServiceBase<PcbDbContext>, IRecipeService
    {
        private IPcbSecurityService SecurityService { get; }

        private IRecipeMapper RecipeMapper { get; }
        public RecipeService(
            IPcbSecurityService securityService,
            IPcbConfiguration configurationService,
            IRecipeMapper recipeMapper,
            ILogger<IngredientService> logger)
            : base(configurationService, logger)
        {
            SecurityService = securityService;
            RecipeMapper = recipeMapper;
        }

        public async Task<PagedResult<RecipeDto>> SearchRecipes(
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
                var recipeArray = _db.Recipe
                    .Skip(skip)
                    .Take(pageSize)
                    .Where(l => string.IsNullOrEmpty(filter) ||
                                l.Name.Contains(filter) ||
                                l.RawInstructions.Contains(filter) ||
                                l.Teaser.Contains(filter));

                recipeArray = order.Equals("asc", StringComparison.OrdinalIgnoreCase)
                    ? recipeArray.OrderByMember(sort)
                    : recipeArray.OrderByMemberDescending(sort);

                var finishedRecipeArray = await recipeArray
                    //.Include(x => x.ParentType)
                    //.Include(x => x.IngredientState)
                    //.Include(x => x.IngredientConversions).ThenInclude(x => x.MeasurementBaseUnit)
                    //.Include(x => x.IngredientConversions).ThenInclude(x => x.MeasurementConvertUnit)
                    //.Include(x => x.IngredientConversions).ThenInclude(x => x.IngredientBaseConversionState)
                    //.Include(x => x.IngredientConversions).ThenInclude(x => x.IngredientConvertConversionState)
                    //.Include(x => x.IngredientAllergyWarning).ThenInclude(x => x.AllergyWarning)
                    //.Include(x => x.IngredientNutrition)
                    .ToListAsync();

                PagedResult<RecipeDto> pagedResult = new PagedResult<RecipeDto>();
                pagedResult.TotalCount = await _db.Recipe.CountAsync();
                foreach (var recipe in finishedRecipeArray)
                {
                    pagedResult.Items.Add(RecipeMapper.MapRecipeToDto(recipe));
                }
                return pagedResult;
            }
        }

        public async Task<RecipeDto> CreateRecipe(RecipeDto dto)
        {
            using (var _db = GetReadWriteDbContext())
            {
                var mapped = RecipeMapper.MapDtoToRecipe(dto);
                _db.Recipe.Add(mapped);
                await _db.SaveChangesAsync();
                return await ReadSingleRecipe(mapped.Id);
            }
        }

        public async Task<RecipeDto> ReadSingleRecipe(int recipeId)
        {
            using (var _db = GetReadOnlyDbContext())
            {
                var recipeObj = await _db.Recipe
                    .Where(x => x.Id == recipeId)
                    .Include(x => x.RecipeAllergyWarning).ThenInclude(y => y.AllergyWarning)
                    .Include(x => x.RecipeCuisineType).ThenInclude(y => y.CuisineType)
                    .Include(x => x.RecipeDishTag).ThenInclude(y => y.DishTag)
                    .Include(x => x.RecipeDishType).ThenInclude(y => y.DishType)
                    .Include(x => x.RecipeHealthLabel).ThenInclude(y => y.HealthLabel)
                    .Include(x => x.SteppedInstruction)
                    .Include(x => x.RecipeIngredientList).ThenInclude(y => y.Ingredient)
                        .ThenInclude(x => x.IngredientConversions).ThenInclude(x => x.MeasurementBaseUnit)
                    .Include(x => x.RecipeIngredientList).ThenInclude(y => y.Ingredient)
                        .ThenInclude(x => x.IngredientConversions).ThenInclude(x => x.MeasurementConvertUnit)
                    .Include(x => x.RecipeIngredientList).ThenInclude(y => y.Ingredient)
                        .ThenInclude(x => x.IngredientConversions).ThenInclude(x => x.IngredientBaseConversionState)
                    .Include(x => x.RecipeIngredientList).ThenInclude(y => y.Ingredient)
                        .ThenInclude(x => x.IngredientConversions).ThenInclude(x => x.IngredientConvertConversionState)
                    .Include(x => x.RecipeIngredientList).ThenInclude(y => y.Ingredient)
                        .ThenInclude(x => x.IngredientAllergyWarning)
                    .Include(x => x.RecipeReview)
                    .Include(x => x.RecipePicture)
                    .FirstOrDefaultAsync();


                return RecipeMapper.MapRecipeToDto(recipeObj);
            }
        }


        public async Task<RecipeDto> UpdateRecipe(int recipeId, RecipeDto dto)
        {
            if (dto == null || recipeId != dto.Id) { return null; }
            using (var _db = GetReadWriteDbContext())
            {
                // Find the ingredient first
                Recipe recipeObj = await _db.Recipe
                    .Where(x => x.Id == recipeId)
                    .Include(x => x.RecipeAllergyWarning).ThenInclude(y => y.AllergyWarning)
                    .Include(x => x.RecipeCuisineType).ThenInclude(y => y.CuisineType)
                    .Include(x => x.RecipeDishTag).ThenInclude(y => y.DishTag)
                    .Include(x => x.RecipeDishType).ThenInclude(y => y.DishType)
                    .Include(x => x.RecipeHealthLabel).ThenInclude(y => y.HealthLabel)
                    .Include(x => x.SteppedInstruction)
                    .Include(x => x.RecipeIngredientList).ThenInclude(y => y.Ingredient)
                        .ThenInclude(x => x.IngredientConversions).ThenInclude(x => x.MeasurementBaseUnit)
                    .Include(x => x.RecipeIngredientList).ThenInclude(y => y.Ingredient)
                        .ThenInclude(x => x.IngredientConversions).ThenInclude(x => x.MeasurementConvertUnit)
                    .Include(x => x.RecipeIngredientList).ThenInclude(y => y.Ingredient)
                        .ThenInclude(x => x.IngredientConversions).ThenInclude(x => x.IngredientBaseConversionState)
                    .Include(x => x.RecipeIngredientList).ThenInclude(y => y.Ingredient)
                        .ThenInclude(x => x.IngredientConversions).ThenInclude(x => x.IngredientConvertConversionState)
                    .Include(x => x.RecipeIngredientList).ThenInclude(y => y.Ingredient)
                        .ThenInclude(x => x.IngredientAllergyWarning)
                    .Include(x => x.RecipeReview)
                    .Include(x => x.RecipePicture)
                    .FirstOrDefaultAsync();

                recipeObj = RecipeMapper.UpdateRecipeWithDto(recipeObj, dto);
                await _db.SaveChangesAsync();

                return await ReadSingleRecipe(recipeId);
            }
        }

        public async Task<RecipeDto> DeleteRecipe(int recipeId)
        {
            // Get the DB Context
            using (var _db = GetReadWriteDbContext())
            {
                // Find the ingredient first
                var ingredientObj = await _db.Recipe
                    .Where(x => x.Id == recipeId)
                    .Include(x => x.RecipeAllergyWarning).ThenInclude(y => y.AllergyWarning)
                    .Include(x => x.RecipeCuisineType).ThenInclude(y => y.CuisineType)
                    .Include(x => x.RecipeDishTag).ThenInclude(y => y.DishTag)
                    .Include(x => x.RecipeDishType).ThenInclude(y => y.DishType)
                    .Include(x => x.RecipeHealthLabel).ThenInclude(y => y.HealthLabel)
                    .Include(x => x.SteppedInstruction)
                    .Include(x => x.RecipeIngredientList).ThenInclude(y => y.Ingredient)
                        .ThenInclude(x => x.IngredientConversions).ThenInclude(x => x.MeasurementBaseUnit)
                    .Include(x => x.RecipeIngredientList).ThenInclude(y => y.Ingredient)
                        .ThenInclude(x => x.IngredientConversions).ThenInclude(x => x.MeasurementConvertUnit)
                    .Include(x => x.RecipeIngredientList).ThenInclude(y => y.Ingredient)
                        .ThenInclude(x => x.IngredientConversions).ThenInclude(x => x.IngredientBaseConversionState)
                    .Include(x => x.RecipeIngredientList).ThenInclude(y => y.Ingredient)
                        .ThenInclude(x => x.IngredientConversions).ThenInclude(x => x.IngredientConvertConversionState)
                    .Include(x => x.RecipeIngredientList).ThenInclude(y => y.Ingredient)
                        .ThenInclude(x => x.IngredientAllergyWarning)
                    .Include(x => x.RecipeReview)
                    .Include(x => x.RecipePicture)
                    .FirstOrDefaultAsync();

                if (ingredientObj == null)
                {
                    return null;
                }

                // Remove and Save the changes
                _db.Recipe.Remove(ingredientObj);
                await _db.SaveChangesAsync();

                // return the ingredientObj mapped
                return RecipeMapper.MapRecipeToDto(ingredientObj);
            }
        }

        public async Task<List<SuggestedIngredientDto>> SuggestedRecipe(string filter = "", int pageSize = 10)
        {
            using (var _db = GetReadOnlyDbContext())
            {
                var ingList = await _db.Recipe
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
        }

        public bool RecipeNameExists(string name, int recipeId = 0)
        {
            using (var _db = GetReadOnlyDbContext())
            {
                Recipe value = _db.Recipe.FirstOrDefault(a => a.Name.ToLower().Trim() == name.ToLower().Trim());
                return (value == null || value.Id == recipeId);
            }
        }



    }
}
