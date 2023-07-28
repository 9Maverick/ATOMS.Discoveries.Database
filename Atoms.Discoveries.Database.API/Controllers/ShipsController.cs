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
public class ShipsController : ControllerBase
{

	private readonly DiscoveriesContext _context;

	public ShipsController(DiscoveriesContext context)
	{
		_context = context;
	}

	[HttpGet]
	public async Task<ActionResult<IEnumerable<ShipDTO>>> GetShips([FromQuery] PaginationParameters paginationParameters)
	{
		return await _context.Ships
			.Skip((int)paginationParameters.Offset)
			.Take((int)paginationParameters.Limit)
			.Select(ship => new ShipDTO
			{
				Id = ship.Id,
				Name = ship.Name,
				DiscoveryType = ship.DiscoveryType,
				Coordinates = ship.Coordinates,
				Galaxy = ship.Galaxy,
				Platform = ship.Platform.ToString(),
				Version = ship.Version,
				Tags = ship.Tags,
				Notes = ship.Notes,
				DiscovererId = ship.DiscovererId,
				SolarSystemId = ship.SolarSystemId,
				PlanetId = ship.PlanetId,
				Type = ship.Type,
				Slots = ship.Slots,
				Colors = ship.Colors,
				Class = ship.Class.ToString(),
			})
			.OrderBy(ship => ship.Id)
			.AsNoTracking()
			.ToListAsync();
	}

	[HttpGet("{shipId}")]
	public async Task<ActionResult<ShipDTO>> GetShip(ulong shipId)
	{
		var ship = await _context.Ships.FindAsync(shipId);
		if (ship == null)
		{
			return NotFound();
		}
		return ShipConverters.ShipToDTO(ship);
	}

	[HttpPost]
	public async Task<ActionResult<Ship>> PostShip(ShipModel shipModel)
	{
		var ship = ShipConverters.ShipFromModel(shipModel);
		var planet = await _context.Planets.FindAsync(ship.PlanetId);
		var system = await _context.SolarSystems.FindAsync(ship.SolarSystemId);
		if (planet != null)
		{
			ship.Galaxy = planet.Galaxy;
			ship.Coordinates = planet.Coordinates;
			ship.SolarSystemId = planet.SolarSystemId;
		}
		else if (system != null)
		{
			ship.Galaxy = system.Galaxy;
		}
		_context.Ships.Add(ship);
		await _context.SaveChangesAsync();

		return CreatedAtAction(nameof(GetShip), new { id = ship.Id }, ship);
	}

	[HttpPut("{shipId}")]
	public async Task<IActionResult> PutShip(ulong shipId, ShipModel shipModel)
	{
		if (!ShipExists(shipId))
		{
			return NotFound();
		}

		var ship = ShipConverters.ShipFromModel(shipModel);
		_context.Entry(ship).State = EntityState.Modified;

		await _context.SaveChangesAsync();

		return Ok();
	}

	[HttpDelete("{shipId}")]
	public async Task<IActionResult> DeleteShip(ulong shipId)
	{
		var ship = await _context.Ships.FindAsync(shipId);
		if (ship == null)
		{
			return NotFound();
		}

		_context.Ships.Remove(ship);
		await _context.SaveChangesAsync();

		return Ok();
	}

	private bool ShipExists(ulong id)
	{
		return _context.Ships.Any(ship => ship.Id == id);
	}
}