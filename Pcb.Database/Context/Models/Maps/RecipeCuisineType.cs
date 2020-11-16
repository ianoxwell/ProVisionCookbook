using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Pcb.Database.Context.Models
{
    [Table("RecipeCuisineType", Schema = "map")]
    public partial class RecipeCuisineType
    {
        public int Id { get; set; }
        public int RecipeId { get; set; }
        public int CuisineTypeId { get; set; }

        public DateTimeOffset CreatedAt { get; set; }

        [Timestamp]
        public byte[] RowVer { get; set; }

        public Recipe Recipe { get; set; }

        public CuisineType CuisineType { get; set; }
    }
}
