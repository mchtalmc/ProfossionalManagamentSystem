namespace MagamentSystem.Application.DataTransferObject.Wares.MarketPlace
{
	public class CraeteMarketPlaceRequest
	{
		public string Name { get; set; }
		public string Location { get; set; }
		public int Capacity { get; set; }
        public int AddedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsStatus { get; set; }
    }
}
