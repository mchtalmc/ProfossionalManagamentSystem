namespace MagamentSystem.Application.DataTransferObject.Wares.Dealer
{
	public class CreateDealerRequest
	{
		public string Name { get; set; }
		public string Location { get; set; }
		public string Phone { get; set; }
		public string Email { get; set; }
        public int AddedBy { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
