namespace MagamentSystem.Application.DataTransferObject.Wares.Dealer
{
	public class RemoveDealerRequest
	{
        public int Id { get; set; }
        public int RemovedBy { get; set; }
        public DateTime RemovedDate { get; set; }
    }
}
