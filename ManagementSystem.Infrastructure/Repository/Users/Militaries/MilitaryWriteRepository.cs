using MagamentSystem.Application.Repository.UserRepository.Military;
using ManagamentSystem.Core.Entities.UserInformatıons;

namespace ManagementSystem.Infrastructure.Repository.Users.Militaries
{
	public class MilitaryWriteRepository : WriteRepository<MilitaryStatus>, IMilitaryWriteRepository
	{
		public MilitaryWriteRepository(ManagamentContext context) : base(context)
		{
		}
	}
}
