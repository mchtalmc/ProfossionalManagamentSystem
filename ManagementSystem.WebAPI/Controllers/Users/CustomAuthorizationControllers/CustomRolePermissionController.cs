using MagamentSystem.Application.Models.Authorization.RolePermissionModel;
using MagamentSystem.Application.Services.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ManagementSystem.WebAPI.Controllers.Users.CustomAuthorizationControllers
{
	[Route("api/[controller]")]
	[ApiExplorerSettings(GroupName = "rolePermissionService")]
	[ApiController]
	public class CustomRolePermissionController : ControllerBase
	{
		private readonly IRolePermissionService _rolePermissionService;

		public CustomRolePermissionController(IRolePermissionService rolePermissionService)
		{
			_rolePermissionService = rolePermissionService;
		}

		[HttpPost("CreateRolePermission")]
		public async Task<IActionResult> CreateRolePermission([FromBody] CreateRolePermission request)
		{
			var response = await _rolePermissionService.Add(request);
			return Ok(response);
		}
		[HttpPut("UpdateRolePermission")]
		public async Task<IActionResult> UpdateRolePermission([FromBody] UpdateRolePermission request)
		{
			var response = await _rolePermissionService.Update(request);
			return Ok(response);
		}
		[HttpGet("RolePermissionList")]
		public IActionResult RolePermissionList()
		{
			var response = _rolePermissionService.GetRoleClaimList();
			return Ok(response);
		}
		[HttpGet("RolePermissionById{rolePermissionId}")]
		public async Task<IActionResult> RolePermissionById([FromRoute] int rolePermissionId)
		{
			var response = await _rolePermissionService.GetRoleClaimById(rolePermissionId);
			return Ok(response);
		}
	}
}
