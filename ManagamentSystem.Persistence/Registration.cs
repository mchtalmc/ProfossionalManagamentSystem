using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ManagamentSystem.Persistance
{
	public static class Registration
	{
		public static void AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
		{
			string connectionString = configuration.GetConnectionString("database") ?? "_noconfiguration";
			services.AddDbContext<ManagamentContext>(options =>
				options.UseSqlServer(connectionString));
		}

	}
}
