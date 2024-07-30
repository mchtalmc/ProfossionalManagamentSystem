using MagamentSystem.Application.DataTransferObject.Identity;
using MagamentSystem.Application.Services.JwtTokenServices;
using MagamentSystem.Application.Services.Security;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ManagementSystem.WebAPI.Controllers.Identity
{
	[Route("api/[controller]")]
	[ApiExplorerSettings(GroupName = "authenticationService")]
	[ApiController]
	public class LoginController : ControllerBase
	{
		private readonly IAuthHandler _authHandler;
		private readonly ITokenHandler _tokenHandler;

		public LoginController(IAuthHandler authHandler, ITokenHandler tokenHandler)
		{
			_authHandler = authHandler;
			_tokenHandler = tokenHandler;
		}
		[HttpPost("LOGIN")]
		public async Task<IActionResult> Login([FromBody]UserLogin request)
		{
			var response= await _authHandler.Login(request);
			return Ok(response);
		}
		//[HttpGet("UserInfo")]
		//public async Task<IActionResult> UserInfo( )
		//{
		//	var token = HttpContext.Request.Headers["Authorization"].ToString().Replace("Bearer ", "");
		//	var user = await _tokenHandler.ValidateTokenAndGetUser(token);
		//	return Ok(user);
		//}
	}
}
