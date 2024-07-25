namespace MagamentSystem.Application.DataTransferObject.User.AppUser
{
	public class RemoveAppUserRequest
	{
        public int Id { get; set; }
        public int RemovedBy { get; set; }
        public DateTime RemovedDate { get; set; }
    }
}
