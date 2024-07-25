using MagamentSystem.Application.Repository.WaresRepository.Dealaers;
using ManagamentSystem.Core.Entities.Wares;

namespace ManagementSystem.Infrastructure.Repository.Wares.Dealers
{
	public class DealersWriteRepository : WriteRepository<Dealer>, IDealerWriteRepository
	{
		public DealersWriteRepository(ManagamentContext context) : base(context)
		{
		}
	}
}
