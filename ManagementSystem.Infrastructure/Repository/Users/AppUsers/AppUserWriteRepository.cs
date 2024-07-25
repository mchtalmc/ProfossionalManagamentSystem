using MagamentSystem.Application.Repository.UserRepository.Users;
using ManagamentSystem.Core.Entities;

namespace ManagementSystem.Infrastructure.Repository.Users.AppUsers
{
	public class AppUserWriteRepository : WriteRepository<AppUser>, IAppUserWriteRepository
	{
		public AppUserWriteRepository(ManagamentContext context) : base(context)
		{
		}
	}
}
