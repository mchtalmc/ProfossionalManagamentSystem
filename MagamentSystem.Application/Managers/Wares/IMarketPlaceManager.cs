using MagamentSystem.Application.DataTransferObject.Buy.Contractİnfo;
using MagamentSystem.Application.DataTransferObject;
using MagamentSystem.Application.DataTransferObject.Wares.MarketPlace;

namespace MagamentSystem.Application.Managers.Wares
{
	public interface IMarketPlaceManager
	{
		Task<BaseResponse<bool>> CreateMarketPlace(CraeteMarketPlaceRequest request);
		Task<BaseResponse<bool>> UpdateMarketPlace(UpdateMarketPlaceRequest request);
		Task<BaseResponse<bool>> DeleteMarketPlace(RemoveMarketPlaceRequest request);
		BaseResponse<List<MarketPlaceResponse>> GetAllMarketPlace();
		BaseResponse<List<MarketPlaceResponse>> GetAllMarketPlaceFilter(FilterMarketPlaceRequest request);
		BaseResponse<MarketPlaceResponse> GetMarketPlaceFilter(FilterMarketPlaceRequest request);
		Task<BaseResponse<MarketPlaceResponse>> GetMarketPlaceById(int id);
	}
}
