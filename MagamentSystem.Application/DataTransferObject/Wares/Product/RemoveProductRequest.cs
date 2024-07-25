namespace MagamentSystem.Application.DataTransferObject.Wares.Product
{
	public class RemoveProductRequest
	{
        public int Id { get; set; }
        public int RemovedBy { get; set; }
        public DateTime RemovedDate { get; set; }
    }
}
