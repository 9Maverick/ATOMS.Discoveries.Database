namespace Atoms.Discoveries.Database.Domain;

public class Freighter : SystemDiscovery
{
	public string Type { get; set; }
	public short? Slots { get; set; }
	public string? Colors { get; set; }

	public Freighter(string name, string type, string coordinates, string galaxy = "Euclid") : base(name, nameof(Freighter), coordinates, galaxy)
	{
		Type = type;
	}
	public Freighter(ulong id, string name, string type, string coordinates, string galaxy = "Euclid") : base(id, name, nameof(Freighter), coordinates, galaxy)
	{
		Type = type;
	}

	private Freighter() : this(null!, null!, null!, null!) { }
}
