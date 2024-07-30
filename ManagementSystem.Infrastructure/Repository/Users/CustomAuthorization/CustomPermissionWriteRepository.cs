using MagamentSystem.Application.Repository.UserRepository.CustomIdentity;
using ManagamentSystem.Core.Entities.CustomIdentity;

namespace ManagementSystem.Infrastructure.Repository.Users.CustomAuthorization
{
	public class CustomPermissionWriteRepository : WriteRepository<CustomPermission>, ICustomPermissionWriteRepository
	{
		public CustomPermissionWriteRepository(ManagamentContext context) : base(context)
		{
		}
	}
}
