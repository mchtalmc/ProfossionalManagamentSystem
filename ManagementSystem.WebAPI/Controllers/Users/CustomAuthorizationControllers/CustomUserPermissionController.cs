using MagamentSystem.Application.Models.Authorization.UserPermissionModel;
using MagamentSystem.Application.Services.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ManagementSystem.WebAPI.Controllers.Users.CustomAuthorizationControllers
{
	[Route("api/[controller]")]
	[ApiExplorerSettings(GroupName = "userPermissionService")]
	[ApiController]
	public class CustomUserPermissionController : ControllerBase
	{
		private readonly IUserPermissionService _userPermissionService;

		public CustomUserPermissionController(IUserPermissionService userPermissionService)
		{
			_userPermissionService = userPermissionService;
		}
		[HttpPost("CreateUserPermission")]
		public async Task<IActionResult> CreateUserPermission([FromBody]CreateUserPermission request)
		{
			var response = await _userPermissionService.Add(request);
			return Ok(response);
		}
		[HttpPut("UpdateUserPermission")]
		public async Task<IActionResult> UpdateUserPermission([FromBody]UpdateUserPermission request)
		{
			var response = await _userPermissionService.Update(request);
			return Ok(response);
		}
		[HttpGet("UserPermissionById{userPermissionId}")]
		public async Task<IActionResult> UserPermissionById([FromRoute]int userPermissionId)
		{
			var response= await _userPermissionService.GetUserClaimById(userPermissionId);
			return Ok(response);
		}
	}
}
