using MagamentSystem.Application.Repository.BuyRepository.SueDetail;

namespace ManagementSystem.Infrastructure.Repository.Buy.SueDetails
{
	public class SueDetailsWriteRepository : WriteRepository<ManagamentSystem.Core.Entities.Buy.SueDetails>, ISueDetailsWriteRepository
	{
		public SueDetailsWriteRepository(ManagamentContext context) : base(context)
		{
		}
	}
}
