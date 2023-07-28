using Atoms.Discoveries.Database.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Atoms.Discoveries.Database.Data.Configuration;

public class PlanetDiscoveriesConfiguration : IEntityTypeConfiguration<PlanetDiscovery>
{
	public void Configure(EntityTypeBuilder<PlanetDiscovery> entity)
	{
		var planetDiscoveries = new PlanetDiscovery[]
		{
			new PlanetDiscovery (11, "Felucia", "Base", "0FE8:00B0:0C61:0089"){ Version="Endurance", DiscovererId=1, PlanetId=4 }
		};
		entity.HasData(planetDiscoveries);
	}
}
