using MagamentSystem.Application.DataTransferObject.Jwt;
using MagamentSystem.Application.Repository.UserRepository.Users;
using MagamentSystem.Application.Services.Security;
using ManagamentSystem.Core.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ManagementSystem.Infrastructure.Services.JwtTokenServices
{
	public class TokenHandler : ITokenHandler
	{
		//Option's Design Pattern'a elebt gecilecek.
		private readonly IConfiguration _configuration;
		private readonly IAppUserReadRepository _userReadRepository;

		public TokenHandler(IConfiguration configuration, IAppUserReadRepository userReadRepository)
		{
			_configuration = configuration;
			_userReadRepository = userReadRepository;
		}

		public Task<TokenResponse> GenerateToken(AppUser user, List<string> permissions)
		{
			SymmetricSecurityKey symmetricSecurityKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_configuration["JWT:Secret"]));
			var dateTime = DateTime.UtcNow;
			var tokenExpiry = dateTime.AddMinutes(15);

			var claims = new List<Claim>
			{
				new("email",user.Email),
				new("id",user.Id.ToString())
				
			};
			permissions.ForEach(permission =>
			{
				claims.Add(new("CustomPermissions", permission));
			});

			var jwt = new JwtSecurityToken(
				issuer: _configuration["JWT:ValidIssuer"],
				audience: _configuration["JWT:ValidAudience"],
				claims:claims,
				notBefore:dateTime,
				expires:tokenExpiry,
				signingCredentials:new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256)
				);
			return Task.FromResult(new TokenResponse{
				
				Token= new JwtSecurityTokenHandler().WriteToken(jwt),
				TokenExpireDate=tokenExpiry
			});

		}

		public async Task<AppUser> ValidateTokenAndGetUser(string token)
		{
			if (string.IsNullOrEmpty(token))
			{
				throw new ArgumentException("Please Login", nameof(token));
			}

			var tokenHandler = new JwtSecurityTokenHandler();
			var key = Encoding.ASCII.GetBytes(_configuration["JWT:Secret"]);

			try
			{
				tokenHandler.ValidateToken(token, new TokenValidationParameters
				{
					ValidateIssuerSigningKey = true,
					IssuerSigningKey = new SymmetricSecurityKey(key),
					ValidateIssuer = true,
					ValidIssuer = _configuration["JWT:ValidIssuer"],
					ValidateAudience = true,
					ValidAudience = _configuration["JWT:ValidAudience"],
					RequireExpirationTime = true,
					ValidateLifetime = true,
					ClockSkew = TimeSpan.Zero
				}, out SecurityToken validatedToken);

				var jwtToken = (JwtSecurityToken)validatedToken;
				var appUserIdClaim = jwtToken.Claims.FirstOrDefault(x => x.Type == "id")?.Value;

				if (string.IsNullOrEmpty(appUserIdClaim))
				{
					throw new Exception("Invalid token: Missing user ID claim");
				}

				var userId = int.Parse(appUserIdClaim);
				var user = await _userReadRepository.GetSingleById(userId);

				if (user == null)
				{
					throw new Exception("User not found. Please Register");
				}

				return user;
			}
			catch (Exception ex)
			{
				throw new Exception("Token validation failed", ex);
			}
		}


	}
}
