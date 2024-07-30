namespace ManagamentSystem.Core.Entities.CustomIdentity
{
	public class CustomPermission :BaseEntity
	{
       
        public string Type { get; set; }
        public string Value  { get; set; }
        public ICollection<UserPermission?> UserPermissions { get; set; }
        public ICollection<RolePermission> RolePermissions { get; set; }
    }
}
