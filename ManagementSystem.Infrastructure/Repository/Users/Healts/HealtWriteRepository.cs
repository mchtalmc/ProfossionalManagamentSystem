using MagamentSystem.Application.Repository.UserRepository.Healts;
using ManagamentSystem.Core.Entities.UserInformatıons;

namespace ManagementSystem.Infrastructure.Repository.Users.Healts
{
	public class HealtWriteRepository : WriteRepository<HealthStatus>, IHealtWriteRepository
	{
		public HealtWriteRepository(ManagamentContext context) : base(context)
		{
		}
	}
}
