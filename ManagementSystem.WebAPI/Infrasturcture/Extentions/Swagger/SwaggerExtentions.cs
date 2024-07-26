using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;

namespace ManagementSystem.WebAPI.Infrastructure.Extensions.Swagger
{
	public static class SwaggerExtensions
	{
		public static IServiceCollection AddSwaggerServices(this IServiceCollection services)
		{
			services.AddSwaggerGen(opt =>
			{
				opt.SwaggerDoc("educationService", new OpenApiInfo
				{
					Title = "Education Information's Service",
					Version = "v1",
					Description = "The procedures about the education will be done here."
				});
				opt.SwaggerDoc("militaryService", new OpenApiInfo
				{
					Title="Military Information's Service",
					Version="v1",
					Description="The procedures about the Military will be done here."
				});
				opt.SwaggerDoc("authService", new OpenApiInfo
				{
					Title="Authentication Service",
					Version="v1",
					Description="The Service about the  Member Authentication Token Generate will be done here "
				});
				opt.SwaggerDoc("experienceService", new OpenApiInfo
				{
					Title="Experience Service",
					Version="v1",
					Description="The procedures about the Experience will be done here."
				});

				opt.SwaggerDoc("healthService", new OpenApiInfo
				{
					Title = "Healt Service",
					Version = "v1",
					Description = "The procedures about the Healty will be done here"
				});
			
				opt.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
				{
					Name = "Authorization",
					Type = SecuritySchemeType.ApiKey,
					Scheme = "Bearer",
					BearerFormat = "JWT",
					In = ParameterLocation.Header,
					Description = "JWT Authorization header using Bearer scheme."
				});


				opt.AddSecurityRequirement(new OpenApiSecurityRequirement {
					{
						new OpenApiSecurityScheme
						{
							Reference = new OpenApiReference
							{
								Type = ReferenceType.SecurityScheme,
								Id = "Bearer"
							}
						},
						new string[] {}
					}
				});
			});
			return services;
		}

		public static IApplicationBuilder AddSwaggerUIServices(this IApplicationBuilder app, IWebHostEnvironment environment)
		{
			if (environment.IsDevelopment())
			{
				app.UseSwagger();
				app.UseSwaggerUI(c =>
				{
					#region Authentication & Authorization
					c.SwaggerEndpoint("/swagger/authService/swagger.json", "Authentication ");
					#endregion


					#region User's 
					c.SwaggerEndpoint("/swagger/educationService/swagger.json", "Education Information");
					c.SwaggerEndpoint("/swagger/militaryService/swagger.json", "Military Information");
					c.SwaggerEndpoint("/swagger/experienceService/swagger.json", "Expererince Information ");
					c.SwaggerEndpoint("/swagger/healthService/swagger.json", "Healt Information ");
					c.SwaggerEndpoint("/swagger/militaryService/swagger.json", "Military Information ");
					#endregion


				});
			}

			return app;
		}
	}
}
