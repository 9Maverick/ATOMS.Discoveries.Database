namespace Atoms.Discoveries.Database.API.Data.DTO;

public class ImageDTO
{
	public ulong Id { get; set; }
	public byte[] Data { get; set; }
	public string? Description { get; set; }
	public ulong DiscoveryId { get; set; }
}
