using MagamentSystem.Application.DataTransferObject.User.AppUser;
using MagamentSystem.Application.Managers.User;
using Microsoft.AspNetCore.Mvc;

namespace ManagementSystem.WebAPI.Controllers.Users
{
	[Route("api/[controller]")]
	[ApiExplorerSettings(GroupName = "appUserService")]
	[ApiController]
	public class AppUserController : ControllerBase
	{
		private readonly IAppUserManager _appUserManager;

		public AppUserController(IAppUserManager appUserManager)
		{
			_appUserManager = appUserManager;
		}
		[HttpPost("CreateAppUser")]
		public async Task<IAppUserManager> CreateAppUser([FromBody] CreateAppUserRequest request)
		{
			var response= await _appUserManager.CreateAppUser(request);
			return (IAppUserManager)Ok(response);
		}
		[HttpPut("UpdateAppUser")]
		public async Task<IActionResult> UpdateAppUser([FromBody]UpdateAppUserRequest request)
		{
			var response = await _appUserManager.UpdateAppUser(request);
			return Ok(response);
		}
		[HttpDelete("RmeoveAppUser")]
		public async Task<IActionResult> RemoveAppUser([FromQuery] RemoveAppUserRequest request)
		{
			var response = await _appUserManager.DeleteAppUser(request);
			return Ok(response);
		}
		[HttpGet("AppUserList")]
		public  IActionResult AppUserList()
		{
			var response=  _appUserManager.GetAllAppUser();
			return Ok(response);
		}
		[HttpGet("AllAppUserFilter")]
		public IActionResult AllAppUserFilter([FromQuery]FilterAppUserRequest request)
		{
			var response = _appUserManager.GetAllAppUserFilter(request);
			return Ok(response);
		}
		[HttpGet("AppUserFilter")]
		public IActionResult AppUserFilter([FromQuery]FilterAppUserRequest request)
		{
			var response= _appUserManager.GetAppUserFilter(request);
			return Ok(response);
		}
		[HttpGet("AppUserById{appUserid}")]
		public async Task<IActionResult> AppUserById([FromRoute] int appUserid)
		{
			var response= await _appUserManager.GetAppUserById(appUserid);
			return Ok(response);
		}


	}
}
