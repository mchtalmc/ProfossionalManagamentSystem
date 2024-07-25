namespace MagamentSystem.Application.DataTransferObject.Buy.Contractor
{
	public class RemoveContractorRequest
	{
        public int Id { get; set; }
        public int RemovedBy { get; set; }
        public DateTime RemovedDate { get; set; }
    }
}
