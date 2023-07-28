using Atoms.Discoveries.Database.Domain;
using Atoms.Discoveries.Database.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Atoms.Discoveries.Database.Data.Configuration;

public class SolarSystemsConfiguration : IEntityTypeConfiguration<SolarSystem>
{
	public void Configure(EntityTypeBuilder<SolarSystem> entity)
	{
		entity
			.Property(e => e.DominantLifeform)
			.HasConversion<string>();
		entity
			.Property(e => e.Economy)
			.HasConversion<string>();
		entity.Ignore(e => e.Planets);

		var systems = new SolarSystem[]
		{
			new SolarSystem(1, "Felucia", "0FE8:00B0:0C61:0089"){ Version = "Endurance", DiscovererId = 1 },
			new SolarSystem(2, "Kairn", "04DF:00CA:0551:0197"){ DominantLifeform = Lifeform.Korvax, Economy = Economy.Tier2, Version = "Endurance", DiscovererId = 2 },
			new SolarSystem(3, "Mepacket", "0EF6:00FB:0EE5:0025"){ Galaxy = "Hilbert", DominantLifeform = Lifeform.Gek, Economy = Economy.Tier1, Version = "Endurance", DiscovererId = 3 }
		};
		entity.HasData(systems);
	}
}
