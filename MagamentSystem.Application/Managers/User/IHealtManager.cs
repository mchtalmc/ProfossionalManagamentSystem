using MagamentSystem.Application.DataTransferObject;
using MagamentSystem.Application.DataTransferObject.User.Healt;

namespace MagamentSystem.Application.Managers.User
{
	public interface IHealtManager
	{
		Task<BaseResponse<bool>> CreateHealtStatus(CreateHealtyRequest request);
		Task<BaseResponse<bool>> UpdateHealtStatus(UpdateHealtyRequest request);
		Task<BaseResponse<bool>> DeleteHealtStatus(RemoveHealtyRequest request);
		BaseResponse<List<HealtResponse>> GetAllHealtStatus();
		BaseResponse<List<HealtResponse>> GetAllHealtStatusFilter(FilterHealtyRequest request);
		BaseResponse<HealtResponse> GetHealtStatusFilter(FilterHealtyRequest request);
		Task<BaseResponse<HealtResponse>> GetHealtStatusById(int id);
	}
}
