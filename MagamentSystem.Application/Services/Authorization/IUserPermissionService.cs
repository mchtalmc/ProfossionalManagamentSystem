using MagamentSystem.Application.DataTransferObject;
using MagamentSystem.Application.Models.Authorization.UserPermissionModel;

namespace MagamentSystem.Application.Services.Authorization
{
	public interface IUserPermissionService
	{
		Task<BaseResponse<object>> Add(CreateUserPermission userClaim);
		Task<BaseResponse<object>> AddRange(List<CreateUserPermission> userClaims);
		Task<BaseResponse<object>> Update(UpdateUserPermission userClaim);
		Task<BaseResponse<ResultUserPermission>> GetUserClaimById(int id);
		BaseResponse<List<ResultUserPermission>> GetUserClaimList();
		List<string> GetUserPermissionWithUserId(int userId);

	}
}
