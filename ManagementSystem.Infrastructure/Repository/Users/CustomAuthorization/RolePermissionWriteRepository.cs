using MagamentSystem.Application.Repository.UserRepository.CustomIdentity;
using ManagamentSystem.Core.Entities.CustomIdentity;

namespace ManagementSystem.Infrastructure.Repository.Users.CustomAuthorization
{
	public class RolePermissionWriteRepository : WriteRepository<RolePermission>, IRolePermissionWriteRepository
	{
		public RolePermissionWriteRepository(ManagamentContext context) : base(context)
		{
		}
	}
}
