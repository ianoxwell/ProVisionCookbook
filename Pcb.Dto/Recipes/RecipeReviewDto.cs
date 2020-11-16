using System;

namespace Pcb.Dto.Recipes
{
    public class RecipeReviewDto
    {
        public int Id { get; set; }
        public int RecipeId { get; set; }
        public string Title { get; set; }
        public string Review { get; set; }
        public int Rating { get; set; }
        public int UserId { get; set; }


        public byte[] RowVer { get; set; }
        public DateTimeOffset CreatedAt { get; set; }

    }
}
