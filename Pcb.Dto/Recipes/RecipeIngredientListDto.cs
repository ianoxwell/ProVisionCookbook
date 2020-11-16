using Pcb.Dto.Ingredient;
using Pcb.Dto.Reference;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pcb.Dto.Recipes
{
    public class RecipeIngredientListDto
    {
        public int Id { get; set; }
        public int RecipeId { get; set; }
        public int IngredientId { get; set; }
        public IngredientDto Ingredient { get; set; }
        public int Quantity { get; set; }
        public int Preference { get; set; }
        public ReferenceItemEx IngredientState { get; set; }
        public ReferenceItemMeasurement MeasurementUnit { get; set; }

        public byte[] RowVer { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
    }
}
