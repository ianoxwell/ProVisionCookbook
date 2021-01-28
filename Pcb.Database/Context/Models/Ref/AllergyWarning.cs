using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace Pcb.Database.Context.Models
{
    [Table("AllergyWarning", Schema = "ref")]
    public partial class AllergyWarning
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [AllowNull]
        public string Summary { get; set; }
        [AllowNull]
        public string AltTitle { get; set; }
        public int OnlineId { get; set; }
        [AllowNull]
        public string Symbol { get; set; }
        public DateTimeOffset CreatedAt { get; set; }

        [Timestamp]
        public byte[] RowVer { get; set; }

        public ICollection<RecipeAllergyWarning> RecipeAllergyWarning { get; set; }
        public ICollection<IngredientAllergyWarning> IngredientAllergyWarning { get; set; }
    }
}
