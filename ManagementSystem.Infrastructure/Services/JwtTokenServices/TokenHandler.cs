using MagamentSystem.Application.DataTransferObject.Jwt;
using MagamentSystem.Application.Models;
using MagamentSystem.Application.Services.Security;
using ManagamentSystem.Core.Entities;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ManagementSystem.Infrastructure.Services.JwtTokenServices
{
    public class TokenHandler : ITokenHandler
    {
        private readonly IOptions<TokenSettings> _options;

        public TokenHandler(IOptions<TokenSettings> options)
        {
            _options = options;
        }

        public Task<TokenResponse> GenerateToken()
        {
            SymmetricSecurityKey symmetricSecurityKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_options.Value.Secret));

            var dateTime = DateTime.Now;
            var tokenExpiry = dateTime.AddDays(1);

            #region PERMISSION
            //var claims = new List<Claim>
            //{
            //	new Claim("email", user.Email),
            //	new Claim("title",user.Title)
            //};
            //Yetki eklenecek
            #endregion

            JwtSecurityToken jwt = new JwtSecurityToken(
                issuer: _options.Value.ValidIssuer,
                audience: _options.Value.ValidAuidence,
                notBefore: dateTime,
                expires: tokenExpiry,
                signingCredentials: new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256)
            );
            return Task.FromResult(new TokenResponse
            {
                Token = new JwtSecurityTokenHandler().WriteToken(jwt),
                TokenExpireDate = tokenExpiry
            });
        }

    }
}
