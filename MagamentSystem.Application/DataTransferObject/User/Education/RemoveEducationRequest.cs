namespace MagamentSystem.Application.DataTransferObject.User.Education
{
	public class RemoveEducationRequest
	{
        public int Id { get; set; }
        public int RemovedBy { get; set; }
        public DateTime RemovedDate { get; set; }
    }
}
