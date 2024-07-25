using Microsoft.OpenApi.Models;

namespace ManagementSystem.WebAPI.Infrasturcture.Extentions.Swagger
{
	public static class SwaggerExtentions
	{
		public static IServiceCollection AddSwaggerServices(this IServiceCollection services)
		{
			services.AddSwaggerGen(opt =>
			{

				opt.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
				{
					Name="Authorization",
					Type=SecuritySchemeType.ApiKey,
					Scheme="Bearer",
					BearerFormat="JWT",
					In=ParameterLocation.Header,
					Description="JWT Authorization header using Bearer scheme. "
				});

				opt.AddSecurityRequirement(new OpenApiSecurityRequirement {{
						new OpenApiSecurityScheme {
						Reference= new OpenApiReference{
						Type=ReferenceType.SecurityScheme,Id="Bearer"}},
					new string[]{}
					  }
				});
			});
			return services;
		}
	

		
	}
}
