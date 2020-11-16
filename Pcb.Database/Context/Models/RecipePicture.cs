using Pcb.Common.Enums;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pcb.Database.Context.Models
{
    [Table("RecipePicture", Schema = "dbo")]
    public partial class RecipePicture
    {
        public int Id { get; set; }
        public int RecipeId { get; set; }
        public string Title { get; set; }
        public string FileLink { get; set; }
        public byte[] Picture { get; set; }
        public PicturePosition PicturePosition { get; set; }


        [Timestamp]
        public byte[] RowVer { get; set; }

        public Recipe Recipe { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
    }
}
