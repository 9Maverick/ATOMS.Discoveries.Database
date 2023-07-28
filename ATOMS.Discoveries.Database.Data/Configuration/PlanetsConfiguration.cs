using Atoms.Discoveries.Database.Domain;
using Atoms.Discoveries.Database.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Atoms.Discoveries.Database.Data.Configuration;

public class PlanetsConfiguration : IEntityTypeConfiguration<Planet>
{
	public void Configure(EntityTypeBuilder<Planet> entity)
	{
		entity
			.Property(e => e.SentinelsActivity)
			.HasConversion<string>();

		var planets = new Planet[]
		{
			new Planet(4, "Heff I", "0FE8:00B0:0C61:0089"){ SentinelsActivity = Sentinels.None, Biome = "Temperate", Resources = "Frost crystal, Emeril, Dioxite, Silver", Version = "Endurance", DiscovererId = 1, SolarSystemId = 1 },
			new Planet(5, "Gefiant IV", "0FE8:00B0:0C61:0089") { SentinelsActivity = Sentinels.Aggressive, Biome = "Icebound", Resources = "Star bulb, Emeril, Parafinium, Magnetized Ferrite", Version = "Endurance", DiscovererId = 1, SolarSystemId = 1 },
			new Planet(6, "Ommones Gamma III", "0FE8:00B0:0C61:0089") { SentinelsActivity = Sentinels.None, Biome = "Arctic", Resources = "Frost crystal, Emeril, Dioxite, Silver", Version = "Endurance", DiscovererId = 1, SolarSystemId = 1 },
			new Planet(7, "Aydar II", "04DF:00CA:0551:0197") { SentinelsActivity = Sentinels.Aggressive, Biome = "Vapour", Resources = "Sodium, Parafinium, Copper", Version = "Interceptor", DiscovererId = 2, SolarSystemId = 2 },
			new Planet(8, "Adninkin Beta", "0EF6:00FB:0EE5:0025"){ SentinelsActivity = Sentinels.High, Biome="Viridescent", Resources = "Star bulb, Copper, Parafinium, Salt", Galaxy = "Hilbert", Version = "Singularity", DiscovererId = 2, SolarSystemId = 3}
		};
		entity.HasData(planets);
	}
}
