using MagamentSystem.Application.Repository.BuyRepository.ContractInfos;
using ManagamentSystem.Core.Entities.Buy;

namespace ManagementSystem.Infrastructure.Repository.Buy.ContractInfos
{
	public class ContractInfosReadRepository : ReadRepository<ContractInfo>, IContractInfoReadRepository
	{
		public ContractInfosReadRepository(ManagamentContext context) : base(context)
		{
		}
	}
}
