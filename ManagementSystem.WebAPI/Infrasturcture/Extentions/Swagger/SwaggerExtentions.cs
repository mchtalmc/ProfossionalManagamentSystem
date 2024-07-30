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
				#region Users Controller
				opt.SwaggerDoc("educationService", new OpenApiInfo
				{
					Title = "Education Information's Service",
					Version = "v1",
					Description = "The procedures about the education will be done here."
				});	
				opt.SwaggerDoc("appUserService", new OpenApiInfo
				{
					Title = "App User Information's Service",
					Version = "v1",
					Description = "The procedures about the App User will be done here."
				});
				opt.SwaggerDoc("militaryService", new OpenApiInfo
				{
					Title = "Military Information's Service",
					Version = "v1",
					Description = "The procedures about the Military will be done here."
				});
			
				opt.SwaggerDoc("experienceService", new OpenApiInfo
				{
					Title = "Experience Service",
					Version = "v1",
					Description = "The procedures about the Experience will be done here."
				});

				opt.SwaggerDoc("healthService", new OpenApiInfo
				{
					Title = "Healt Service",
					Version = "v1",
					Description = "The procedures about the Healty will be done here"
				});	
			
				#endregion


				#region Buys Controller
				opt.SwaggerDoc("contractInfoService", new OpenApiInfo
				{
					Title = "Contract Info Information's Service",
					Version = "v1",
					Description = "The procedures Info about the Contract will be done here."
				});
				opt.SwaggerDoc("contractorService", new OpenApiInfo
				{
					Title = "Contractor  Information's Service",
					Version = "v1",
					Description = "The procedures  about the Contractor will be done here."
				});
				opt.SwaggerDoc("sueService", new OpenApiInfo
				{
					Title = "Sue  Information's Service",
					Version = "v1",
					Description = "The procedures about the Sue will be done here."
				});
				opt.SwaggerDoc("sueDetailsService", new OpenApiInfo
				{
					Title = "Sue Details  Information's Service",
					Version = "v1",
					Description = "The procedures  about the Sue Details will be done here."
				});
				#endregion

				#region Wares Controller
				opt.SwaggerDoc("categoryService", new OpenApiInfo
				{
					Title = "Category Information's Service",
					Version = "v1",
					Description = "The procedures about the Category will be done here."
				});
				opt.SwaggerDoc("dealerService", new OpenApiInfo
				{
					Title = "Dealer Information's Service",
					Version = "v1",
					Description = "The procedures about the Dealer will be done here."
				});
				opt.SwaggerDoc("marketPlaceService", new OpenApiInfo
				{
					Title = "Market Place Information's Service",
					Version = "v1",
					Description = "The procedures  about the Market Place  will be done here."
				});	
				opt.SwaggerDoc("producerService", new OpenApiInfo
				{
					Title = "Producer Information's Service",
					Version = "v1",
					Description = "The procedures about the Producer will be done here."
				});
				opt.SwaggerDoc("productService", new OpenApiInfo
				{
					Title = "Product Information's Service",
					Version = "v1",
					Description = "The procedures about the Product will be done here."
				});
				#endregion
				#region Authorization && Authentication 
					opt.SwaggerDoc("authenticationService", new OpenApiInfo
				{
					Title = "authenticationService",
					Version = "v1",
					Description = "The Service about the  Member Authentication Token Generate will be done here "
				});
					opt.SwaggerDoc("permissionService", new OpenApiInfo
				{
					Title = "Permission Information's Service",
					Version = "v1",
					Description = "The procedures about the Permission will be done here."
					});	
				opt.SwaggerDoc("roleService", new OpenApiInfo
				{
					Title = "Role Information's Service",
					Version = "v1",
					Description = "The procedures about the Role will be done here."
				});	
				opt.SwaggerDoc("rolePermissionService", new OpenApiInfo
				{
					Title = "Role Permission Information's Service",
					Version = "v1",
					Description = "The procedures Permission about the Role Permission will be done here."
				});	
				opt.SwaggerDoc("userPermissionService", new OpenApiInfo
				{
					Title = "User Permission Information's Service",
					Version = "v1",
					Description = "The procedures  about the User Permission will be done here."
				});
				#endregion



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
					c.SwaggerEndpoint("/swagger/authenticationService/swagger.json", "Authentication ");
					c.SwaggerEndpoint("/swagger/permissionService/swagger.json", "Permission Information");
					c.SwaggerEndpoint("/swagger/roleService/swagger.json", "Role Information");
					c.SwaggerEndpoint("/swagger/rolePermissionService/swagger.json", "Role Permission Information");
					c.SwaggerEndpoint("/swagger/userPermissionService/swagger.json", "User Permission Information");
					#endregion



					#region Wares
					c.SwaggerEndpoint("/swagger/categoryService/swagger.json", "Category Information");
					c.SwaggerEndpoint("/swagger/dealerService/swagger.json", "Dealer Information");
					c.SwaggerEndpoint("/swagger/marketPlaceService/swagger.json", "Market Place Information");
					c.SwaggerEndpoint("/swagger/producerService/swagger.json", "Producer Information");
					c.SwaggerEndpoint("/swagger/productService/swagger.json", "Product Information");
					#endregion




					#region Buys
					c.SwaggerEndpoint("/swagger/contractInfoService/swagger.json", "Contract Info Information");
					c.SwaggerEndpoint("/swagger/contractorService/swagger.json", "Contractor Information");
					c.SwaggerEndpoint("/swagger/sueService/swagger.json", "Sue Information");
					c.SwaggerEndpoint("/swagger/sueDetailsService/swagger.json", "Sue Details Information");
					#endregion

					#region User's 
					c.SwaggerEndpoint("/swagger/educationService/swagger.json", "Education Information");
					c.SwaggerEndpoint("/swagger/militaryService/swagger.json", "Military Information");
					c.SwaggerEndpoint("/swagger/experienceService/swagger.json", "Expererince Information ");
					c.SwaggerEndpoint("/swagger/healthService/swagger.json", "Healt Information ");
					c.SwaggerEndpoint("/swagger/militaryService/swagger.json", "Military Information ");
					c.SwaggerEndpoint("/swagger/appUserService/swagger.json", "App User Information ");
					#endregion
					

				});
			}

			return app;
		}
	}
}
