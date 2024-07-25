using MagamentSystem.Application.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace ManagementSystem.WebAPI.Infrastructure.Extensions.Security
{
	public static class AuthRegistration
	{
		public static IServiceCollection ConfigureAuth(this IServiceCollection services, IConfiguration configuration)
		{
			// Configure TokenSettings from configuration
			var tokenSettings = configuration.GetSection("TokenSettings").Get<TokenSettings>();

			var jwtIssuer = tokenSettings.ValidIssuer;
			var jwtKey = tokenSettings.Secret;
			var audience = tokenSettings.ValidAuidence;

			services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
				.AddJwtBearer(options =>
				{
					options.TokenValidationParameters = new TokenValidationParameters
					{
						ValidateIssuer = true,
						ValidateAudience = true,
						ValidateLifetime = true,
						ValidateIssuerSigningKey = true,
						ValidIssuer = jwtIssuer,
						ValidAudience = audience,
						IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey)),
					};
				});

			return services;
		}
	}
}
