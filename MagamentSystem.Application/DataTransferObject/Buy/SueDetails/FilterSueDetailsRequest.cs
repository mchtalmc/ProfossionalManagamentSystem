namespace MagamentSystem.Application.DataTransferObject.Buy.SueDetails
{
	public class FilterSueDetailsRequest
	{
		public string Location { get; set; }
		public int Quantity { get; set; }
		public string Currency { get; set; }
		public int UnitPrice { get; set; }
		public int Cost { get; set; }
		public string DeliveryLocation { get; set; }
		public string JobName { get; set; }
		public int ProductId { get; set; }
	}
}
