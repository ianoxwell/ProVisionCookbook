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
	[Route("api/v1/ingredient")]
	[ApiController]
	[Produces("application/json")]
	[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
	[ProducesResponseType(StatusCodes.Status500InternalServerError)]
	public class IngredientController : Controller
	{
		private IIngredientService IngredientService { get; }

		/// <summary>
		/// Initialises a new instance of the IngredientController Class
		/// Expected lifetime is scope to the web request
		/// </summary>
		/// <param name="ingredientService">The ingredient service.</param>
		public IngredientController(IIngredientService ingredientService)
		{
			IngredientService = ingredientService;
		}

		/// <summary>
		/// Get a single Ingredient by Id
		/// </summary>
		/// <param name="ingredientId">Ingredient Identifier</param>
		/// <returns>IngredientDto</returns>
		[HttpGet("{ingredientId}")]
		[ProducesResponseType(200, Type = typeof(IngredientDto))]
		public IActionResult GetIngredient(int ingredientId)
		{
			IngredientDto ingredient = IngredientService.ReadSingleIngredient(ingredientId).Result;
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
		/// <returns></returns>
		[HttpGet]
		[Route("search")]
		[ProducesResponseType(200, Type = typeof(PagedResult<IngredientDto>))]
		public IActionResult SearchIngredient(
			int pageSize = 25,
			int page = 0,
			string sort = "name",
			string order = "asc",
			string filter = "")
		{
			PagedResult<IngredientDto> ingredient = IngredientService.SearchIngredients(pageSize, page, sort, order, filter).Result;
			return Ok(ingredient);
		}

		/// <summary>
		/// List of possible ingredient suggestions
		/// </summary>
		/// <param name="filter">Text to filter name on</param>
		/// <param name="limit">Number of results</param>
		/// <returns></returns>
		[HttpGet]
		[ProducesResponseType(200, Type = typeof(List<SuggestedIngredientDto>))]
		[Route("suggestion")]
		public IActionResult IngredientSuggestion(string filter = "", int limit = 10)
		{
			List<SuggestedIngredientDto> suggestions = IngredientService.SuggestedIngredient(filter, limit).Result;
			return Ok(suggestions);
		}


		/// <summary>
		/// Check if a food name is available
		/// </summary>
		/// <param name="filter">Text to filter name on</param>
		/// <param name="foodId">For a name change doesn't check itself</param>
		/// <returns></returns>
		[HttpGet]
		[ProducesResponseType(200, Type = typeof(bool))]
		[Route("check-name")]
		public IActionResult IsIngredientNameAvailable(string filter = "", int foodId = 0)
		{
			return Ok(IngredientService.IngredientNameExists(filter, foodId));
		}

		/// <summary>
		/// Create a new Ingredient
		/// </summary>
		/// <param name="ingredientDto">Ingredient Object</param>
		/// <returns>New IngredientDto</returns>
		[HttpPost]
		[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IngredientDto))]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public IActionResult CreateIngredient([FromBody] IngredientDto ingredientDto)
		{
			if (ingredientDto == null)
			{
				return BadRequest(ModelState);
			}
			if (IngredientService.IngredientNameExists(ingredientDto.Name))
			{
				ModelState.AddModelError("", "Ingredient name already exists.");
				return StatusCode(404, ModelState);
			}

			return Ok(IngredientService.CreateIngredient(ingredientDto).Result);
		}

		/// <summary>
		/// Update ingredient
		/// </summary>
		/// <param name="ingredientDto">Ingredient Object</param>
		/// <param name="ingredientId">Ingredient Id check</param>
		/// <returns></returns>
		[HttpPut("{ingredientId}")]
		[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IngredientDto))]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		public IActionResult UpdateIngredient([FromBody] IngredientDto ingredientDto, int ingredientId)
		{
			if (ingredientDto == null || ingredientId != ingredientDto.Id)
			{
				return BadRequest(ModelState);
			}
			if (IngredientService.IngredientNameExists(ingredientDto.Name))
			{
				ModelState.AddModelError("", "Ingredient name already exists.");
				return StatusCode(404, ModelState);
			}

			return Ok(IngredientService.UpdateIngredient(ingredientId, ingredientDto).Result);
		}


		/// <summary>
		/// Delete a single ingredient by ingredientId
		/// </summary>
		/// <param name="ingredientId">Ingredient Identifier</param>
		/// <returns></returns>
		[HttpDelete("{ingredientId}")]
		[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IngredientDto))]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		public IActionResult DeleteIngredient(int ingredientId)
		{
			if (ingredientId == 0)
			{
				return BadRequest(ModelState);
			}

			var dto = IngredientService.DeleteIngredient(ingredientId).Result;
			if (dto == null)
			{
				ModelState.AddModelError("", $"Something went wrong when Deleting the record {ingredientId}");
				return StatusCode(500, ModelState);
			}


			return Ok(dto);
		}

	}
}
