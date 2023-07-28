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
public class PlanetDiscoveriesController : ControllerBase
{

	private readonly DiscoveriesContext _context;

	public PlanetDiscoveriesController(DiscoveriesContext context)
	{
		_context = context;
	}

	[HttpGet]
	public async Task<ActionResult<IEnumerable<PlanetDiscoveryDTO>>> GetPlanetDiscoveries([FromQuery] PaginationParameters paginationParameters)
	{
		return await _context.PlanetDiscoveries
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
				SolarSystemId = planetDiscovery.SolarSystemId,
				PlanetId = planetDiscovery.PlanetId,
			})
			.OrderBy(planetDiscovery => planetDiscovery.Id)
			.AsNoTracking()
			.ToListAsync();
	}

	[HttpGet("{planetDiscoveryId}")]
	public async Task<ActionResult<PlanetDiscoveryDTO>> GetPlanetDiscovery(ulong planetDiscoveryId)
	{
		var planetDiscovery = await _context.PlanetDiscoveries.FindAsync(planetDiscoveryId);
		if (planetDiscovery == null)
		{
			return NotFound();
		}
		return PlanetDiscoveryConverters.PlanetDiscoveryToDTO(planetDiscovery);
	}

	[HttpPost]
	public async Task<ActionResult<PlanetDiscovery>> PostPlanetDiscovery(PlanetDiscoveryModel planetDiscoveryModel)
	{
		var planetDiscovery = PlanetDiscoveryConverters.PlanetDiscoveryFromModel(planetDiscoveryModel);
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

	[HttpPut("{planetDiscoveryId}")]
	public async Task<IActionResult> PutPlanetDiscovery(ulong planetDiscoveryId, PlanetDiscoveryModel planetDiscoveryModel)
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

	[HttpDelete("{planetDiscoveryId}")]
	public async Task<IActionResult> DeletePlanetDiscovery(ulong planetDiscoveryId)
	{
		var planetDiscovery = await _context.PlanetDiscoveries.FindAsync(planetDiscoveryId);
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
}