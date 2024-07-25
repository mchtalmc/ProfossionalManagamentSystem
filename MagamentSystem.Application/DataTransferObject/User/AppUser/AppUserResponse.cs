namespace MagamentSystem.Application.DataTransferObject.User.AppUser
{
	public class AppUserResponse
	{
        public int Id { get; set; }
        public string Name { get; set; }
		public string Email { get; set; }
		public string PhoneNumber { get; set; }
		public string Address { get; set; }
		public string Password { get; set; }
		public bool IsBlocked { get; set; }
		public string Title { get; set; }
		public bool Gender { get; set; }
		public int AddedBy { get; set; }
        public int ModifiedBy { get; set; }
        public int RemovedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
        public DateTime RemovedDate { get; set; }
        public DateTime CreatedDate { get; set; }
	}
}
