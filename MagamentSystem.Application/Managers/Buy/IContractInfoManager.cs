using MagamentSystem.Application.DataTransferObject;
using MagamentSystem.Application.DataTransferObject.Buy.Contractİnfo;
using MagamentSystem.Application.DataTransferObject.User.AppUser;

namespace MagamentSystem.Application.Managers.Buy
{
	public interface IContractInfoManager
	{
		Task<BaseResponse<bool>> CreateContractInfo(CreateContractInfoRequest request);
		Task<BaseResponse<bool>> UpdateContractInfo(UpdateContractİnfoRequest request);
		Task<BaseResponse<bool>> DeleteContractInfo(RemoveContractİnfoRequest request);
		BaseResponse<List<ContractInfoResponse>> GetAllContractInfo();
		BaseResponse<List<ContractInfoResponse>> GetAllContractInfoFilter(FilterContractİnfoRequest request);
		BaseResponse<ContractInfoResponse> GetContractInfoFilter(FilterContractİnfoRequest request);
		Task<BaseResponse<ContractInfoResponse>> GetContractInfoById(int id);
	}
}
