using MagamentSystem.Application.Models;
using Microsoft.Extensions.Configuration;

namespace ManagementSystem.WebAPI.Infrastructure.Extensions.Security
{
	public static class AuthRegistration
	{
		public static IServiceCollection ConfigureAuth(this IServiceCollection services, IConfiguration configuration)
		{
			
			return services;
		}

	}
}
