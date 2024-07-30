namespace ManagamentSystem.Core.Entities.CustomIdentity
{
	public class UserPermission :BaseEntity
	{
        

        public int AppUserId { get; set; }
        public int CustomPermissionId { get; set; }
        public AppUser AppUser { get; set; }
        public CustomPermission CustomPermission { get; set; }
    }
}
