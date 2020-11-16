using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace Pcb.Database.Context.Models
{
    [Table("IngredientConversion", Schema = "dbo")]
    public partial class IngredientConversion
    {
        [Key]
        public int Id { get; set; }
        public int IngredientId { get; set; }

        public int? BaseStateId { get; set; }

        public int? BaseMeasurementUnitId { get; set; }
        public double BaseQuantity { get; set; }

        public int? ConvertToStateId { get; set; }
        public int? ConvertToMeasurementUnitId { get; set; }
        public double ConvertToQuantity { get; set; }



        [Timestamp]
        public byte[] RowVer { get; set; }
        public DateTimeOffset CreatedAt { get; set; }

        public Ingredient Ingredient { get; set; }
        [ForeignKey("BaseMeasurementUnitId")]

        public virtual MeasurementUnit MeasurementBaseUnit { get; set; }
        [ForeignKey("ConvertToMeasurementUnitId")]

        public virtual MeasurementUnit MeasurementConvertUnit { get; set; }
        [ForeignKey("BaseStateId")]
        public virtual IngredientState IngredientBaseConversionState { get; set; }
        [ForeignKey("ConvertToStateId")]

        public virtual IngredientState IngredientConvertConversionState { get; set; }
    }
}
