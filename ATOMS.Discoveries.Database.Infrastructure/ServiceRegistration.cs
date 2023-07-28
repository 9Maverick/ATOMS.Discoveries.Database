using Atoms.Discoveries.Database.Data;
using Atoms.Discoveries.Database.Data.Configuration;
using Atoms.Discoveries.Database.SharedKernel.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics;

namespace Atoms.Discoveries.Database.Infrastructure;

public static class ServiceRegistration
{
	public static IServiceCollection AddInfrastructure(this IServiceCollection services, string connectionString, bool isDevelopment)
	{
		services.AddSingleton<IModelConfiguration, SqlModelConfiguration>();
		services.AddDbContext<DiscoveriesContext>(options =>
		{
			options.UseSqlServer(connectionString, sqlOptions =>
			{
				sqlOptions.MigrationsAssembly(
					typeof(ServiceRegistration).Assembly.FullName);
			});
			if (isDevelopment)
			{
				options.EnableSensitiveDataLogging();
			}
			options.LogTo(message => Trace.WriteLine(message));
		});

		return services;
	}
}