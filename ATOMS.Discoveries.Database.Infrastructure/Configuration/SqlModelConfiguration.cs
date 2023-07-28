using Atoms.Discoveries.Database.SharedKernel.Configuration;
using Microsoft.EntityFrameworkCore;

namespace Atoms.Discoveries.Database.Data.Configuration;

public class SqlModelConfiguration : IModelConfiguration
{
	public void ConfigureModel(ModelBuilder modelBuilder)
	{
		modelBuilder.ApplyConfigurationsFromAssembly(typeof(SqlModelConfiguration).Assembly);
	}
}
