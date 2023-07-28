namespace Atoms.Discoveries.Database.Domain;

public class SystemDiscovery : Discovery
{
	public SolarSystem? SolarSystem { get; set; }
	public ulong? SolarSystemId { get; set; }

	public SystemDiscovery(string name, string discoveryType, string coordinates, string galaxy = "Euclid") : base(name, discoveryType, coordinates, galaxy) { }
	public SystemDiscovery(ulong id, string name, string discoveryType, string coordinates, string galaxy = "Euclid") : base(id, name, discoveryType, coordinates, galaxy) { }
}
