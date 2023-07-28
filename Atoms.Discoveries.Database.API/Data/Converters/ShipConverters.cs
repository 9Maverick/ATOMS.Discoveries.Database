using Atoms.Discoveries.Database.API.Data.DTO;
using Atoms.Discoveries.Database.API.Data.Models;
using Atoms.Discoveries.Database.Domain;
using Atoms.Discoveries.Database.Domain.Enums;

namespace Atoms.Discoveries.Database.API.Data.Converters;

public static class ShipConverters
{
	public static ShipDTO ShipToDTO(Ship ship)
	{
		return new ShipDTO
		{
			Id = ship.Id,
			Name = ship.Name,
			Coordinates = ship.Coordinates,
			Galaxy = ship.Galaxy,
			Platform = ship.Platform.ToString(),
			Version = ship.Version,
			Tags = ship.Tags,
			Notes = ship.Notes,
			DiscovererId = ship.DiscovererId,
			SolarSystemId = ship.SolarSystemId,
			PlanetId = ship.PlanetId,
			Type = ship.Type,
			Slots = ship.Slots,
			Colors = ship.Colors,
			Class = ship.Class.ToString(),
		};
	}
	public static Ship ShipFromModel(ShipModel ship)
	{
		return new Ship(ship.Name, ship.Coordinates, ship.Galaxy)
		{
			Name = ship.Name,
			DiscoveryType = ship.DiscoveryType,
			Coordinates = ship.Coordinates,
			Galaxy = ship.Galaxy,
			Platform = Enum.Parse<Platform>(ship.Platform),
			Version = ship.Version,
			Tags = ship.Tags,
			Notes = ship.Notes,
			DiscovererId = ship.DiscovererId,
			SolarSystemId = ship.SolarSystemId,
			PlanetId = ship.PlanetId,
			Type = ship.Type,
			Slots = ship.Slots,
			Colors = ship.Colors,
			Class = Enum.Parse<Class>(ship.Class),
		};
	}
}
