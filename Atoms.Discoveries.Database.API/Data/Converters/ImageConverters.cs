using Atoms.Discoveries.Database.API.Data.DTO;
using Atoms.Discoveries.Database.Domain;

namespace Atoms.Discoveries.Database.API.Data.Converters;

public static class ImageConverters
{
	public static ImageDTO ImageToDTO(Image image)
	{
		return new ImageDTO
		{
			Id = image.Id,
			Data = image.Data,
			Description = image.Description,
			DiscoveryId = image.DiscoveryId
		};
	}
}
