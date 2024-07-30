namespace ManagamentSystem.Core.Entities.CustomIdentity
{
	public class RolePermission :BaseEntity
	{
    
        public int RoleId { get; set; }
        public int PermissionId { get; set; }
        public CustomRole CustomRole { get; set; }
        public CustomPermission CustomPermission { get; set; }

    }
}
