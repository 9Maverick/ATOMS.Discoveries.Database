namespace Atoms.Discoveries.Database.Domain;

public class PlanetDiscovery : SystemDiscovery
{
	public Planet? Planet { get; set; }
	public ulong? PlanetId { get; set; }

	public PlanetDiscovery(string name, string discoveryType, string coordinates, string galaxy = "Euclid") : base(name, discoveryType, coordinates, galaxy) { }
	public PlanetDiscovery(ulong id, string name, string discoveryType, string coordinates, string galaxy = "Euclid") : base(id, name, discoveryType, coordinates, galaxy) { }
}
