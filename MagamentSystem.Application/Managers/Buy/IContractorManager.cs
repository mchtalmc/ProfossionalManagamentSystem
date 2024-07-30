using MagamentSystem.Application.DataTransferObject;
using MagamentSystem.Application.DataTransferObject.Buy.Contractor;
using MagamentSystem.Application.DataTransferObject.User.AppUser;

namespace MagamentSystem.Application.Managers.Buy
{
	public interface IContractorManager
	{
		Task<BaseResponse<bool>> CreateContractor(CreateContractorRequest request);
		Task<BaseResponse<bool>> UpdateContractor(UpdateContractorRequest request);
		Task<BaseResponse<bool>> DeleteContractor(RemoveContractorRequest request);
		BaseResponse<List<ContractorResponse>> GetAllContractor();
		BaseResponse<List<ContractorResponse>> GetAllContractorFilter(FilterContractorRequest request);
		BaseResponse<ContractorResponse> GetContractorFilter(FilterContractorRequest request);
		Task<BaseResponse<ContractorResponse>> GetContractorById(int id);
	}
}
