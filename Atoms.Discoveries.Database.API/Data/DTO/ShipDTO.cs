using Atoms.Discoveries.Database.Domain;

namespace Atoms.Discoveries.Database.API.Data.DTO;

public class ShipDTO : PlanetDiscoveryDTO
{
	public override string DiscoveryType => nameof(Ship);
	public string Type { get; set; }
	public string Class { get; set; }
	public short? Slots { get; set; }
	public string? Colors { get; set; }
}
