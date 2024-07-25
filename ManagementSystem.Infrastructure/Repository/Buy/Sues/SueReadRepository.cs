using MagamentSystem.Application.Repository.BuyRepository.Sues;
using ManagamentSystem.Core.Entities.Buy;

namespace ManagementSystem.Infrastructure.Repository.Buy.Sues
{
	public class SueReadRepository : ReadRepository<Sue>, ISueReadRepository
	{
		public SueReadRepository(ManagamentContext context) : base(context)
		{
		}
	}
}
