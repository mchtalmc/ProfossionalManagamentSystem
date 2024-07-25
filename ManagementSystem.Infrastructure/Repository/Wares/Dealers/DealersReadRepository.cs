using MagamentSystem.Application.Repository.WaresRepository.Dealaers;
using ManagamentSystem.Core.Entities.Wares;

namespace ManagementSystem.Infrastructure.Repository.Wares.Dealers
{
	public class DealersReadRepository : ReadRepository<Dealer>, IDealerReadRepository
	{
		public DealersReadRepository(ManagamentContext context) : base(context)
		{
		}
	}
}
