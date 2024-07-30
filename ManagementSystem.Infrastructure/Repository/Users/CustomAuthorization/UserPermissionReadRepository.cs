using MagamentSystem.Application.Repository.UserRepository.CustomIdentity;
using ManagamentSystem.Core.Entities.CustomIdentity;

namespace ManagementSystem.Infrastructure.Repository.Users.CustomAuthorization
{
	public class UserPermissionReadRepository : ReadRepository<UserPermission>, IUserPermissionReadRepository
	{
		public UserPermissionReadRepository(ManagamentContext context) : base(context)
		{
		}
	}
}
