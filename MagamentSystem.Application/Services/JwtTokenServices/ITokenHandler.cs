using MagamentSystem.Application.DataTransferObject.Jwt;
using ManagamentSystem.Core.Entities;

namespace MagamentSystem.Application.Services.Security
{
	public interface ITokenHandler
    {
        Task<TokenResponse> GenerateToken(AppUser user, List<string> permissions);
        Task<AppUser> ValidateTokenAndGetUser(string token);
    }
}
