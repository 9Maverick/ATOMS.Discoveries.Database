namespace Atoms.Discoveries.Database.Domain;

public class Frigate : SystemDiscovery
{
	public string Type { get; set; }
	public string? Colors { get; set; }

	public Frigate(string name, string type, string coordinates, string galaxy = "Euclid") : base(name, nameof(Frigate), coordinates, galaxy)
	{
		Type = type;
	}
	public Frigate(ulong id, string name, string type, string coordinates, string galaxy = "Euclid") : base(id, name, nameof(Frigate), coordinates, galaxy)
	{
		Type = type;
	}

	private Frigate() : this(null!, null!, null!, null!) { }
}
