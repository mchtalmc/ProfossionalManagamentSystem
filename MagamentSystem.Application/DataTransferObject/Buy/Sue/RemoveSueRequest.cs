namespace MagamentSystem.Application.DataTransferObject.Buy.Sue
{
	public class RemoveSueRequest
	{
        public int Id { get; set; }
        public int RemovedBy { get; set; }
        public DateTime RemovedDate { get; set; }
    }
}
