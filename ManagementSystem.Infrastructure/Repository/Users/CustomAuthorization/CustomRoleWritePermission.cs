using MagamentSystem.Application.Repository.UserRepository.CustomIdentity;
using ManagamentSystem.Core.Entities.CustomIdentity;

namespace ManagementSystem.Infrastructure.Repository.Users.CustomAuthorization
{
	public class CustomRoleWritePermission : WriteRepository<CustomRole>, ICustomRoleWriteRepository
	{
		public CustomRoleWritePermission(ManagamentContext context) : base(context)
		{
		}
	}
}
