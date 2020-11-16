using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace Pcb.Database.Context.Models
{
    [Table("RecipeIngredientList", Schema = "dbo")]
    public partial class RecipeIngredientList
    {
        public int Id { get; set; }
        public int RecipeId { get; set; }
        public int IngredientId { get; set; }
        public int Quantity { get; set; }
        public int Preference { get; set; }
        public int IngredientStateId { get; set; }
        public int MeasurementUnitId { get; set; }

        [Timestamp]
        public byte[] RowVer { get; set; }

        public Recipe Recipe { get; set; }
        public Ingredient Ingredient { get; set; }
        public IngredientState IngredientState { get; set; }
        public MeasurementUnit MeasurementUnit { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
    }
}
