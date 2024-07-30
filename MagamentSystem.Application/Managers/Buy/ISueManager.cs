using MagamentSystem.Application.DataTransferObject;
using MagamentSystem.Application.DataTransferObject.Buy.Sue;

namespace MagamentSystem.Application.Managers.Buy
{
	public interface ISueManager
	{
		Task<BaseResponse<bool>> CreateSue(CreateSueRequest request);
		Task<BaseResponse<bool>> UpdateSue(UpdateSueRequest request);
		Task<BaseResponse<bool>> DeleteSue(RemoveSueRequest request);
		BaseResponse<List<SueResponse>> GetAllSue();
		BaseResponse<List<SueResponse>> GetAllSueFilter(FilterSueRequest request);
		BaseResponse<SueResponse> GetSueFilter(FilterSueRequest request);
		Task<BaseResponse<SueResponse>> GetSueById(int id);
	}
}
