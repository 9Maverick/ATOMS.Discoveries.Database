using Atoms.Discoveries.Database.Domain.Enums;

namespace Atoms.Discoveries.Database.Domain;

public class MultiTool : PlanetDiscovery
{
	public string Type { get; set; }
	public Class Class { get; set; }
	public string Size { get; set; }
	public bool IsInSpaceStation => Planet == null;
	public string? Colors { get; set; }

	public MultiTool(string name, string type, string size, string coordinates, string galaxy = "Euclid") : base(name, nameof(Ship), coordinates, galaxy)
	{
		Type = type;
		Size = size;
	}
	public MultiTool(ulong id, string name, string type, string size, string coordinates, string galaxy = "Euclid") : base(id, name, nameof(Ship), coordinates, galaxy)
	{
		Type = type;
		Size = size;
	}
	private MultiTool() : this(null!, null!, null!, null!, null!) { }
}
