using Atoms.Discoveries.Database.API.Data.Converters;
using Atoms.Discoveries.Database.API.Data.DTO;
using Atoms.Discoveries.Database.API.Data.Models;
using Atoms.Discoveries.Database.Data;
using Atoms.Discoveries.Database.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Atoms.Discoveries.Database.Controllers;

[ApiController]
[Route("/api/[controller]")]
public class PlanetsController : ControllerBase
{

	private readonly DiscoveriesContext _context;

	public PlanetsController(DiscoveriesContext context)
	{
		_context = context;
	}

	[HttpGet]
	public async Task<ActionResult<IEnumerable<PlanetDTO>>> GetPlanets([FromQuery] PaginationParameters paginationParameters)
	{
		return await _context.Planets
			.Skip((int)paginationParameters.Offset)
			.Take((int)paginationParameters.Limit)
			.Select(planet => new PlanetDTO
			{
				Id = planet.Id,
				Name = planet.Name,
				Coordinates = planet.Coordinates,
				Galaxy = planet.Galaxy,
				Platform = planet.Platform.ToString(),
				Version = planet.Version,
				Tags = planet.Tags,
				Notes = planet.Notes,
				DiscovererId = planet.DiscovererId,
				SolarSystemId = planet.SolarSystemId,
				SentinelsActivity = planet.SentinelsActivity.ToString(),
				Biome = planet.Biome,
				Resources = planet.Resources,
				GrassColor = planet.GrassColor,
				SkyColor = planet.SkyColor,
				WaterColor = planet.WaterColor
			})
			.OrderBy(planet => planet.Id)
			.AsNoTracking()
			.ToListAsync();
	}

	[HttpGet("{planetId}")]
	public async Task<ActionResult<PlanetDTO>> GetPlanet(ulong planetId)
	{
		var planet = await _context.Planets.FindAsync(planetId);
		if (planet == null)
		{
			return NotFound();
		}
		return PlanetConverters.PlanetToDTO(planet);
	}

	[HttpPost]
	public async Task<ActionResult<Planet>> PostPlanet(PlanetModel planetModel)
	{
		var planet = PlanetConverters.PlanetFromModel(planetModel);
		var system = await _context.SolarSystems.FindAsync(planetModel.SolarSystemId);
		if (planet != null)
		{
			planet.Galaxy = system.Galaxy;
		}
		_context.Planets.Add(planet);
		await _context.SaveChangesAsync();

		return CreatedAtAction(nameof(GetPlanet), new { id = planet.Id }, planet);
	}

	[HttpPut("{planetId}")]
	public async Task<IActionResult> PutPlanet(ulong planetId, PlanetModel planetModel)
	{
		if (!PlanetExists(planetId))
		{
			return NotFound();
		}

		var planet = PlanetConverters.PlanetFromModel(planetModel);
		_context.Entry(planet).State = EntityState.Modified;

		await _context.SaveChangesAsync();

		return Ok();
	}

	[HttpDelete("{planetId}")]
	public async Task<IActionResult> DeletePlanet(ulong planetId)
	{
		var planet = await _context.Planets.FindAsync(planetId);
		if (planet == null)
		{
			return NotFound();
		}

		_context.Planets.Remove(planet);
		await _context.SaveChangesAsync();

		return Ok();
	}

	[HttpGet("{planetId}/PlanetDiscoveries")]
	public async Task<ActionResult<IEnumerable<PlanetDiscoveryDTO>>> GetPlanetDiscoveries([FromQuery] PaginationParameters paginationParameters, ulong planetId)
	{
		return await _context.PlanetDiscoveries
			.Where(planetDiscovery => planetDiscovery.PlanetId == planetId)
			.Skip((int)paginationParameters.Offset)
			.Take((int)paginationParameters.Limit)
			.Select(planetDiscovery => new PlanetDiscoveryDTO
			{
				Id = planetDiscovery.Id,
				Name = planetDiscovery.Name,
				DiscoveryType = planetDiscovery.DiscoveryType,
				Coordinates = planetDiscovery.Coordinates,
				Galaxy = planetDiscovery.Galaxy,
				Platform = planetDiscovery.Platform.ToString(),
				Version = planetDiscovery.Version,
				Tags = planetDiscovery.Tags,
				Notes = planetDiscovery.Notes,
				DiscovererId = planetDiscovery.DiscovererId,
				PlanetId = planetDiscovery.PlanetId
			})
			.OrderBy(planetDiscovery => planetDiscovery.Id)
			.AsNoTracking()
			.ToListAsync();
	}

	[HttpGet("{planetId}/PlanetDiscoveries/{planetDiscoveryId}")]
	public async Task<ActionResult<PlanetDiscoveryDTO>> GetPlanetDiscovery(ulong planetDiscoveryId, ulong planetId)
	{
		var planetDiscovery = await _context.PlanetDiscoveries
			.Where(planetDiscovery =>
				planetDiscovery.PlanetId == planetId && planetDiscovery.Id == planetDiscoveryId
			)
			.FirstOrDefaultAsync();
		if (planetDiscovery == null)
		{
			return NotFound();
		}
		return PlanetDiscoveryConverters.PlanetDiscoveryToDTO(planetDiscovery);
	}

	[HttpPost("{planetId}/PlanetDiscoveries")]
	public async Task<ActionResult<PlanetDiscovery>> PostPlanetDiscovery(PlanetDiscoveryModel planetDiscoveryModel, ulong planetId)
	{
		var planetDiscovery = PlanetDiscoveryConverters.PlanetDiscoveryFromModel(planetDiscoveryModel);
		planetDiscovery.PlanetId = planetId;
		var planet = await _context.Planets.FindAsync(planetDiscovery.PlanetId);
		var system = await _context.SolarSystems.FindAsync(planetDiscovery.SolarSystemId);
		if (planet != null)
		{
			planetDiscovery.Galaxy = planet.Galaxy;
			planetDiscovery.Coordinates = planet.Coordinates;
			planetDiscovery.SolarSystemId = planet.SolarSystemId;
		}
		else if (system != null)
		{
			planetDiscovery.Galaxy = system.Galaxy;
		}
		_context.PlanetDiscoveries.Add(planetDiscovery);
		await _context.SaveChangesAsync();

		return CreatedAtAction(nameof(GetPlanetDiscovery), new { id = planetDiscovery.Id }, planetDiscovery);
	}

	[HttpPut("{planetId}/PlanetDiscoveries/{planetDiscoveryId}")]
	public async Task<IActionResult> PutPlanetDiscovery(ulong planetDiscoveryId, PlanetDiscoveryModel planetDiscoveryModel, ulong planetId)
	{
		if (!PlanetDiscoveryExists(planetDiscoveryId))
		{
			return NotFound();
		}

		var planetDiscovery = PlanetDiscoveryConverters.PlanetDiscoveryFromModel(planetDiscoveryModel);
		_context.Entry(planetDiscovery).State = EntityState.Modified;

		await _context.SaveChangesAsync();

		return Ok();
	}

	[HttpDelete("{planetId}/PlanetDiscoveries/{planetDiscoveryId}")]
	public async Task<IActionResult> DeletePlanetDiscovery(ulong planetDiscoveryId, ulong planetId)
	{
		var planetDiscovery = await _context.PlanetDiscoveries
			.Where(planetDiscovery =>
				planetDiscovery.PlanetId == planetId && planetDiscovery.Id == planetDiscoveryId
			)
			.FirstOrDefaultAsync();
		if (planetDiscovery == null)
		{
			return NotFound();
		}

		_context.PlanetDiscoveries.Remove(planetDiscovery);
		await _context.SaveChangesAsync();

		return Ok();
	}

	private bool PlanetDiscoveryExists(ulong id)
	{
		return _context.PlanetDiscoveries.Any(planetDiscovery => planetDiscovery.Id == id);
	}

	private bool PlanetExists(ulong id)
	{
		return _context.Planets.Any(planet => planet.Id == id);
	}
}