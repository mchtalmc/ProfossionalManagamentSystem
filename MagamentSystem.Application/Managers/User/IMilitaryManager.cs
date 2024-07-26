using MagamentSystem.Application.DataTransferObject;
using MagamentSystem.Application.DataTransferObject.User.Military;

namespace MagamentSystem.Application.Managers.User
{
	public interface IMilitaryManager
	{
		Task<BaseResponse<bool>> CreateMilitaryStatus(CreateMilitaryRequest request);
		Task<BaseResponse<bool>> UpdateMilitaryStatus(UpdateMilitaryRequest request);
		Task<BaseResponse<bool>> DeleteMilitaryStatus(RemoveMilitaryRequest request);
		BaseResponse<List<MilitaryResponse>> GetAllMilitaryStatus();
		BaseResponse<List<MilitaryResponse>> GetAllFilterMilitaryStatus(FilterMilitaryRequest request);
		BaseResponse<MilitaryResponse> GetMilitaryStatutsFilter(FilterMilitaryRequest request);
		Task<BaseResponse<MilitaryResponse>> GetMilitaryStatusById(int id);
	}
}
