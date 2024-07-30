namespace MagamentSystem.Application.DataTransferObject.Wares.Product
{
	public class FilterProductRequest
	{
		public string? Brand { get; set; }
		public decimal? Price { get; set; }
		public bool? IsUsedProduct { get; set; }
		public int? CategoryId { get; set; }
		public int? ProducerId { get; set; }
		public int? DealerId { get; set; }
		public int? MarketPlaceId { get; set; }
	}
}
