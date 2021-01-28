using Pcb.Database.Context.Models;
using System;
using System.Collections.Generic;

namespace Pcb.Dto.Recipes
{
    public class RecipeSteppedInstructionDto
    {
        public int Id { get; set; }
        public int RecipeId { get; set; }
        public int StepNumber { get; set; }
        public string StepDescription { get; set; }

        public byte[] RowVer { get; set; }
        public DateTimeOffset CreatedAt { get; set; }

        public List<Equipment> Equipment { get; set; }
        public List<RecipeIngredientList> RecipeIngredientList { get; set; }
    }
}
