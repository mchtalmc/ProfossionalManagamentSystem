using MagamentSystem.Application.DataTransferObject;
using MagamentSystem.Application.Models.Authorization.CustomRoleModel;

namespace MagamentSystem.Application.Services.Authorization
{
	public interface ICustomRoleService
	{
		Task<BaseResponse<object>> Add(CreateRole role);
		Task<BaseResponse<object>> Update(UpdateRole role);
		Task<BaseResponse<ResultRole>> GetRoleById(int id);
		BaseResponse<List<ResultRole>> GetRoleList();
	}
}
