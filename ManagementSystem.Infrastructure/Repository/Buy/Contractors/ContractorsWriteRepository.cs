using MagamentSystem.Application.Repository.BuyRepository.Contractors;
using ManagamentSystem.Core.Entities.Buy;

namespace ManagementSystem.Infrastructure.Repository.Buy.Contractors
{
	public class ContractorsWriteRepository : WriteRepository<Contractor>, IContractorWriteRepository
	{
		public ContractorsWriteRepository(ManagamentContext context) : base(context)
		{
		}
	}
}
