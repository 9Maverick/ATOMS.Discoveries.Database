using Atoms.Discoveries.Database.Domain;

namespace Atoms.Discoveries.Database.API.Data.DTO;

public class FaunaDTO : PlanetDiscoveryDTO
{
	public override string DiscoveryType => nameof(Fauna);
	public string Species { get; set; }
	public string? TameProduct { get; set; }
	public double? Height { get; set; }
}
