namespace MagamentSystem.Application.Models.Authorization.RolePermissionModel
{
	public class UpdateRolePermission
	{
        public int Id { get; set; }
		public int RoleId { get; set; }
		public int PermissionId { get; set; }
	}
}
