using Atoms.Discoveries.Database.Domain;

namespace Atoms.Discoveries.Database.API.Data.Models;

public class PlanetModel : SystemDiscoveryModel
{
	public override string DiscoveryType => nameof(Planet);
	public string? SentinelsActivity { get; set; }
	public string? Biome { get; set; }
	public string? Resources { get; set; }
	public string? GrassColor { get; set; }
	public string? SkyColor { get; set; }
	public string? WaterColor { get; set; }
}
