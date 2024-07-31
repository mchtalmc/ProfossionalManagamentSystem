namespace ManagamentSystem.Core.Entities.CustomIdentity
{
	public class UserPermission :BaseEntity
	{
        

        public int AppUsersId { get; set; }
        public int CustomPermissionsId { get; set; }
        public AppUser AppUser { get; set; }
        public CustomPermission CustomPermission { get; set; }
    }
}
