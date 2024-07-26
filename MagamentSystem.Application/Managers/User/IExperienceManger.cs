using MagamentSystem.Application.DataTransferObject;
using MagamentSystem.Application.DataTransferObject.User.Experience;

namespace MagamentSystem.Application.Managers.User
{
	public interface IExperienceManger
	{
		Task<BaseResponse<bool>> CreateExperience(CreateExperienceRequest request);
		Task<BaseResponse<bool>> UpdateExperience(UpdateExperienceRequest request);
		Task<BaseResponse<bool>> DeleteExperience(RemoveExperienceRequest request);
		BaseResponse<List<ExperienceResponse>> GetAllExperience();
		BaseResponse<List<ExperienceResponse>> GetAllExperienceFilter(FilterExperienceRequest request);
		BaseResponse<ExperienceResponse> GetExperienceFilter(FilterExperienceRequest request);
		Task<BaseResponse<ExperienceResponse>> GetExperienceById(int id);
	}
}
