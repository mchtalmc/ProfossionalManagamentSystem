using MagamentSystem.Application.Repository.UserRepository.Users;
using ManagamentSystem.Core.Entities;

namespace ManagementSystem.Infrastructure.Repository.Users.AppUsers
{
	public class AppUserReadRepository : ReadRepository<AppUser>, IAppUserReadRepository
	{
		public AppUserReadRepository(ManagamentContext context) : base(context)
		{
		}
	}
}
