namespace MagamentSystem.Application.Models.Authorization.RolePermissionModel
{
	public class UpdateRolePermission
	{
        public int Id { get; set; }
		public int CustomRolesId { get; set; }
		public int CustomPermissionId { get; set; }
	}
}
