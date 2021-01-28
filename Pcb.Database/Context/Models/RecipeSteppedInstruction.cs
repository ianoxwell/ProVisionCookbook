using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace Pcb.Database.Context.Models
{
    [Table("RecipeSteppedInstruction", Schema = "dbo")]
    public partial class RecipeSteppedInstruction
    {
        public int Id { get; set; }
        public int RecipeId { get; set; }
        public int StepNumber { get; set; }
        public string StepDescription { get; set; }

        [Timestamp]
        public byte[] RowVer { get; set; }

        public Recipe Recipe { get; set; }
        public DateTimeOffset CreatedAt { get; set; }

        public ICollection<Equipment> Equipment { get; set; }
        public ICollection<RecipeIngredientList> RecipeIngredientList { get; set; }
    }
}
