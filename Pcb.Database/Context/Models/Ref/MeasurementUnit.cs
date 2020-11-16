using Pcb.Common.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace Pcb.Database.Context.Models
{
    [Table("MeasurementUnit", Schema = "ref")]
    public partial class MeasurementUnit
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        public MeasurementType MeasurementType { get; set; }
        public string ShortName { get; set; }
        [AllowNull]
        public string AltShortName { get; set; }
        [ForeignKey("MeasurementUnit")]
        public int ConvertsToId { get; set; }
        public double Quantity { get; set; }
        public CountryCode CountryCode { get; set; }


        public DateTimeOffset CreatedAt { get; set; }

        [Timestamp]
        public byte[] RowVer { get; set; }

        [InverseProperty("MeasurementBaseUnit")]

        public virtual ICollection<IngredientConversion> MeasurementBaseUnits { get; set; }
        [InverseProperty("MeasurementConvertUnit")]

        public virtual ICollection<IngredientConversion> MeasurementConvertUnits { get; set; }
    }
}
