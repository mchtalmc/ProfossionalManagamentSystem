using MagamentSystem.Application.DataTransferObject;
using MagamentSystem.Application.DataTransferObject.User.AppUser;
using ManagamentSystem.Core.Entities;

namespace MagamentSystem.Application.Managers.User
{
	public interface IAppUserManager
	{
		Task<BaseResponse<bool>> CreateAppUser(CreateAppUserRequest request);
		Task<BaseResponse<bool>> UpdateAppUser(UpdateAppUserRequest request);
		Task<BaseResponse<bool>> DeleteAppUser(RemoveAppUserRequest request);
		BaseResponse<List<AppUserResponse>> GetAllAppUser();
		BaseResponse<List<AppUserResponse>> GetAllAppUserFilter(FilterAppUserRequest request);
		BaseResponse<AppUserResponse> GetAppUserFilter(FilterAppUserRequest request);
		Task<BaseResponse<AppUserResponse>> GetAppUserById(int id);
		AppUser CheckRegister(string email,  string password);


	}
}
