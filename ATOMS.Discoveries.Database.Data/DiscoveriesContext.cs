using Atoms.Discoveries.Database.Domain;
using Atoms.Discoveries.Database.SharedKernel.Configuration;
using Microsoft.EntityFrameworkCore;

namespace Atoms.Discoveries.Database.Data;

public class DiscoveriesContext : DbContext
{
	private readonly IModelConfiguration _modelConfiguration;

	public DbSet<User> Users => Set<User>();
	public DbSet<Discovery> Discoveries => Set<Discovery>();
	public DbSet<SolarSystem> SolarSystems => Set<SolarSystem>();
	public DbSet<SystemDiscovery> SystemDiscoveries => Set<SystemDiscovery>();
	public DbSet<Freighter> Freighters => Set<Freighter>();
	public DbSet<Frigate> Frigates => Set<Frigate>();
	public DbSet<Planet> Planets => Set<Planet>();
	public DbSet<PlanetDiscovery> PlanetDiscoveries => Set<PlanetDiscovery>();
	public DbSet<Ship> Ships => Set<Ship>();
	public DbSet<MultiTool> MultiTools => Set<MultiTool>();
	public DbSet<Fauna> Fauna => Set<Fauna>();
	public DbSet<Image> Images => Set<Image>();
	public DiscoveriesContext(DbContextOptions<DiscoveriesContext> options, IModelConfiguration modelConfiguration) :
		base(options)
	{
		_modelConfiguration = modelConfiguration;
	}
	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.ApplyConfigurationsFromAssembly(typeof(DiscoveriesContext).Assembly);
		_modelConfiguration.ConfigureModel(modelBuilder);
	}
}
