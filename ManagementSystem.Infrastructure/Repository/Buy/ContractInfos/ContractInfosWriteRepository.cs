using MagamentSystem.Application.Repository.BuyRepository.ContractInfos;
using ManagamentSystem.Core.Entities.Buy;

namespace ManagementSystem.Infrastructure.Repository.Buy.ContractInfos
{
	public class ContractInfosWriteRepository : WriteRepository<ContractInfo>, IContractInfoWriteRepository
	{
		public ContractInfosWriteRepository(ManagamentContext context) : base(context)
		{
		}
	}
}
