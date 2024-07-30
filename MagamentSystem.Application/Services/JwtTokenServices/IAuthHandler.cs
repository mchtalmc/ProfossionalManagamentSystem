using MagamentSystem.Application.DataTransferObject.Identity;

namespace MagamentSystem.Application.Services.JwtTokenServices
{
	public interface IAuthHandler
	{
		Task<UserLoginResponse> Login(UserLogin request);
	}
}
