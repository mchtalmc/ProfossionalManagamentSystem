namespace MagamentSystem.Application.DataTransferObject.Wares.MarketPlace
{
	public class RemoveMarketPlaceRequest
	{
        public int Id { get; set; }
        public int RemovedBy { get; set; }
        public DateTime RemovedDate { get; set; }
    }
}
