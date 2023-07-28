﻿namespace Atoms.Discoveries.Database.API.Data.DTO;

public class DiscoveryDTO
{
	public ulong Id { get; set; }
	public string Name { get; set; }
	public virtual string DiscoveryType { get; set; }
	public string Coordinates { get; set; }
	public string Galaxy { get; set; } = "Euclid";
	public string? Platform { get; set; }
	public string? Version { get; set; }
	public string? Tags { get; set; }
	public string? Notes { get; set; }
	public ulong? DiscovererId { get; set; }
}
