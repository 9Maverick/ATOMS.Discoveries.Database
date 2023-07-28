using Atoms.Discoveries.Database.Domain;

namespace Atoms.Discoveries.Database.API.Data.DTO;

public class FreighterDTO : SystemDiscoveryDTO
{
	public override string DiscoveryType => nameof(Freighter);
	public string Type { get; set; }
	public short? Slots { get; set; }
	public string? Colors { get; set; }

}
