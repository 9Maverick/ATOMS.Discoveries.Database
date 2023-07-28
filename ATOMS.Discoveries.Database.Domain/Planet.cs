using Atoms.Discoveries.Database.Domain.Enums;

namespace Atoms.Discoveries.Database.Domain;

public class Planet : SystemDiscovery
{
	public List<PlanetDiscovery> Discoveries { get; set; }
	public Sentinels? SentinelsActivity { get; set; }
	public string? Biome { get; set; }
	public string? Resources { get; set; }
	public string? GrassColor { get; set; }
	public string? SkyColor { get; set; }
	public string? WaterColor { get; set; }

	public Planet(string name, string coordinates, string galaxy = "Euclid") : base(name, nameof(Planet), coordinates, galaxy)
	{
		Discoveries = new List<PlanetDiscovery>();
	}
	public Planet(ulong id, string name, string coordinates, string galaxy = "Euclid") : base(id, name, nameof(Planet), coordinates, galaxy)
	{
		Discoveries = new List<PlanetDiscovery>();
	}
}
