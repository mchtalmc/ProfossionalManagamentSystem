using MagamentSystem.Application.Repository.BuyRepository.SueDetail;

namespace ManagementSystem.Infrastructure.Repository.Buy.SueDetails
{
	public class SueDetailsReadRepository : ReadRepository<ManagamentSystem.Core.Entities.Buy.SueDetails>, ISueDetailsReadRepository
	{
		public SueDetailsReadRepository(ManagamentContext context) : base(context)
		{
		}
	}
}
