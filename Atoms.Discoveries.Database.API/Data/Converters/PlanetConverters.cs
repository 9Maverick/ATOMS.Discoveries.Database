using Atoms.Discoveries.Database.API.Data.DTO;
using Atoms.Discoveries.Database.API.Data.Models;
using Atoms.Discoveries.Database.Domain;
using Atoms.Discoveries.Database.Domain.Enums;

namespace Atoms.Discoveries.Database.API.Data.Converters;

public static class PlanetConverters
{
	public static PlanetDTO PlanetToDTO(Planet planet)
	{
		return new PlanetDTO
		{
			Id = planet.Id,
			Name = planet.Name,
			Coordinates = planet.Coordinates,
			Galaxy = planet.Galaxy,
			Platform = planet.Platform.ToString(),
			Version = planet.Version,
			Tags = planet.Tags,
			Notes = planet.Notes,
			DiscovererId = planet.DiscovererId,
			SolarSystemId = planet.SolarSystemId,
			SentinelsActivity = planet.SentinelsActivity.ToString(),
			Biome = planet.Biome,
			Resources = planet.Resources,
			GrassColor = planet.GrassColor,
			SkyColor = planet.SkyColor,
			WaterColor = planet.WaterColor
		};
	}
	public static Planet PlanetFromModel(PlanetModel planet)
	{
		return new Planet(planet.Name, planet.Coordinates, planet.Galaxy)
		{
			Name = planet.Name,
			DiscoveryType = planet.DiscoveryType,
			Coordinates = planet.Coordinates,
			Galaxy = planet.Galaxy,
			Platform = Enum.Parse<Platform>(planet.Platform),
			Version = planet.Version,
			Tags = planet.Tags,
			Notes = planet.Notes,
			DiscovererId = planet.DiscovererId,
			SolarSystemId = planet.SolarSystemId,
			SentinelsActivity = Enum.Parse<Sentinels>(planet.SentinelsActivity),
			Biome = planet.Biome,
			Resources = planet.Resources,
			GrassColor = planet.GrassColor,
			SkyColor = planet.SkyColor,
			WaterColor = planet.WaterColor
		};
	}
}
