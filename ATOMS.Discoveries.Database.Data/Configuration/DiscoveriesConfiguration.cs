using Atoms.Discoveries.Database.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Atoms.Discoveries.Database.Data.Configuration;

public class DiscoveriesConfiguration : IEntityTypeConfiguration<Discovery>
{
	public void Configure(EntityTypeBuilder<Discovery> entity)
	{
		entity.HasKey(e => e.Id);
		entity
			.Property(e => e.Name)
			.IsRequired();
		entity
			.Property(e => e.DiscoveryType)
			.IsRequired();
		entity
			.Property(e => e.Coordinates)
			.IsRequired();
		entity
			.Property(e => e.Galaxy)
			.IsRequired();
		entity
			.Property(e => e.Platform)
			.HasConversion<string>();
	}
}
