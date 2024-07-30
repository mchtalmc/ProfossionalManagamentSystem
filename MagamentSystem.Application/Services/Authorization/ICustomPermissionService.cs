using MagamentSystem.Application.DataTransferObject;
using MagamentSystem.Application.Models.Authorization.CustomPermissionModel;

namespace MagamentSystem.Application.Services.Authorization
{
	public interface ICustomPermissionService
	{
		Task<BaseResponse<object>> AddPermisson(CreatePermission createPermisson);
		Task<BaseResponse<object>> UpdatePermisson(UpdatePermission updatePermission);
		Task<BaseResponse<ResultPermission>> GetResultPermissionById(int id);
		BaseResponse<List<ResultPermission>> GetResultPermissionList();
	}
}
