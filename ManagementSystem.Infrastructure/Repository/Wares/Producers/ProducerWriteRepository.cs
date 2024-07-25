using MagamentSystem.Application.Repository.WaresRepository.Producers;
using ManagamentSystem.Core.Entities.Wares;

namespace ManagementSystem.Infrastructure.Repository.Wares.Producers
{
	public class ProducerWriteRepository : WriteRepository<Producer>, IProducerWriteRepository
	{
		public ProducerWriteRepository(ManagamentContext context) : base(context)
		{
		}
	}
}
