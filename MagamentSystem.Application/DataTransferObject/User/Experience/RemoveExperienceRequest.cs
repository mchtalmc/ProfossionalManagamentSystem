namespace MagamentSystem.Application.DataTransferObject.User.Experience
{
	public class RemoveExperienceRequest
	{
        public int Id { get; set; }
        public int RemovedBy { get; set; }
        public DateTime RemovedDate { get; set; }
    }
}
