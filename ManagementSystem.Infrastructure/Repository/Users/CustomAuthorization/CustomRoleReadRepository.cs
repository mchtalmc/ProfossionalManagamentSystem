using MagamentSystem.Application.Repository.UserRepository.CustomIdentity;
using ManagamentSystem.Core.Entities.CustomIdentity;

namespace ManagementSystem.Infrastructure.Repository.Users.CustomAuthorization
{
	public class CustomRoleReadRepository : ReadRepository<CustomRole>, ICustomRoleReadRepository
	{
		public CustomRoleReadRepository(ManagamentContext context) : base(context)
		{
		}
	}
}
