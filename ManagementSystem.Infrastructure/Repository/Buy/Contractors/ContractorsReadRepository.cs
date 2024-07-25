using MagamentSystem.Application.Repository.BuyRepository.Contractors;
using ManagamentSystem.Core.Entities.Buy;

namespace ManagementSystem.Infrastructure.Repository.Buy.Contractors
{
	public class ContractorsReadRepository : ReadRepository<Contractor>, IContractorReadRepository
	{
		public ContractorsReadRepository(ManagamentContext context) : base(context)
		{
		}
	}
}
