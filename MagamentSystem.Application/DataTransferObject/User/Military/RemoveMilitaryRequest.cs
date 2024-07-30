namespace MagamentSystem.Application.DataTransferObject.User.Military
{
	public class RemoveMilitaryRequest
	{
        public int Id { get; set; }
        public int RemovedBy { get; set; }
        public DateTime RemovedDate { get; set; } = DateTime.UtcNow;
    }
}
