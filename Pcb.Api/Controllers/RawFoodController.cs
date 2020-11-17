using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pcb.Common;
using Pcb.Dto.Ingredient;
using Pcb.Service.Interfaces;
using System.Collections.Generic;

namespace Pcb.Api.Controllers
{
	/// <summary>
	/// Provide access to the Ingredients
	/// </summary>
	[Route("api/v1/rawfooddata")]
	[ApiController]
	[Produces("application/json")]
	[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
	[ProducesResponseType(StatusCodes.Status500InternalServerError)]
	public class RawFoodController : Controller
	{
		private IRawFoodService RawFoodService { get; }

		/// <summary>
		/// Initialises a new instance of the IngredientController Class
		/// Expected lifetime is scope to the web request
		/// </summary>
		/// <param name="rawFoodService">The ingredient service.</param>
		public RawFoodController(IRawFoodService rawFoodService)
		{
			RawFoodService = rawFoodService;
		}

		/// <summary>
		/// Get a single Ingredient by Id
		/// </summary>
		/// <param name="usdaId">Ingredient Identifier</param>
		/// <returns>IngredientDto</returns>
		[HttpGet("{usdaId}")]
		[ProducesResponseType(200, Type = typeof(RawFoodDto))]
		public IActionResult GetIngredient(int usdaId)
		{
			RawFoodDto ingredient = RawFoodService.ReadSingleIngredient(usdaId).Result;
			return Ok(ingredient);
		}

		/// <summary>
		/// Search for ingredients with paged results
		/// </summary>
		/// <param name="pageSize">Number of results per page</param>
		/// <param name="page">Page offset - default is 0</param>
		/// <param name="sort">Sort field name - default is name</param>
		/// <param name="order">Direction of sort - default is asc</param>
		/// <param name="filter">Searches a number of fields to contain text</param>
		/// <param name="foodGroupId">Limits the search to a food group</param>
		/// <returns></returns>
		[HttpGet]
		[Route("search")]
		[ProducesResponseType(200, Type = typeof(PagedResult<RawFoodDto>))]
		public IActionResult SearchIngredient(
			int pageSize = 25,
			int page = 0,
			string sort = "name",
			string order = "asc",
			string filter = "",
			int foodGroupId = 0
			)
		{
			PagedResult<RawFoodDto> ingredient = RawFoodService.SearchIngredients(pageSize, page, sort, order, filter, foodGroupId).Result;
			return Ok(ingredient);
		}

		/// <summary>
		/// List of possible ingredient suggestions
		/// </summary>
		/// <param name="filter">Text to filter name on</param>
		/// <param name="limit">Number of results</param>
		/// <param name="foodGroupId">Limits the search to a food group</param>
		/// <returns></returns>
		[HttpGet]
		[ProducesResponseType(200, Type = typeof(List<SuggestedIngredientDto>))]
		[Route("suggestion")]
		public IActionResult IngredientSuggestion(string filter = "", int limit = 10, int foodGroupId = 0)
		{
			List<SuggestedIngredientDto> suggestions = RawFoodService.SuggestedIngredient(filter, limit, foodGroupId).Result;
			return Ok(suggestions);
		}

	}
}
