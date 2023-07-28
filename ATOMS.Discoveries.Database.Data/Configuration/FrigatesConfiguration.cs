using Atoms.Discoveries.Database.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Atoms.Discoveries.Database.Data.Configuration;

public class FrigatesConfiguration : IEntityTypeConfiguration<Frigate>
{
	public void Configure(EntityTypeBuilder<Frigate> entity)
	{
		var frigates = new Frigate[]
		{
			new Frigate(15, "Makojim's Omen", "Combat", "04DF:00CA:0551:0197"){ Colors = "Red, Black, White", DiscovererId = 3, SolarSystemId = 1 }
		};
		entity.HasData(frigates);
	}
}
