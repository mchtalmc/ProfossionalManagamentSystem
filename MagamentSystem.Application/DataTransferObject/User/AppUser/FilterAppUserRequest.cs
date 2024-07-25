namespace MagamentSystem.Application.DataTransferObject.User.AppUser
{
	public class FilterAppUserRequest
	{
		public string Name { get; set; }
		public string Address { get; set; }
		public bool IsBlocked { get; set; }
		public string Title { get; set; }
		public bool Gender { get; set; }
	}
}
