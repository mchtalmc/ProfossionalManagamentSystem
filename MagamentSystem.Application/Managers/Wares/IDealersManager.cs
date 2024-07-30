using MagamentSystem.Application.DataTransferObject;
using MagamentSystem.Application.DataTransferObject.Wares.Dealer;

namespace MagamentSystem.Application.Managers.Wares
{
	public interface IDealersManager
	{
		Task<BaseResponse<bool>> CreateDealers(CreateDealerRequest request);
		Task<BaseResponse<bool>> UpdateDealers(UpdateDealerRequest request);
		Task<BaseResponse<bool>> DeleteDealers(RemoveDealerRequest request);
		BaseResponse<List<DealerResponse>> GetAllDealers();
		BaseResponse<List<DealerResponse>> GetAllDealersFilter(FilterDealerRequest request);
		BaseResponse<DealerResponse> GetDealersFilter(FilterDealerRequest request);
		Task<BaseResponse<DealerResponse>> GetDealersById(int id);
	}
}
