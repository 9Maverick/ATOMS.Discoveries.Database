using Atoms.Discoveries.Database.API.Data.DTO;
using Atoms.Discoveries.Database.API.Data.Models;
using Atoms.Discoveries.Database.Domain;
using Atoms.Discoveries.Database.Domain.Enums;

namespace Atoms.Discoveries.Database.API.Data.Converters;

public static class FrigateConverters
{
	public static FrigateDTO FrigateToDTO(Frigate frigate)
	{
		return new FrigateDTO
		{
			Id = frigate.Id,
			Name = frigate.Name,
			Coordinates = frigate.Coordinates,
			Galaxy = frigate.Galaxy,
			Platform = frigate.Platform.ToString(),
			Version = frigate.Version,
			Tags = frigate.Tags,
			Notes = frigate.Notes,
			DiscovererId = frigate.DiscovererId,
			SolarSystemId = frigate.SolarSystemId,
			Type = frigate.Type,
			Colors = frigate.Colors,
		};
	}
	public static Frigate FrigateFromModel(FrigateModel frigate)
	{
		return new Frigate(frigate.Name, frigate.Coordinates, frigate.Galaxy)
		{
			Name = frigate.Name,
			DiscoveryType = frigate.DiscoveryType,
			Coordinates = frigate.Coordinates,
			Galaxy = frigate.Galaxy,
			Platform = Enum.Parse<Platform>(frigate.Platform),
			Version = frigate.Version,
			Tags = frigate.Tags,
			Notes = frigate.Notes,
			DiscovererId = frigate.DiscovererId,
			SolarSystemId = frigate.SolarSystemId,
			Type = frigate.Type,
			Colors = frigate.Colors,
		};
	}
}
