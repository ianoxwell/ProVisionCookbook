using Pcb.Common.Enums;
using System;

namespace Pcb.Dto.Recipes
{
    public class RecipePictureDto
    {
        public int Id { get; set; }
        public int RecipeId { get; set; }
        public string Title { get; set; }
        public string FileLink { get; set; }
        public byte[] Picture { get; set; }
        public PicturePosition PicturePosition { get; set; }

        public byte[] RowVer { get; set; }
        public DateTimeOffset CreatedAt { get; set; }

    }
}
