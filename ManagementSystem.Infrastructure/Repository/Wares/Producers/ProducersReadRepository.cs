using MagamentSystem.Application.Repository.WaresRepository.Producers;
using ManagamentSystem.Core.Entities.Wares;

namespace ManagementSystem.Infrastructure.Repository.Wares.Producers
{
	public class ProducersReadRepository : ReadRepository<Producer>, IProducerReadRepository
	{
		public ProducersReadRepository(ManagamentContext context) : base(context)
		{
		}
	}
}
