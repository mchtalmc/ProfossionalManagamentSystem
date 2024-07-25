using MagamentSystem.Application.DataTransferObject.Jwt;

namespace MagamentSystem.Application.Services.Security
{
    public interface ITokenHandler
    {
        Task<TokenResponse> GenerateToken();
    }
}
