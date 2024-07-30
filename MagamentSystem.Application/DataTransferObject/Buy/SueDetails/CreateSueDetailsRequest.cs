namespace MagamentSystem.Application.DataTransferObject.Buy.SueDetails
{
	public class CreateSueDetailsRequest
	{
		public string Location { get; set; }
		public int Quantity { get; set; }
		public string Currency { get; set; }
		public int UnitPrice { get; set; }
		public int Cost { get; set; }
		public string Description { get; set; }
		public string DeliveryLocation { get; set; }
		public string JobName { get; set; }
		public DateTime StartedDate { get; set; }
		public DateTime EndDate { get; set; }
		public int ProductId { get; set; }
        public int AddedBy { get; set; }
        public bool IsStatus { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
