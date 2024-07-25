using AutoMapper;
using MagamentSystem.Application.DataTransferObject.Wares.MarketPlace;
using ManagamentSystem.Core.Entities.Wares;

namespace ManagementSystem.Infrastructure.Helper.AutoMapper.WaresMapper
{
	public class MarketPlacesMapper : Profile
	{
        public MarketPlacesMapper()
        {
            CreateMap<MarketPlace, CraeteMarketPlaceRequest>().ReverseMap();
            CreateMap<MarketPlace, UpdateMarketPlaceRequest>().ReverseMap();
            CreateMap<MarketPlace, MarketPlaceResponse>().ReverseMap();
            CreateMap<List<MarketPlace>, List<MarketPlaceResponse>>().ReverseMap();

        }
    }
}
