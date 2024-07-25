namespace MagamentSystem.Application.DataTransferObject.Wares.Dealer
{
	public class DealerResponse
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Location { get; set; }
		public string Phone { get; set; }
		public string Email { get; set; }
        public int AddedBy { get; set; }
        public int ModifiedBy { get; set; }
        public int RemovedBy { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public DateTime RemovedDate { get; set; }
    }
}
