namespace MagamentSystem.Application.DataTransferObject.Wares.Dealer
{
	public class UpdateDealerRequest
	{
        public int Id { get; set; }
		public string Name { get; set; }
		public string Location { get; set; }
		public string Phone { get; set; }
		public string Email { get; set; }
        public int ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
