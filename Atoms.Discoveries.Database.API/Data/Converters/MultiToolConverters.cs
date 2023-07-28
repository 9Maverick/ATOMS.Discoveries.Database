using Atoms.Discoveries.Database.API.Data.DTO;
using Atoms.Discoveries.Database.API.Data.Models;
using Atoms.Discoveries.Database.Domain;
using Atoms.Discoveries.Database.Domain.Enums;

namespace Atoms.Discoveries.Database.API.Data.Converters;

public static class MultiToolConverters
{
	public static MultiToolDTO MultiToolToDTO(MultiTool multiTool)
	{
		return new MultiToolDTO
		{
			Id = multiTool.Id,
			Name = multiTool.Name,
			Coordinates = multiTool.Coordinates,
			Galaxy = multiTool.Galaxy,
			Platform = multiTool.Platform.ToString(),
			Version = multiTool.Version,
			Tags = multiTool.Tags,
			Notes = multiTool.Notes,
			DiscovererId = multiTool.DiscovererId,
			SolarSystemId = multiTool.SolarSystemId,
			PlanetId = multiTool.PlanetId,
			Type = multiTool.Type,
			Size = multiTool.Size,
			Colors = multiTool.Colors,
			Class = multiTool.Class.ToString(),
		};
	}
	public static MultiTool MultiToolFromModel(MultiToolModel multiTool)
	{
		return new MultiTool(multiTool.Name, multiTool.Type, multiTool.Size, multiTool.Coordinates, multiTool.Galaxy)
		{
			Name = multiTool.Name,
			DiscoveryType = multiTool.DiscoveryType,
			Coordinates = multiTool.Coordinates,
			Galaxy = multiTool.Galaxy,
			Platform = Enum.Parse<Platform>(multiTool.Platform),
			Version = multiTool.Version,
			Tags = multiTool.Tags,
			Notes = multiTool.Notes,
			DiscovererId = multiTool.DiscovererId,
			SolarSystemId = multiTool.SolarSystemId,
			PlanetId = multiTool.PlanetId,
			Colors = multiTool.Colors,
			Class = Enum.Parse<Class>(multiTool.Class),
		};
	}
}
