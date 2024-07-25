using AutoMapper;
using MagamentSystem.Application.DataTransferObject.Wares.Dealer;
using ManagamentSystem.Core.Entities.Wares;

namespace ManagementSystem.Infrastructure.Helper.AutoMapper.WaresMapper
{
	public class DealersMapper : Profile
	{
        public DealersMapper()
        {
            CreateMap<Dealer, CreateDealerRequest>().ReverseMap();
            CreateMap<Dealer, UpdateDealerRequest>().ReverseMap();
            CreateMap<Dealer, DealerResponse>().ReverseMap();
            CreateMap<List<Dealer>, List<DealerResponse>>().ReverseMap();
        }
    }
}
