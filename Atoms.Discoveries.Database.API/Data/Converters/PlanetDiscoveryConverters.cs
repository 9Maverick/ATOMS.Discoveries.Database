using Atoms.Discoveries.Database.API.Data.DTO;
using Atoms.Discoveries.Database.API.Data.Models;
using Atoms.Discoveries.Database.Domain;
using Atoms.Discoveries.Database.Domain.Enums;

namespace Atoms.Discoveries.Database.API.Data.Converters;

public static class PlanetDiscoveryConverters
{
	public static PlanetDiscoveryDTO PlanetDiscoveryToDTO(PlanetDiscovery planetDiscovery)
	{
		return new PlanetDiscoveryDTO
		{
			Id = planetDiscovery.Id,
			Name = planetDiscovery.Name,
			DiscoveryType = planetDiscovery.DiscoveryType,
			Coordinates = planetDiscovery.Coordinates,
			Galaxy = planetDiscovery.Galaxy,
			Platform = planetDiscovery.Platform.ToString(),
			Version = planetDiscovery.Version,
			Tags = planetDiscovery.Tags,
			Notes = planetDiscovery.Notes,
			DiscovererId = planetDiscovery.DiscovererId,
			SolarSystemId = planetDiscovery.SolarSystemId,
			PlanetId = planetDiscovery.PlanetId,
		};
	}
	public static PlanetDiscovery PlanetDiscoveryFromModel(PlanetDiscoveryModel planetDiscovery)
	{
		return new PlanetDiscovery(planetDiscovery.Name, planetDiscovery.Coordinates, planetDiscovery.Galaxy)
		{
			Platform = Enum.Parse<Platform>(planetDiscovery.Platform),
			Version = planetDiscovery.Version,
			Tags = planetDiscovery.Tags,
			Notes = planetDiscovery.Notes,
			DiscovererId = planetDiscovery.DiscovererId,
			SolarSystemId = planetDiscovery.SolarSystemId,
			PlanetId = planetDiscovery.PlanetId,
		};
	}
}
