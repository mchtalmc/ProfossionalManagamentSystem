namespace MagamentSystem.Application.Models.Authorization.UserPermissionModel
{
	public class UpdateUserPermission
	{
        public int Id { get; set; }
		public int AppUsersId { get; set; }
		public int CustomPermissionsId { get; set; }
	}
}
