using Atoms.Discoveries.Database.API.Data.DTO;
using Atoms.Discoveries.Database.API.Data.Models;
using Atoms.Discoveries.Database.Domain;
using Atoms.Discoveries.Database.Domain.Enums;

namespace Atoms.Discoveries.Database.API.Data.Converters;

public static class DiscoveryConverters
{
	public static DiscoveryDTO DiscoveryToDTO(Discovery discovery)
	{
		return new DiscoveryDTO
		{
			Id = discovery.Id,
			Name = discovery.Name,
			DiscoveryType = discovery.DiscoveryType,
			Coordinates = discovery.Coordinates,
			Galaxy = discovery.Galaxy,
			Platform = discovery.Platform.ToString(),
			Version = discovery.Version,
			Tags = discovery.Tags,
			Notes = discovery.Notes,
			DiscovererId = discovery.DiscovererId
		};
	}
	public static Discovery DiscoveryFromModel(DiscoveryModel discovery)
	{
		return new Discovery(discovery.Name, discovery.DiscoveryType, discovery.Coordinates, discovery.Galaxy)
		{
			Platform = Enum.Parse<Platform>(discovery.Platform),
			Version = discovery.Version,
			Tags = discovery.Tags,
			Notes = discovery.Notes,
			DiscovererId = discovery.DiscovererId
		};
	}
}
