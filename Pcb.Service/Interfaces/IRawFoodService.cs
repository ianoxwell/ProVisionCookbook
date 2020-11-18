using Pcb.Common;
using Pcb.Dto.Ingredient;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pcb.Service.Interfaces
{
	public interface IRawFoodService
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
		Task<PagedResult<RawFoodDto>> SearchIngredients(
			int pageSize = 25,
			int page = 1,
			string sort = "name",
			string order = "asc",
			string filter = "",
			int foodGroupId = 0);

		/// <summary>
		/// Get a Single Ingredient
		/// </summary>
		/// <param name="ingredientId"></param>
		/// <returns></returns>
		Task<RawFoodDto> ReadSingleIngredient(int ingredientId);

		/// <summary>
		/// Get list of Suggested Ingredient names and Id's
		/// </summary>
		/// <param name="filter"></param>
		/// <param name="pageSize"></param>
		/// <returns></returns>
		Task<List<SuggestedRawFoodDto>> SuggestedIngredient(string filter = "", int pageSize = 10, int foodGroupId = 0);
	}
}
