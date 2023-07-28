using Atoms.Discoveries.Database.Domain;

namespace Atoms.Discoveries.Database.API.Data.Models;

public class SolarSystemModel : DiscoveryModel
{
	public override string DiscoveryType => nameof(SolarSystem);
	public string DominantLifeform { get; set; }
	public string Economy { get; set; }
}
