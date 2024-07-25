namespace MagamentSystem.Application.DataTransferObject.Wares.Producer
{
	public class RemoveProducerRequest
	{
        public int Id { get; set; }
        public int RemovedBy { get; set; }
        public DateTime RemovedDate { get; set; }
    }
}
