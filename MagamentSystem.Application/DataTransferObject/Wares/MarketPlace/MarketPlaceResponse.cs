namespace MagamentSystem.Application.DataTransferObject.Wares.MarketPlace
{
	public class MarketPlaceResponse
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Location { get; set; }
		public int Capacity { get; set; }
        public int AddedBy { get; set; }
        public int? ModifiedBy { get; set; }
        public int? RemovedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public DateTime? RemovedDate { get; set; }
        public bool IsStatus { get; set; }
    }
}
