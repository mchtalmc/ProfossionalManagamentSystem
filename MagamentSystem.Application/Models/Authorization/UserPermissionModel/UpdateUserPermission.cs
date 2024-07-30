namespace MagamentSystem.Application.Models.Authorization.UserPermissionModel
{
	public class UpdateUserPermission
	{
        public int Id { get; set; }
		public int AppUserId { get; set; }
		public int CustomPermissionId { get; set; }
	}
}
