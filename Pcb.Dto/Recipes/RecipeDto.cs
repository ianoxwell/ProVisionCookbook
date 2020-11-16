using Pcb.Dto.Reference;
using System;
using System.Collections.Generic;

namespace Pcb.Dto.Recipes
{
    public class RecipeDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Teaser { get; set; }
        public int NumberOfServings { get; set; }
        public decimal PriceEstimate { get; set; }
        public decimal PriceServing { get; set; }
        public int PrepTime { get; set; }
        public int CookTime { get; set; }
        public int ReadyInMinutes { get; set; }
        public string RawInstructions { get; set; }
        public int CreateByUserId { get; set; }
        public string SourceOfRecipeLink { get; set; } // used to reference SpoonAcular or source
        public string CreditsText { get; set; }
        public int NumberStars { get; set; }
        public int NumberFavourites { get; set; }
        public int NumberOfTimesCooked { get; set; }


        public byte[] RowVer { get; set; }
        public DateTimeOffset CreatedAt { get; set; }

        public List<ReferenceItemEx> AllergyWarnings { get; set; }
        public List<ReferenceItemEx> RecipeCuisineTypes { get; set; }
        public List<ReferenceItemEx> RecipeDishTags { get; set; }
        public List<ReferenceItemEx> RecipeDishTypes { get; set; }
        public List<ReferenceItemEx> RecipeHealthLabels { get; set; }
        public List<RecipeSteppedInstructionDto> SteppedInstructions { get; set; }
        public List<RecipeIngredientListDto> RecipeIngredientLists { get; set; }
        public List<RecipeReviewDto> RecipeReviews { get; set; }
        public List<RecipePictureDto> RecipePictures { get; set; }
    }
}
