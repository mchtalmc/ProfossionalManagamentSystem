using AutoMapper;
using MagamentSystem.Application.DataTransferObject.Buy.Sue;
using ManagamentSystem.Core.Entities.Buy;

namespace ManagementSystem.Infrastructure.Helper.AutoMapper.BuysMapper
{
	public class SueMapper : Profile
	{
        public SueMapper()
        {
            CreateMap<Sue,CreateSueRequest>().ReverseMap();
            CreateMap<Sue,UpdateSueRequest>().ReverseMap();
            CreateMap<Sue, SueResponse>().ReverseMap();
            CreateMap<List<Sue>, List<SueResponse>>().ReverseMap();
        }
    }
}
