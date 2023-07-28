using Atoms.Discoveries.Database.Domain;

namespace Atoms.Discoveries.Database.API.Data.DTO;

public class FrigateDTO : SystemDiscoveryDTO
{
	public override string DiscoveryType => nameof(Frigate);
	public string Type { get; set; }
	public string? Colors { get; set; }

}
