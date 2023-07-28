using Atoms.Discoveries.Database.Domain;
using Atoms.Discoveries.Database.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Atoms.Discoveries.Database.Data.Configuration;

public class MultiToolsConfiguration : IEntityTypeConfiguration<MultiTool>
{
	public void Configure(EntityTypeBuilder<MultiTool> entity)
	{
		entity
			.Property(e => e.Class)
			.HasConversion<string>();

		var multiTools = new MultiTool[]
		{
			new MultiTool(16, "Messenger of the Anomaly G-2-92T", "Experimental", "Rifle", "0EF6:00FB:0EE5:0025", "Hilbert"){ Class = Class.A, DiscovererId = 3, SolarSystemId = 3 },
			new MultiTool(17, "Touch of Matter", "Alien", "Rifle", "0EF6:00FB:0EE5:0025", "Hilbert"){ Class = Class.B, DiscovererId = 3, SolarSystemId = 3, PlanetId = 8 }
		};
		entity.HasData(multiTools);
	}
}
