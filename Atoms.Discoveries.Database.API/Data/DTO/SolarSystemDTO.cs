using Atoms.Discoveries.Database.Domain;

namespace Atoms.Discoveries.Database.API.Data.DTO;

public class SolarSystemDTO : DiscoveryDTO
{
    public override string DiscoveryType => nameof(SolarSystem);
    public string DominantLifeform { get; set; }
    public string Economy { get; set; }
}
