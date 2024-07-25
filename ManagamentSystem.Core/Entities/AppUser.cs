namespace ManagamentSystem.Core.Entities
{
	public class AppUser :  BaseEntity
	{
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string Password { get; set; }
        public bool IsBlocked { get; set; }
        public string Title { get; set; }
        public bool Gender { get; set; }




    }
}
