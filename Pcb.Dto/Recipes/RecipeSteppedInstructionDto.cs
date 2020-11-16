using System;

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
    }
}
