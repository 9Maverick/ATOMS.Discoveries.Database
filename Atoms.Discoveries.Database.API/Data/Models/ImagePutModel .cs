namespace Atoms.Discoveries.Database.API.Data.Models;

public class ImagePutModel
{
	public byte[] Data { get; set; }
	public string? Description { get; set; }
	public ulong DiscoveryId { get; set; }
}
