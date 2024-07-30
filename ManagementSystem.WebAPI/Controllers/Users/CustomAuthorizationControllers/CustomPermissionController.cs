using MagamentSystem.Application.Models.Authorization.CustomPermissionModel;
using MagamentSystem.Application.Services.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ManagementSystem.WebAPI.Controllers.Users.CustomAuthorizationControllers
{
	[Route("api/[controller]")]
	[ApiExplorerSettings(GroupName = "permissionService")]
	[ApiController]
	public class CustomPermissionController : ControllerBase
	{
		private readonly ICustomPermissionService _customPermissionService;

		public CustomPermissionController(ICustomPermissionService customPermissionService)
		{
			_customPermissionService = customPermissionService;
		}
		[HttpPost("CreatePermission")]
		public async Task<IActionResult> CreatePermission([FromBody]CreatePermission request)
		{
			var response = await _customPermissionService.AddPermisson(request);
			return Ok(response);
		}
		[HttpPut("UpdatePermission")]
		public async Task<IActionResult> UpdatePermission([FromBody]UpdatePermission request)
		{
			var response = await _customPermissionService.UpdatePermisson(request);
			return Ok(response);
		}
		[HttpGet("PermissionById{permissionById}")]
		public async Task<IActionResult> PermissionById([FromRoute]int permissionById)
		{
			var response = await _customPermissionService.GetResultPermissionById(permissionById);
			return Ok(response);
		}
		[HttpGet("PermissionList")]
		public IActionResult PermissionList()
		{
			var response= _customPermissionService.GetResultPermissionList();
			return Ok(response);
		}
	}
}
