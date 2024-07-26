namespace MagamentSystem.Application.DataTransferObject.Buy.SueDetails
{
	public class SueDetailsReponse
	{
		public int Id { get; set; }
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
        public int? ModifiedBy { get; set; }
        public int? RemovedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public DateTime? RemovedDate { get; set; }
    }
}
