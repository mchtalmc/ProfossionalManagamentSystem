using ManagamentSystem.Persistance;
using ManagementSystem.Infrastructure;  // Corrected namespace
using ManagementSystem.WebAPI.Infrastructure.Extensions.Swagger;

namespace ManagementSystem.WebAPI.Infrastructure
{
	public static class ConfigureStartupExtension
	{
		public static WebApplicationBuilder ConfigureBuilder(this WebApplicationBuilder builder)
		{
			
		//	builder.Configuration.GetSection("TokenSettings").Get<TokenSettings>();
		//Elbet buna donecegiz Dert etmeye gerek yok , simdilik NUll donsun

			// Register services
			
			builder.Services.AddInfrasturctureServices(builder.Configuration); 
			builder.Services.AddSwaggerServices();
			builder.Services.AddPersistenceServices(builder.Configuration);
			
			



			

			return builder;
		}
	}
}
