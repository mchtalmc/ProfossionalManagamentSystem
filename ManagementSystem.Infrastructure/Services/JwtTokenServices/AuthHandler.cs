using MagamentSystem.Application.DataTransferObject.Identity;
using MagamentSystem.Application.Managers.User;
using MagamentSystem.Application.Services.Authorization;
using MagamentSystem.Application.Services.JwtTokenServices;
using MagamentSystem.Application.Services.Security;

namespace ManagementSystem.Infrastructure.Services.JwtTokenServices
{
	public class AuthHandler : IAuthHandler
	{
		private readonly ITokenHandler _tokenHandler;
		private readonly IAppUserManager _appUserManger;
		private readonly IUserPermissionService _userPermissionService;

		
		public AuthHandler(ITokenHandler tokenHandler, IAppUserManager appUserManager, IAppUserManager appUserManger, IUserPermissionService userPermissionService)
		{
			_tokenHandler = tokenHandler;
			_appUserManger = appUserManger;
			_userPermissionService = userPermissionService;
		}

		public async Task<UserLoginResponse> Login(UserLogin request)
		{

			var user = _appUserManger.CheckRegister(request.Email, request.Password);
			if(user is null)
			{
				return new UserLoginErrorMessage { Message = "Email or Password FALSE" };
			}
			var permission = _userPermissionService.GetUserPermissionWithUserId(user.Id);
			var generatedToken = await _tokenHandler.GenerateToken(user,permission);
			UserLoginResponse response = new UserLoginResponse();
			response.AuthencticateResult = true;
			response.AccessTokenExpiredDate = generatedToken.TokenExpireDate;
			response.AuthToken = generatedToken.Token;
			return response;





		}
	}
}