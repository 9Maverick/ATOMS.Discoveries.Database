using Atoms.Discoveries.Database.Domain;
using Atoms.Discoveries.Database.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Atoms.Discoveries.Database.Data.Configuration;

public class DiscoveriesConfiguration : IEntityTypeConfiguration<Discovery>
{
	public void Configure(EntityTypeBuilder<Discovery> entity)
	{
		entity
			.Property(e => e.Platform)
			.HasDefaultValue(Platform.PC);
		entity
			.Property(e => e.Galaxy)
			.HasDefaultValue("Euclid");
		entity.UseTpcMappingStrategy();
	}
}
