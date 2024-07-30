using MagamentSystem.Application.Models.Authorization.CustomRoleModel;
using MagamentSystem.Application.Models.Authorization.RolePermissionModel;
using MagamentSystem.Application.Services.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ManagementSystem.WebAPI.Controllers.Users.CustomAuthorizationControllers
{
	[Route("api/[controller]")]
	[ApiExplorerSettings(GroupName = "roleService")]
	[ApiController]
	public class CustomRoleController : ControllerBase
	{
		private readonly ICustomRoleService _customRoleService;

		public CustomRoleController(ICustomRoleService customRoleService)
		{
			_customRoleService = customRoleService;
		}
		[HttpPost("CreateRole")]
		public async Task<IActionResult> CreateRol([FromBody]CreateRole request)
		{
			var response = await _customRoleService.Add(request);
			return Ok(response);
		}
		[HttpPut("UpdateRole")]
		public async Task<IActionResult> UpdateRol([FromBody]UpdateRole request)
		{
			var response = await _customRoleService.Update(request);
			return Ok(response);
		}
		[HttpGet("RoleById{roleId}")]
		public async Task<IActionResult> RoleById([FromRoute]int roleId)
		{
			var response = await _customRoleService.GetRoleById(roleId);
			return Ok(response);
		}
		[HttpGet]
		public IActionResult RoleList()
		{
			var response = _customRoleService.GetRoleList();
			return Ok(response);
		}
	}
}
