using FluentValidation;
using MagamentSystem.Application.Managers.Buy;
using MagamentSystem.Application.Managers.User;
using MagamentSystem.Application.Managers.Wares;
using MagamentSystem.Application.Repository.BuyRepository.ContractInfos;
using MagamentSystem.Application.Repository.BuyRepository.Contractors;
using MagamentSystem.Application.Repository.BuyRepository.SueDetail;
using MagamentSystem.Application.Repository.BuyRepository.Sues;
using MagamentSystem.Application.Repository.UserRepository.CustomIdentity;
using MagamentSystem.Application.Repository.UserRepository.Educations;
using MagamentSystem.Application.Repository.UserRepository.Experiences;
using MagamentSystem.Application.Repository.UserRepository.Healts;
using MagamentSystem.Application.Repository.UserRepository.Military;
using MagamentSystem.Application.Repository.UserRepository.Users;
using MagamentSystem.Application.Repository.WaresRepository.Categoryies;
using MagamentSystem.Application.Repository.WaresRepository.Dealaers;
using MagamentSystem.Application.Repository.WaresRepository.MarketPlaces;
using MagamentSystem.Application.Repository.WaresRepository.Producers;
using MagamentSystem.Application.Repository.WaresRepository.Products;
using MagamentSystem.Application.Services.Authorization;
using MagamentSystem.Application.Services.JwtTokenServices;
using MagamentSystem.Application.Services.Security;
using ManagementSystem.Infrastructure.Managers.Buy;
using ManagementSystem.Infrastructure.Managers.User;
using ManagementSystem.Infrastructure.Managers.Wares;
using ManagementSystem.Infrastructure.Repository.Buy.ContractInfos;
using ManagementSystem.Infrastructure.Repository.Buy.Contractors;
using ManagementSystem.Infrastructure.Repository.Buy.SueDetails;
using ManagementSystem.Infrastructure.Repository.Buy.Sues;
using ManagementSystem.Infrastructure.Repository.Users.AppUsers;
using ManagementSystem.Infrastructure.Repository.Users.CustomAuthorization;
using ManagementSystem.Infrastructure.Repository.Users.Educations;
using ManagementSystem.Infrastructure.Repository.Users.Experiences;
using ManagementSystem.Infrastructure.Repository.Users.Healts;
using ManagementSystem.Infrastructure.Repository.Users.Militaries;
using ManagementSystem.Infrastructure.Repository.Wares.Categories;
using ManagementSystem.Infrastructure.Repository.Wares.Dealers;
using ManagementSystem.Infrastructure.Repository.Wares.MarketPlaces;
using ManagementSystem.Infrastructure.Repository.Wares.Producers;
using ManagementSystem.Infrastructure.Repository.Wares.Products;
using ManagementSystem.Infrastructure.Services.Authorization;
using ManagementSystem.Infrastructure.Services.JwtTokenServices;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace ManagementSystem.Infrastructure
{
	public static class Registration
	{
		public static void AddInfrasturctureServices(this IServiceCollection services, IConfiguration configuration)
		{
			AddManagerService(services);
			AddRepositoryService(services);
			services.AddAutoMapper(Assembly.GetExecutingAssembly());
			services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
			
			services.AddTransient<ITokenHandler, TokenHandler>();
			
		}

		public static void AddManagerService( IServiceCollection services)
		{
			#region User
			services.AddTransient<IAppUserManager, AppUserManagerService>();
			services.AddTransient<IEducationManager, EducationManager>();
			services.AddTransient<IHealtManager, HealtManager>();
			services.AddTransient<IMilitaryManager, MilitaryManager>();
			services.AddTransient<IExperienceManger,ExperienceManager>();
			#endregion
			#region Buy
			services.AddTransient<IContractInfoManager, ContractInfoManager>();
			services.AddTransient<IContractorManager, ContractorManager>();
		//	services.AddTransient<ISueDetailManager, SueDetailsManager>();
			services.AddTransient<ISueManager,SueManager>();
			#endregion

			#region Wares
			services.AddTransient<ICategoryManager, CategoryManager>();
			services.AddTransient<IDealersManager, DealersManager>();
			services.AddTransient<IProducerManager, ProducerManager>();
			services.AddTransient<IProductManager, ProductManager>();
			services.AddTransient<IMarketPlaceManager, MarketPlaceManager>();
			#endregion
			#region Authorization && Authantication
			services.AddScoped<IAuthHandler, AuthHandler>();
			services.AddScoped<ITokenHandler, TokenHandler>();

			services.AddScoped<ICustomRoleService,CustomRoleService>();
			services.AddScoped<ICustomPermissionService,  CustomPermissionService>();
			services.AddScoped<IUserPermissionService, UserPermissionService>();
			services.AddScoped<IRolePermissionService,RolePermissionService>();


			#endregion






		}
		public static void AddRepositoryService(IServiceCollection services)
		{
			#region User
			services.AddTransient<IAppUserReadRepository,AppUserReadRepository>();
			services.AddTransient<IAppUserWriteRepository,AppUserWriteRepository>();

			services.AddTransient<IEducationReadRepository, EducationReadRepository>();
			services.AddTransient<IEducationWriteRepository,EducationWriteRepository>();

			services.AddTransient<IExperienceReadRepository,ExperiencesReadRepository>();
			services.AddTransient<IExperiencesWriteRepository,ExperiencesWriteRepository>();

			services.AddTransient<IHealtReadRepository,HealtReadRepository>();
			services.AddTransient<IHealtWriteRepository,HealtWriteRepository>();

			services.AddTransient<IMilitaryReadRepository,MilitaryReadRepository>();
			services.AddTransient<IMilitaryWriteRepository,MilitaryWriteRepository>();

			#endregion

			#region Buy
			services.AddTransient<IContractInfoReadRepository,ContractInfosReadRepository>();
			services.AddTransient<IContractInfoWriteRepository,ContractInfosWriteRepository>();

			services.AddTransient<IContractorReadRepository, ContractorsReadRepository>();
			services.AddTransient<IContractorWriteRepository,ContractorsWriteRepository>();

			//services.AddTransient<ISueDetailsReadRepository,SueDetailsReadRepository>();
			//services.AddTransient<ISueDetailsWriteRepository , SueDetailsWriteRepository>();

			services.AddTransient<ISueWriteRepository, SueWriteRepository>();
			services.AddTransient<ISueReadRepository, SueReadRepository>();

			#endregion

			#region Wares
			services.AddTransient<ICategoryReadRepository, CategoryReadRepository>();
			services.AddTransient<ICategoryWriteRepository,CategoryWriteRepository>();

			services.AddTransient<IDealerReadRepository,DealersReadRepository>();
			services.AddTransient<IDealerWriteRepository,DealersWriteRepository>();	

			services.AddTransient<IProducerWriteRepository,ProducerWriteRepository>();
			services.AddTransient<IProducerReadRepository,ProducersReadRepository>();

			services.AddTransient<IProductReadRepository, ProductReadRepository>();
			services.AddTransient<IProductWriteRepository, ProductWriteRepository>();

			services.AddTransient<IMarketPlaceReadRepository, MarketPlaceReadRepository>();
			services.AddTransient<IMarketPlaceWriteRepository, MarketPlaceWriteRepository>();

			#endregion
			#region Authorization
			services.AddScoped<ICustomRoleReadRepository,CustomRoleReadRepository>();
			services.AddScoped<ICustomRoleWriteRepository,CustomRoleWritePermission>();

			services.AddScoped<ICustomPermissionReadRepository,CustomPermissionReadRepository>();
			services.AddScoped<ICustomPermissionWriteRepository,CustomPermissionWriteRepository>();

			services.AddScoped<IUserPermissionReadRepository , UserPermissionReadRepository>();
			services.AddScoped<IUserPermissionWriteRepository,UserPermissionWriteRepository>();

			services.AddScoped<IRolePermissionReadRepository, RolePermissionReadRepository>();
			services.AddScoped<IRolePermissionWriteRepository, RolePermissionWriteRepository>();
			#endregion




		}
	}
}
