using MagamentSystem.Application.DataTransferObject;
using MagamentSystem.Application.DataTransferObject.Buy.SueDetails;

namespace MagamentSystem.Application.Managers.Buy
{
	public interface ISueDetailManager
	{
		Task<BaseResponse<bool>> CreateSueDetails(CreateSueDetailsRequest request);
		Task<BaseResponse<bool>> UpdateSueDetails(UpdateSueDetailsRequest request);
		Task<BaseResponse<bool>> DeleteSueDetails(RemoveSueDetailsRequest request);
		BaseResponse<List<SueDetailsReponse>> GetAllSueDetails();
		BaseResponse<List<SueDetailsReponse>> GetAllSueDetailsFilter(FilterSueDetailsRequest request);
		BaseResponse<SueDetailsReponse> GetSueDetailsFilter(FilterSueDetailsRequest request);
		Task<BaseResponse<SueDetailsReponse>> GetSueDetailsById(int id);
	}
}
