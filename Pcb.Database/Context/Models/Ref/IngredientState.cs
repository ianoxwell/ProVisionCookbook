﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace Pcb.Database.Context.Models
{
    [Table("IngredientState", Schema = "ref")]
    public partial class IngredientState
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [AllowNull]
        public string Summary { get; set; }
        [AllowNull]
        public string Symbol { get; set; }
        public DateTimeOffset CreatedAt { get; set; }

        [Timestamp]
        public byte[] RowVer { get; set; }

        public ICollection<Ingredient> Ingredient { get; set; }
        [InverseProperty("IngredientBaseConversionState")]
        public virtual ICollection<IngredientConversion> IngredientBaseConversions { get; set; }
        [InverseProperty("IngredientConvertConversionState")]
        public virtual ICollection<IngredientConversion> IngredientConvertConversionState { get; set; }
    }
}
