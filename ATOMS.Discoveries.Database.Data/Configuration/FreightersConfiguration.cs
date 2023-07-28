using Atoms.Discoveries.Database.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Atoms.Discoveries.Database.Data.Configuration;

public class FreightersConfiguration : IEntityTypeConfiguration<Freighter>
{
	public void Configure(EntityTypeBuilder<Freighter> entity)
	{
		var freighters = new Freighter[]
		{
			new Freighter(14, "MS-9 Yanagata", "Resurgent", "04DF:00CA:0551:0197") { Colors = "Black, Yellow", Slots = 40, DiscovererId = 1, SolarSystemId = 2 }
		};
		entity.HasData(freighters);
	}
}
