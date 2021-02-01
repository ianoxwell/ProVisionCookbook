using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pcb.Common;
using Pcb.Dto.Ingredient;
using Pcb.Dto.Recipes;
using Pcb.Service.Interfaces;
using System.Collections.Generic;

namespace Pcb.Api.Controllers
{
    /// <summary>
    /// Provide access to the Recipes
    /// </summary>
    [Route("api/v1/recipe")]
    [ApiController]
    [ApiVersion("1.0")]
    [Produces("application/json")]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public class RecipeController : Controller
    {
        private IRecipeService RecipeService { get; }

        /// <summary>
        /// Initialises a new instance of the RecipeController Class
        /// Expected lifetime is scope to the web request
        /// </summary>
        /// <param name="recipeService">The recipe service.</param>
        public RecipeController(IRecipeService recipeService)
        {
            RecipeService = recipeService;
        }

        /// <summary>
        /// Get a single Recipe by Id
        /// </summary>
        /// <param name="recipeId">Recipe Identifier</param>
        /// <returns>RecipeDto</returns>
        [HttpGet("{recipeId}")]
        [ProducesResponseType(200, Type = typeof(RecipeDto))]
        public IActionResult GetRecipe(int recipeId)
        {
            RecipeDto recipe = RecipeService.ReadSingleRecipe(recipeId).Result;
            return Ok(recipe);
        }

        /// <summary>
        /// Search for recipes with paged results
        /// </summary>
        /// <param name="pageSize">Number of results per page</param>
        /// <param name="page">Page offset - default is 0</param>
        /// <param name="sort">Sort field name - default is name</param>
        /// <param name="order">Direction of sort - default is asc</param>
        /// <param name="filter">Searches a number of fields to contain text</param>
        /// <returns></returns>
        [HttpGet]
        [Route("search")]
        [ProducesResponseType(200, Type = typeof(PagedResult<RecipeDto>))]
        public IActionResult SearchRecipe(
            int pageSize = 25,
            int page = 0,
            string sort = "name",
            string order = "asc",
            string filter = "")
        {
            PagedResult<RecipeDto> recipe = RecipeService.SearchRecipes(pageSize, page, sort, order, filter).Result;
            if (recipe == null)
            {
                ModelState.AddModelError("", $"Something went wrong trying to search the recipes {filter}");
                return StatusCode(500, ModelState);
            }
            return Ok(recipe);
        }

        /// <summary>
        /// List of possible recipe suggestions
        /// </summary>
        /// <param name="filter">Text to filter name on</param>
        /// <param name="limit">Number of results</param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(List<SuggestedIngredientDto>))]
        [Route("suggestion")]
        public IActionResult RecipeSuggestion(string filter = "", int limit = 10)
        {
            List<SuggestedIngredientDto> suggestions = RecipeService.SuggestedRecipe(filter, limit).Result;
            return Ok(suggestions);
        }

        /// <summary>
        /// Create a new Recipe
        /// </summary>
        /// <param name="dto">Recipe Object</param>
        /// <returns>New RecipeDto</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(RecipeDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult CreateRecipe([FromBody] RecipeDto dto)
        {
            if (dto == null)
            {
                return BadRequest(ModelState);
            }
            if (RecipeService.RecipeNameExists(dto.Name))
            {
                ModelState.AddModelError("", "Recipe name already exists.");
                return StatusCode(404, ModelState);
            }

            return Ok(RecipeService.CreateRecipe(dto).Result);
        }

        /// <summary>
        /// Update Recipe
        /// </summary>
        /// <param name="RecipeDto">Recipe Object</param>
        /// <param name="recipeId">Recipe Id check</param>
        /// <returns></returns>
        [HttpPut("{recipeId}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(RecipeDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult UpdateRecipe([FromBody] RecipeDto RecipeDto, int recipeId)
        {
            if (RecipeDto == null || recipeId != RecipeDto.Id)
            {
                return BadRequest(ModelState);
            }
            if (RecipeService.RecipeNameExists(RecipeDto.Name))
            {
                ModelState.AddModelError("", "Recipe name already exists.");
                return StatusCode(404, ModelState);
            }

            return Ok(RecipeService.UpdateRecipe(recipeId, RecipeDto).Result);
        }


        /// <summary>
        /// Delete a single Recipe by recipeId
        /// </summary>
        /// <param name="recipeId">Recipe Identifier</param>
        /// <returns></returns>
        [HttpDelete("{recipeId}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(RecipeDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult DeleteRecipe(int recipeId)
        {
            if (recipeId == 0)
            {
                return BadRequest(ModelState);
            }

            var dto = RecipeService.DeleteRecipe(recipeId).Result;
            if (dto == null)
            {
                ModelState.AddModelError("", $"Something went wrong when Deleting the record {recipeId}");
                return StatusCode(500, ModelState);
            }


            return Ok(dto);
        }

        /// <summary>
        /// Check if a Recipe name is available
        /// </summary>
        /// <param name="filter">Text to filter name on</param>
        /// <param name="recipeId">For a name change doesn't check itself</param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(bool))]
        [Route("check-name")]
        public IActionResult IsIngredientNameAvailable(string filter = "", int recipeId = 0)
        {
            return Ok(RecipeService.RecipeNameExists(filter, recipeId));
        }

    }
}
