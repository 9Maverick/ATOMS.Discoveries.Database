namespace Atoms.Discoveries.Database.Domain;

public class Fauna : PlanetDiscovery
{
	public string Species { get; set; }
	public string? TameProduct { get; set; }
	public double? Height { get; set; }

	public Fauna(string name, string species, string coordinates, string galaxy = "Euclid") : base(name, nameof(Fauna), coordinates, galaxy)
	{
		Species = species;
	}
	public Fauna(ulong id, string name, string species, string coordinates, string galaxy = "Euclid") : base(id, name, nameof(Fauna), coordinates, galaxy)
	{
		Species = species;
	}

	private Fauna() : this(null!, null!, null!, null!) { }
}
