using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace Pcb.Database.Context.Models
{
    [Table("RecipeReview", Schema = "dbo")]
    public partial class RecipeReview
    {
        public int Id { get; set; }
        public int RecipeId { get; set; }
        public string Title { get; set; }
        public string Review { get; set; }
        [Range(0, 10)]
        public int Rating { get; set; }
        public int UserId { get; set; }


        [Timestamp]
        public byte[] RowVer { get; set; }
        public DateTimeOffset CreatedAt { get; set; }

        public Recipe Recipe { get; set; }
        public User User { get; set; }
    }
}
