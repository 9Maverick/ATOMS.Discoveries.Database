namespace Atoms.Discoveries.Database.Domain;

public class Image
{
	public ulong Id { get; set; }
	public byte[] Data { get; set; }
	public string? Description { get; set; }
	public Discovery Discovery { get; set; } = null!;
	public ulong DiscoveryId { get; set; }

	public Image(byte[] data)
	{
		Data = data;
	}

	public Image(ulong id, byte[] data, ulong discoveryId)
	{
		Id = id;
		Data = data;
		DiscoveryId = discoveryId;
	}

	private Image() : this(null!) { }
}
