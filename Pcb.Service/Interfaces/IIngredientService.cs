using Pcb.Common;
using Pcb.Dto.Ingredient;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pcb.Service.Interfaces
{
    public interface IIngredientService
    {
        /// <summary>
        /// Async Search for ingredients with query parameters
        /// </summary>
        /// <param name="pageSize"></param>
        /// <param name="page"></param>
        /// <param name="sort"></param>
        /// <param name="order"></param>
        /// <param name="filter"></param>
        /// <returns></returns>
        Task<PagedResult<IngredientDto>> SearchIngredients(
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
        Task<IngredientDto> CreateIngredient(IngredientDto dto);
        /// <summary>
        /// Get a Single Ingredient
        /// </summary>
        /// <param name="ingredientId"></param>
        /// <returns></returns>
        Task<IngredientDto> ReadSingleIngredient(int ingredientId);
        /// <summary>
        /// Update a single ingredient
        /// </summary>
        /// <param name="ingredientId"></param>
        /// <param name="dto"></param>
        /// <returns></returns>
        Task<IngredientDto> UpdateIngredient(int ingredientId, IngredientDto dto);
        /// <summary>
        /// Delete a single ingredient
        /// </summary>
        /// <param name="ingredientId"></param>
        /// <returns></returns>
        Task<IngredientDto> DeleteIngredient(int ingredientId);
        /// <summary>
        /// Get list of Suggested Ingredient names and Id's
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        Task<List<SuggestedIngredientDto>> SuggestedIngredient(string filter = "", int pageSize = 10);
        /// <summary>
        /// Check if Ingredient with same name exists
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        bool IngredientNameExists(string name, int ingredientId = 0);
    }
}
