using MagamentSystem.Application.DataTransferObject;
using MagamentSystem.Application.Models.Authorization.RolePermissionModel;

namespace MagamentSystem.Application.Services.Authorization
{
	public interface IRolePermissionService
	{
		Task<BaseResponse<object>> Add(CreateRolePermission roleClaim);
		Task<BaseResponse<object>> Update(UpdateRolePermission roleClaim);
		Task<BaseResponse<ResultRolePermission>> GetRoleClaimById(int id);
		BaseResponse<List<ResultRolePermission>> GetRoleClaimList();
	}
}
