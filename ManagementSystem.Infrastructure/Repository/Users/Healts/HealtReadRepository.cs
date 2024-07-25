using MagamentSystem.Application.Repository.UserRepository.Healts;
using ManagamentSystem.Core.Entities.UserInformatıons;

namespace ManagementSystem.Infrastructure.Repository.Users.Healts
{
	public class HealtReadRepository : ReadRepository<HealthStatus>, IHealtReadRepository
	{
		public HealtReadRepository(ManagamentContext context) : base(context)
		{
		}
	}
}
