using Atoms.Discoveries.Database.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Atoms.Discoveries.Database.Data.Configuration;

public class FaunaConfiguration : IEntityTypeConfiguration<Fauna>
{
	public void Configure(EntityTypeBuilder<Fauna> entity)
	{
		entity
			.Property(e => e.Species)
			.IsRequired();

		var fauna = new Fauna[]
		{
			new Fauna(12, "C. Livercoyllera", "Robot", "0FE8:00B0:0C61:0089"){ Height=1.2, DiscovererId = 1, PlanetId = 4 },
			new Fauna(13, "C. Potasamensium", "Robot", "0FE8:00B0:0C61:0089"){ Height=1.7, DiscovererId = 1, PlanetId = 4 }
		};
		entity.HasData(fauna);
	}
}
