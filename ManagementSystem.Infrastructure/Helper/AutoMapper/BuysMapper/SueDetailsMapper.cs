using AutoMapper;
using MagamentSystem.Application.DataTransferObject.Buy.SueDetails;
using ManagamentSystem.Core.Entities.Buy;

namespace ManagementSystem.Infrastructure.Helper.AutoMapper.BuysMapper
{
	public class SueDetailsMapper : Profile
	{
        public SueDetailsMapper()
        {
            CreateMap<SueDetails, CreateSueDetailsRequest>().ReverseMap();
            CreateMap<SueDetails, UpdateSueDetailsRequest>().ReverseMap();
            CreateMap<SueDetails, SueDetailsReponse>().ReverseMap();
            CreateMap<List<SueDetails>, List<SueDetailsReponse>>().ReverseMap();
        }
    }
}
