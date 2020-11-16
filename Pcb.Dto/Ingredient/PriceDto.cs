using Pcb.Common.Enums;

namespace Pcb.Dto.Ingredient
{
	public class PriceDto
	{
		public string BrandName { get; set; }
		public decimal? Price { get; set; }
		public decimal? Quantity { get; set; }
		public MeasurementType? Measurement { get; set; }
		public string StoreName { get; set; }
		public string ApiLink { get; set; }
	}
}