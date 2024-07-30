using MagamentSystem.Application.Repository.UserRepository.CustomIdentity;
using ManagamentSystem.Core.Entities.CustomIdentity;

namespace ManagementSystem.Infrastructure.Repository.Users.CustomAuthorization
{
	public class RolePermissionReadRepository : ReadRepository<RolePermission>, IRolePermissionReadRepository
	{
		public RolePermissionReadRepository(ManagamentContext context) : base(context)
		{
		}
	}
}
