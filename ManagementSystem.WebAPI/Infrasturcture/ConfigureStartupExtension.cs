using MagamentSystem.Application;
using ManagamentSystem.Persistance;
using ManagementSystem.Infrastructure;
using ManagementSystem.WebAPI.Infrastructure.Extensions.Security;
using ManagementSystem.WebAPI.Infrastructure.Extensions.Swagger;

namespace ManagementSystem.WebAPI.Infrastructure
{
	public static class ConfigureStartupExtension
	{
		public static WebApplicationBuilder ConfigureBuilder(this WebApplicationBuilder builder)
		{
			builder.Services.AddInfrasturctureServices(builder.Configuration);
			builder.Services.AddSwaggerServices();
			builder.Services.ConfigureAuth(builder.Configuration);
			
			builder.Services.AddApplicationRegistration(builder.Configuration);
			
			return builder;
		}

	
	}
}
