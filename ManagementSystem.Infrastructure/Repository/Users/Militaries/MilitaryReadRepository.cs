using MagamentSystem.Application.Repository.UserRepository.Military;
using ManagamentSystem.Core.Entities.UserInformatıons;

namespace ManagementSystem.Infrastructure.Repository.Users.Militaries
{
	public class MilitaryReadRepository : ReadRepository<MilitaryStatus>, IMilitaryReadRepository
	{
		public MilitaryReadRepository(ManagamentContext context) : base(context)
		{
		}
	}
}
