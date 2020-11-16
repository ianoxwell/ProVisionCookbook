using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Pcb.Database.Context.Models
{
    [Table("IngredientAllergyWarning", Schema = "map")]
    public partial class IngredientAllergyWarning
    {
        public int Id { get; set; }
        public int IngredientId { get; set; }
        public int AllergyWarningId { get; set; }

        public DateTimeOffset CreatedAt { get; set; }

        [Timestamp]
        public byte[] RowVer { get; set; }

        public Ingredient Ingredient { get; set; }
        public AllergyWarning AllergyWarning { get; set; }
    }
}
