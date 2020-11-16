using Pcb.Common;
using Pcb.Dto.Ingredient;
using Pcb.Dto.Recipes;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pcb.Service.Interfaces
{
    public interface IRecipeService
    {
        /// <summary>
        ///  Async Search for ingredients with query parameters
        /// </summary>
        /// <param name="pageSize">Return number of results</param>
        /// <param name="page">Skips the page * pageSize</param>
        /// <param name="sort">Field to sort</param>
        /// <param name="order">"asc" or anything else</param>
        /// <param name="filter">Text to filter on</param>
        /// <returns></returns>
        Task<PagedResult<RecipeDto>> SearchRecipes(
            int pageSize = 25,
            int page = 1,
            string sort = "name",
            string order = "asc",
            string filter = "");
        /// <summary>
        /// Create a new Ingredient
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        Task<RecipeDto> CreateRecipe(RecipeDto dto);
        /// <summary>
        /// Get a Single Ingredient
        /// </summary>
        /// <param name="recipeId"></param>
        /// <returns></returns>
        Task<RecipeDto> ReadSingleRecipe(int recipeId);
        /// <summary>
        /// Update a single ingredient
        /// </summary>
        /// <param name="recipeId"></param>
        /// <param name="dto"></param>
        /// <returns></returns>
        Task<RecipeDto> UpdateRecipe(int recipeId, RecipeDto dto);
        /// <summary>
        /// Delete a single ingredient
        /// </summary>
        /// <param name="recipeId"></param>
        /// <returns></returns>
        Task<RecipeDto> DeleteRecipe(int recipeId);

        /// <summary>
        ///  Get list of Suggested Ingredient names and Id's
        /// </summary>
        /// <param name="filter">Text to filter on</param>
        /// <param name="pageSize">Number of results to return defaults to 10</param>
        /// <returns></returns>
        Task<List<SuggestedIngredientDto>> SuggestedRecipe(string filter = "", int pageSize = 10);
        /// <summary>
        /// Check if Ingredient with same name exists
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        bool RecipeNameExists(string name, int recipeId = 0);
    }
}
