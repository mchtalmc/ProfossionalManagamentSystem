namespace MagamentSystem.Application.DataTransferObject.Buy.SueDetails
{
	public class RemoveSueDetailsRequest
	{
        public int Id { get; set; }
        public int RemovedBy { get; set; }
        public DateTime RemovedDate { get; set; }
    }
}
