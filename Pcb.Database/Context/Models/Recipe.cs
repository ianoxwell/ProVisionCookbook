using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace Pcb.Database.Context.Models
{
    [Table("Recipe", Schema = "dbo")]
    public partial class Recipe
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Teaser { get; set; }
        public int NumberOfServings { get; set; }
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")]

        public decimal PriceEstimate { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        [DataType(DataType.Currency)]
        public decimal PriceServing { get; set; }
        public int PrepTime { get; set; }
        public int CookTime { get; set; }
        public int ReadyInMinutes { get; set; }
        [Column(TypeName = "text")]
        public string RawInstructions { get; set; }
        public int CreateByUserId { get; set; }
        public string SourceOfRecipeName { get; set; } // used to reference source name
        public string SourceOfRecipeLink { get; set; } // used to reference SpoonAcular or source
        public string SpoonacularId { get; set; }
        public string CreditsText { get; set; }
        public int NumberStars { get; set; }
        public int NumberFavourites { get; set; }
        public int NumberOfTimesCooked { get; set; }

        [Timestamp]
        public byte[] RowVer { get; set; }

        public DateTimeOffset CreatedAt { get; set; }

        public ICollection<RecipeAllergyWarning> RecipeAllergyWarning { get; set; }
        public ICollection<RecipeCuisineType> RecipeCuisineType { get; set; }
        public ICollection<RecipeDishTag> RecipeDishTag { get; set; }
        public ICollection<RecipeDishType> RecipeDishType { get; set; }
        public ICollection<RecipeHealthLabel> RecipeHealthLabel { get; set; }
        public ICollection<RecipeSteppedInstruction> SteppedInstruction { get; set; }
        public ICollection<RecipeIngredientList> RecipeIngredientList { get; set; }
        public ICollection<RecipeReview> RecipeReview { get; set; }
        public ICollection<RecipePicture> RecipePicture { get; set; }
    }
}
