using MagamentSystem.Application.DataTransferObject;
using MagamentSystem.Application.DataTransferObject.User.AppUser;

namespace MagamentSystem.Application.Managers.User
{
	public interface IAppUserManager
	{
		Task<BaseResponse<bool>> CreateAppUser(CreateAppUserRequest request);
		Task<BaseResponse<bool>> UpdateAppUser(UpdateAppUserRequest request);
		Task<BaseResponse<bool>> DeleteAppUser(RemoveAppUserRequest request);
		BaseResponse<List<AppUserResponse>> GetAllAppUser();
		BaseResponse<List<AppUserResponse>> GetAllAppUserFilter(FilterAppUserRequest request);
		Task<BaseResponse<AppUserResponse>> GetAppUserFilter(FilterAppUserRequest request);
		Task<BaseResponse<AppUserResponse>> GetAppUserById(int id);


	}
}
