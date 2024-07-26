using MagamentSystem.Application.Services.Security;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ManagementSystem.WebAPI.Controllers
{
    [Route("api/[controller]")]
	[ApiExplorerSettings(GroupName = "authService")]
	[ApiController]
	public class AuthController : ControllerBase
	{
		private readonly ITokenHandler _tokenHandler;

		public AuthController(ITokenHandler tokenHandler)
		{
			_tokenHandler = tokenHandler;
		}
		[HttpGet("GetCreateAuthToken")]
		public async Task<IActionResult> CreateToken()
		{
			var response = await _tokenHandler.GenerateToken();
			return Ok(response);
		}
	}
}
