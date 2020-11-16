using Pcb.Common.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pcb.Dto.Ingredient
{
    public class IngredientNutritionDto
    {
        public int Id { get; set; }
        public int IngredientId { get; set; }

        public string Title { get; set; }
        public decimal Amount { get; set; }
        public int PercentOfDailyNeeds { get; set; }
        public NutritionUnit Unit { get; set; }




        public byte[] RowVer { get; set; }
        public DateTimeOffset CreatedAt { get; set; }

    }
}
