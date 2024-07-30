using MagamentSystem.Application.Repository.UserRepository.CustomIdentity;
using ManagamentSystem.Core.Entities.CustomIdentity;

namespace ManagementSystem.Infrastructure.Repository.Users.CustomAuthorization
{
	public class CustomPermissionReadRepository : ReadRepository<CustomPermission>, ICustomPermissionReadRepository
	{
		public CustomPermissionReadRepository(ManagamentContext context) : base(context)
		{
		}
	}
}
