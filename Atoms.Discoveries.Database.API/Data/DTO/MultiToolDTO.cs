using Atoms.Discoveries.Database.Domain;

namespace Atoms.Discoveries.Database.API.Data.DTO;

public class MultiToolDTO : PlanetDiscoveryDTO
{
	public override string DiscoveryType => nameof(MultiTool);
	public string Type { get; set; }
	public string Class { get; set; }
	public string? Size { get; set; }
	public string? Colors { get; set; }
}
