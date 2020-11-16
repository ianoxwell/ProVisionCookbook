using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Pcb.Database.Context.Models
{
    [Table("RecipeHealthLabel", Schema = "map")]
    public partial class RecipeHealthLabel
    {
        public int Id { get; set; }
        public int RecipeId { get; set; }
        public int HealthLabelId { get; set; }

        public DateTimeOffset CreatedAt { get; set; }

        [Timestamp]
        public byte[] RowVer { get; set; }

        public Recipe Recipe { get; set; }

        public HealthLabel HealthLabel { get; set; }
    }
}
