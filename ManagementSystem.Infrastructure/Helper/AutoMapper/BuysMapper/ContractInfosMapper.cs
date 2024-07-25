using AutoMapper;
using MagamentSystem.Application.DataTransferObject.Buy.Contractİnfo;
using ManagamentSystem.Core.Entities.Buy;

namespace ManagementSystem.Infrastructure.Helper.AutoMapper.BuysMapper
{
	public class ContractInfosMapper : Profile
	{
        public ContractInfosMapper()
        {
            CreateMap<ContractInfo, CreateContractInfoRequest>().ReverseMap();
            CreateMap<ContractInfo,UpdateContractİnfoRequest>().ReverseMap();
            CreateMap<ContractInfo,ContractInfoResponse>().ReverseMap();
            CreateMap<List<ContractInfo>, List<ContractInfoResponse>>().ReverseMap();
        }
    }
}
