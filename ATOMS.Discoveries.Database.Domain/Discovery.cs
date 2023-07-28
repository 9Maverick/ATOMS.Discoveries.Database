using Atoms.Discoveries.Database.Domain.Enums;

namespace Atoms.Discoveries.Database.Domain;

public class Discovery
{
	public ulong Id { get; set; }
	public string Name { get; set; }
	public string DiscoveryType { get; set; }
	public string Coordinates { get; set; }
	public string Galaxy { get; set; }
	public Platform? Platform { get; set; }
	/// <summary>
	/// Version of game in which discovery was made
	/// </summary>
	public string? Version { get; set; }
	public string? Tags { get; set; }
	public string? Notes { get; set; }
	public User? Discoverer { get; set; }
	public ulong? DiscovererId { get; set; }
	public List<Image>? Images { get; set; }

	public Discovery(string name, string discoveryType, string coordinates, string galaxy = "Euclid")
	{
		Name = name;
		DiscoveryType = discoveryType;
		Coordinates = coordinates;
		Galaxy = galaxy;
	}
	public Discovery(ulong id, string name, string discoveryType, string coordinates, string galaxy = "Euclid")
	{
		Id = id;
		Name = name;
		DiscoveryType = discoveryType;
		Coordinates = coordinates;
		Galaxy = galaxy;
	}

	private Discovery() : this(null!, null!, null!, null!) { }
}
