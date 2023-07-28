using Atoms.Discoveries.Database.Domain.Enums;

namespace Atoms.Discoveries.Database.Domain;

public class Ship : PlanetDiscovery
{
	public string Type { get; set; }
	public Class Class { get; set; }
	/// <summary>
	/// Defines whenever ship is crashed on planet
	/// </summary>
	public bool IsCrashed => Planet != null;
	public short? Slots { get; set; }
	public string? Colors { get; set; }

	public Ship(string name, string type, string coordinates, string galaxy = "Euclid") : base(name, nameof(Ship), coordinates, galaxy)
	{
		Type = type;
	}
	public Ship(ulong id, string name, string type, string coordinates, string galaxy = "Euclid") : base(id, name, nameof(Ship), coordinates, galaxy)
	{
		Type = type;
	}

	private Ship() : this(null!, null!, null!, null!) { }
}
