using Atoms.Discoveries.Database.API.Data.DTO;
using Atoms.Discoveries.Database.API.Data.Models;
using Atoms.Discoveries.Database.Domain;
using Atoms.Discoveries.Database.Domain.Enums;

namespace Atoms.Discoveries.Database.API.Data.Converters;

public static class SolarSystemConverters
{
	public static SolarSystemDTO SolarSystemToDTO(SolarSystem solarSystem)
	{
		return new SolarSystemDTO
		{
			Id = solarSystem.Id,
			Name = solarSystem.Name,
			Coordinates = solarSystem.Coordinates,
			Galaxy = solarSystem.Galaxy,
			Platform = solarSystem.Platform.ToString(),
			Version = solarSystem.Version,
			Tags = solarSystem.Tags,
			Notes = solarSystem.Notes,
			DiscovererId = solarSystem.DiscovererId,
			DominantLifeform = solarSystem.DominantLifeform.ToString(),
			Economy = solarSystem.Economy.ToString()
		};
	}
	public static SolarSystem SolarSystemFromModel(SolarSystemModel solarSystem)
	{
		return new SolarSystem(solarSystem.Name, solarSystem.Coordinates, solarSystem.Galaxy)
		{
			Name = solarSystem.Name,
			DiscoveryType = solarSystem.DiscoveryType,
			Coordinates = solarSystem.Coordinates,
			Galaxy = solarSystem.Galaxy,
			Platform = Enum.Parse<Platform>(solarSystem.Platform),
			Version = solarSystem.Version,
			Tags = solarSystem.Tags,
			Notes = solarSystem.Notes,
			DiscovererId = solarSystem.DiscovererId,
			DominantLifeform = Enum.Parse<Lifeform>(solarSystem.DominantLifeform),
			Economy = Enum.Parse<Economy>(solarSystem.Economy)
		};
	}
}
