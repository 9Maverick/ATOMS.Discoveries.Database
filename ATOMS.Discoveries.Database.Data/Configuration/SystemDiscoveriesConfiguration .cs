using Atoms.Discoveries.Database.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Atoms.Discoveries.Database.Data.Configuration;

public class SystemDiscoveriesConfiguration : IEntityTypeConfiguration<SystemDiscovery>
{
	public void Configure(EntityTypeBuilder<SystemDiscovery> entity)
	{
		var systemDiscoveries = new SystemDiscovery[]
		{
			new SystemDiscovery(18,"Atlas Messenger","Cosmic structure","0FE8:00B0:0C61:0089") { Version="Endurance", DiscovererId=3, SolarSystemId = 1 }
		};
		entity.HasData(systemDiscoveries);
	}
}
