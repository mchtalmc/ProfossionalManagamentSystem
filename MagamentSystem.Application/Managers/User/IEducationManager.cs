using MagamentSystem.Application.DataTransferObject;
using MagamentSystem.Application.DataTransferObject.User.Education;

namespace MagamentSystem.Application.Managers.User
{
	public interface IEducationManager
	{
		Task<BaseResponse<bool>> CreateEducation(CreateEducationRequest request);
		Task<BaseResponse<bool>> UpdateEducation(UpdateEducationRequest request);
		Task<BaseResponse<bool>> DeleteEducation(RemoveEducationRequest request);
		BaseResponse<List<EducationResponse>> GetAllEducation();
		BaseResponse<List<EducationResponse>> GetAllEducationFilter(FilterEducationRequest request);
		BaseResponse<EducationResponse> GetEducationFilter(FilterEducationRequest request);
		Task<BaseResponse<EducationResponse>> GetEducationById(int id);
	}
}
