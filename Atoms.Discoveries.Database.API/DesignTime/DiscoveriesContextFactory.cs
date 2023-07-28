using Atoms.Discoveries.Database.Data;
using Atoms.Discoveries.Database.Data.Configuration;
using Atoms.Discoveries.Database.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Atoms.Discoveries.Database.API.DesignTime;

public class DiscoveriesContextFactory : IDesignTimeDbContextFactory<DiscoveriesContext>
{
	private const string AdminConnectionString = "DISCOVERIES_ADMIN_CONNECTION_STRING";
	public DiscoveriesContext CreateDbContext(string[] args)
	{
		Environment.SetEnvironmentVariable(AdminConnectionString, "Data Source = (localdb)\\MSSQLLocalDB;Initial Catalog=Discoveries;Integrated Security=true;Trusted_Connection=True");
		var connectionString = Environment.GetEnvironmentVariable(AdminConnectionString);
		if (string.IsNullOrEmpty(connectionString))
		{
			throw new ApplicationException(
				$"Error, absent {AdminConnectionString}");
		}
		var options = new DbContextOptionsBuilder<DiscoveriesContext>()
			.UseSqlServer(connectionString, sqlOptions =>
			{
				sqlOptions.MigrationsAssembly(
					typeof(ServiceRegistration).Assembly.FullName);
			})
			.Options;
		return new DiscoveriesContext(options, new SqlModelConfiguration());
	}
}
