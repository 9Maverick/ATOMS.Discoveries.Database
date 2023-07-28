using Atoms.Discoveries.Database.API.Data.DTO;
using Atoms.Discoveries.Database.API.Data.Models;
using Atoms.Discoveries.Database.Domain;
using Atoms.Discoveries.Database.Domain.Enums;

namespace Atoms.Discoveries.Database.API.Data.Converters;

public static class FaunaConverters
{
	public static FaunaDTO FaunaToDTO(Fauna fauna)
	{
		return new FaunaDTO
		{
			Id = fauna.Id,
			Name = fauna.Name,
			Coordinates = fauna.Coordinates,
			Galaxy = fauna.Galaxy,
			Platform = fauna.Platform.ToString(),
			Version = fauna.Version,
			Tags = fauna.Tags,
			Notes = fauna.Notes,
			DiscovererId = fauna.DiscovererId,
			SolarSystemId = fauna.SolarSystemId,
			PlanetId = fauna.PlanetId,
			Species = fauna.Species,
			TameProduct = fauna.TameProduct,
			Height = fauna.Height,
		};
	}
	public static Fauna FaunaFromModel(FaunaModel fauna)
	{
		return new Fauna(fauna.Name, fauna.Coordinates, fauna.Galaxy)
		{
			Name = fauna.Name,
			DiscoveryType = fauna.DiscoveryType,
			Coordinates = fauna.Coordinates,
			Galaxy = fauna.Galaxy,
			Platform = Enum.Parse<Platform>(fauna.Platform),
			Version = fauna.Version,
			Tags = fauna.Tags,
			Notes = fauna.Notes,
			DiscovererId = fauna.DiscovererId,
			SolarSystemId = fauna.SolarSystemId,
			PlanetId = fauna.PlanetId,
			Species = fauna.Species,
			TameProduct = fauna.TameProduct,
			Height = fauna.Height,
		};
	}
}
