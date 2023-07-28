using Atoms.Discoveries.Database.API.Data.DTO;
using Atoms.Discoveries.Database.API.Data.Models;
using Atoms.Discoveries.Database.Domain;
using Atoms.Discoveries.Database.Domain.Enums;

namespace Atoms.Discoveries.Database.API.Data.Converters;

public static class FreighterConverters
{
	public static FreighterDTO FreighterToDTO(Freighter freighter)
	{
		return new FreighterDTO
		{
			Id = freighter.Id,
			Name = freighter.Name,
			Coordinates = freighter.Coordinates,
			Galaxy = freighter.Galaxy,
			Platform = freighter.Platform.ToString(),
			Version = freighter.Version,
			Tags = freighter.Tags,
			Notes = freighter.Notes,
			DiscovererId = freighter.DiscovererId,
			SolarSystemId = freighter.SolarSystemId,
			Type = freighter.Type,
			Slots = freighter.Slots,
			Colors = freighter.Colors,
		};
	}
	public static Freighter FreighterFromModel(FreighterModel freighter)
	{
		return new Freighter(freighter.Name, freighter.Coordinates, freighter.Galaxy)
		{
			Name = freighter.Name,
			DiscoveryType = freighter.DiscoveryType,
			Coordinates = freighter.Coordinates,
			Galaxy = freighter.Galaxy,
			Platform = Enum.Parse<Platform>(freighter.Platform),
			Version = freighter.Version,
			Tags = freighter.Tags,
			Notes = freighter.Notes,
			DiscovererId = freighter.DiscovererId,
			SolarSystemId = freighter.SolarSystemId,
			Type = freighter.Type,
			Slots = freighter.Slots,
			Colors = freighter.Colors,
		};
	}
}
