using Atoms.Discoveries.Database.Domain;
using Atoms.Discoveries.Database.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Atoms.Discoveries.Database.Data.Configuration;

public class ShipsConfiguration : IEntityTypeConfiguration<Ship>
{
	public void Configure(EntityTypeBuilder<Ship> entity)
	{
		entity
			.Property(e => e.Class)
			.HasConversion<string>();

		var ships = new Ship[]
		{
			new Ship(9, "Flameborn", "Interceptor", "04DF:00CA:0551:0197"){ Class = Class.S, Colors = "White, Black, Red", Slots = 25, Version = "Singularity", SolarSystemId = 2, DiscovererId = 3 },
			new Ship(10, "Katori de Loucura", "Exotic", "04DF:00CA:0551:0197"){ Class = Class.A, Colors = "White, Black, Orange", Slots = 20, Version = "Singularity", SolarSystemId = 2, DiscovererId = 3, PlanetId = 7 }
		};
		entity.HasData(ships);
	}
}
