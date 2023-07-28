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
			.HasDefaultValue(Lifeform.Abadoned);
		entity
			.Property(e => e.Economy)
			.HasDefaultValue(Economy.None);
	}
}
