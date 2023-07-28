using Atoms.Discoveries.Database.API.Data.DTO;
using Atoms.Discoveries.Database.API.Data.Models;
using Atoms.Discoveries.Database.Domain;
using Atoms.Discoveries.Database.Domain.Enums;

namespace Atoms.Discoveries.Database.API.Data.Converters;

public static class SystemDiscoveryConverters
{
	public static SystemDiscoveryDTO SystemDiscoveryToDTO(SystemDiscovery systemDiscovery)
	{
		return new SystemDiscoveryDTO
		{
			Id = systemDiscovery.Id,
			Name = systemDiscovery.Name,
			DiscoveryType = systemDiscovery.DiscoveryType,
			Coordinates = systemDiscovery.Coordinates,
			Galaxy = systemDiscovery.Galaxy,
			Platform = systemDiscovery.Platform.ToString(),
			Version = systemDiscovery.Version,
			Tags = systemDiscovery.Tags,
			Notes = systemDiscovery.Notes,
			DiscovererId = systemDiscovery.DiscovererId,
			SolarSystemId = systemDiscovery.SolarSystemId
		};
	}
	public static SystemDiscovery SystemDiscoveryFromModel(SystemDiscoveryModel systemDiscovery)
	{
		return new SystemDiscovery(systemDiscovery.Name, systemDiscovery.Coordinates, systemDiscovery.Galaxy)
		{
			Platform = Enum.Parse<Platform>(systemDiscovery.Platform),
			Version = systemDiscovery.Version,
			Tags = systemDiscovery.Tags,
			Notes = systemDiscovery.Notes,
			DiscovererId = systemDiscovery.DiscovererId,
			SolarSystemId = systemDiscovery.SolarSystemId
		};
	}
}
