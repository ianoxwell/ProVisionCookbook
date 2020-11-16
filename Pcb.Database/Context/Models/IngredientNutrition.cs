using Pcb.Common.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace Pcb.Database.Context.Models
{
    [Table("IngredientNutrition", Schema = "dbo")]
    public partial class IngredientNutrition
    {
        public int Id { get; set; }
        public int IngredientId { get; set; }

        public string Title { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Amount { get; set; }
        public int PercentOfDailyNeeds { get; set; }
        public NutritionUnit Unit { get; set; }



        [Timestamp]
        public byte[] RowVer { get; set; }
        public DateTimeOffset CreatedAt { get; set; }

        public Ingredient Ingredient { get; set; }
    }
}
