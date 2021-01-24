using Pcb.Dto.Reference;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pcb.Dto.Ingredient
{
    public class IngredientConversionDto
    {
        public int Id { get; set; }
        public int IngredientId { get; set; }
        public int Preference { get; set; }

        public ReferenceItemEx BaseState { get; set; }
        public ReferenceItemMeasurement BaseMeasurementUnit { get; set; }
        public double BaseQuantity { get; set; }

        public ReferenceItemEx ConvertToState { get; set; }
        public ReferenceItemMeasurement ConvertToMeasurementUnit { get; set; }
        public double ConvertToQuantity { get; set; }



        public byte[] RowVer { get; set; }
        public DateTimeOffset CreatedAt { get; set; }

    }
}
