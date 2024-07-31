namespace ManagamentSystem.Core.Entities.CustomIdentity
{
	public class RolePermission :BaseEntity
	{

		public int CustomRolesId { get; set; }
		public int CustomPermissionsId { get; set; }
		public CustomRole CustomRoles { get; set; }
        public CustomPermission CustomPermissions { get; set; }

    }
}
