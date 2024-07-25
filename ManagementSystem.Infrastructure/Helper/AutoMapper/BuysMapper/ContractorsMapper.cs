using AutoMapper;
using MagamentSystem.Application.DataTransferObject.Buy.Contractor;
using ManagamentSystem.Core.Entities.Buy;

namespace ManagementSystem.Infrastructure.Helper.AutoMapper.BuysMapper
{
	public class ContractorsMapper : Profile
	{
        public ContractorsMapper()
        {
            CreateMap<Contractor, CreateContractorRequest>().ReverseMap();
            CreateMap<Contractor,UpdateContractorRequest>().ReverseMap();
            CreateMap<Contractor,ContractorResponse>().ReverseMap();
            CreateMap<List<Contractor>, List<ContractorResponse>>().ReverseMap();
        }
    }
}
