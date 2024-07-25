namespace MagamentSystem.Application.DataTransferObject.Wares.MarketPlace
{
	public class UpdateMarketPlaceRequest
	{
        public int Id { get; set; }
		public string Name { get; set; }
		public string Location { get; set; }
		public int Capacity { get; set; }
        public int ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
