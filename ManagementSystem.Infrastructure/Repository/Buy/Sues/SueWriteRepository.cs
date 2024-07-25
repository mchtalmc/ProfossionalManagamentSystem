using MagamentSystem.Application.Repository.BuyRepository.Sues;
using ManagamentSystem.Core.Entities.Buy;

namespace ManagementSystem.Infrastructure.Repository.Buy.Sues
{
	public class SueWriteRepository : WriteRepository<Sue>, ISueWriteRepository
	{
		public SueWriteRepository(ManagamentContext context) : base(context)
		{
		}
	}
}
