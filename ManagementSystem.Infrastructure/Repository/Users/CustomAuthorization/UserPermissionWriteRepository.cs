using MagamentSystem.Application.Repository.UserRepository.CustomIdentity;
using ManagamentSystem.Core.Entities.CustomIdentity;

namespace ManagementSystem.Infrastructure.Repository.Users.CustomAuthorization
{
	public class UserPermissionWriteRepository : WriteRepository<UserPermission>, IUserPermissionWriteRepository
	{
		public UserPermissionWriteRepository(ManagamentContext context) : base(context)
		{
		}
	}
}
