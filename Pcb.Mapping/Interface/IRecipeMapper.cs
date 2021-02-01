using Pcb.Database.Context.Models;
using Pcb.Dto.Recipes;
using Pcb.Dto.Reference;
using System.Collections.Generic;

namespace Pcb.Mapping.Interface
{
    public interface IRecipeMapper
    {
        List<ReferenceItemEx> MapAllergyWarningToList(IEnumerable<RecipeAllergyWarning> map);
        List<ReferenceItemEx> MapRecipeCuisineTypesToList(IEnumerable<RecipeCuisineType> map);
        List<ReferenceItemEx> MapRecipeDishTagsToList(IEnumerable<RecipeDishTag> map);
        List<ReferenceItemEx> MapRecipeDishTypesToList(IEnumerable<RecipeDishType> map);
        List<ReferenceItemEx> MapRecipeHealthLabelsToList(IEnumerable<RecipeHealthLabel> map);
        List<RecipeSteppedInstructionDto> MapSteppedInstructionsToDtoList(IEnumerable<RecipeSteppedInstruction> map);

        List<RecipeIngredientListDto> MapRecipeIngredientsDtoList(IEnumerable<RecipeIngredientList> map);
        List<RecipeReviewDto> MapRecipeReviewsDtoList(IEnumerable<RecipeReview> map);
        List<RecipePictureDto> MapRecipePicturesDtoList(IEnumerable<RecipePicture> map);
        RecipeDto MapRecipeToDto(Recipe dbObj);
        RecipeDto MapRecipeToShortDto(Recipe dbObj);
        Recipe MapDtoToRecipe(RecipeDto dto);
        Recipe UpdateRecipeWithDto(Recipe updateObj, RecipeDto dto);
    }
}
