using Atoms.Discoveries.Database.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Atoms.Discoveries.Database.Data.Configuration;

public class ImagesConfiguration : IEntityTypeConfiguration<Image>
{
	public void Configure(EntityTypeBuilder<Image> entity)
	{
		entity.HasKey(e => e.Id);
	}
}
