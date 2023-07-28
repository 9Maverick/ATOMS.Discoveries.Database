using Atoms.Discoveries.Database.Domain.Enums;

namespace Atoms.Discoveries.Database.Domain;

public class SolarSystem : Discovery
{
	public Lifeform DominantLifeform { get; set; }
	public Economy Economy { get; set; }
	public List<Planet> Planets
	{
		get => Discoveries.Where(d => d.DiscoveryType == nameof(Planet)).Select(d => (Planet)d).ToList();
	}
	public List<SystemDiscovery> Discoveries { get; set; }

	public SolarSystem(string name, string coordinates, string galaxy = "Euclid") : base(name, nameof(SolarSystem), coordinates, galaxy)
	{
		Discoveries = new List<SystemDiscovery>();
	}
	public SolarSystem(ulong id, string name, string coordinates, string galaxy = "Euclid") : base(id, name, nameof(SolarSystem), coordinates, galaxy)
	{
		Discoveries = new List<SystemDiscovery>();
	}
}
