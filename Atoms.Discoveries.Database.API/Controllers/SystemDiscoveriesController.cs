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
public class SystemDiscoveriesController : ControllerBase
{

	private readonly DiscoveriesContext _context;

	public SystemDiscoveriesController(DiscoveriesContext context)
	{
		_context = context;
	}

	[HttpGet]
	public async Task<ActionResult<IEnumerable<SystemDiscoveryDTO>>> GetSystemDiscoveries([FromQuery] PaginationParameters paginationParameters)
	{
		return await _context.SystemDiscoveries
			.Skip((int)paginationParameters.Offset)
			.Take((int)paginationParameters.Limit)
			.Select(systemDiscovery => new SystemDiscoveryDTO
			{
				Id = systemDiscovery.Id,
				Name = systemDiscovery.Name,
				DiscoveryType = systemDiscovery.DiscoveryType,
				Coordinates = systemDiscovery.Coordinates,
				Galaxy = systemDiscovery.Galaxy,
				Platform = systemDiscovery.Platform.ToString(),
				Version = systemDiscovery.Version,
				Tags = systemDiscovery.Tags,
				Notes = systemDiscovery.Notes,
				DiscovererId = systemDiscovery.DiscovererId,
				SolarSystemId = systemDiscovery.SolarSystemId
			})
			.OrderBy(systemDiscovery => systemDiscovery.Id)
			.AsNoTracking()
			.ToListAsync();
	}

	[HttpGet("{systemDiscoveryId}")]
	public async Task<ActionResult<SystemDiscoveryDTO>> GetSystemDiscovery(ulong systemDiscoveryId)
	{
		var systemDiscovery = await _context.SystemDiscoveries.FindAsync(systemDiscoveryId);
		if (systemDiscovery == null)
		{
			return NotFound();
		}
		return SystemDiscoveryConverters.SystemDiscoveryToDTO(systemDiscovery);
	}

	[HttpPost]
	public async Task<ActionResult<SystemDiscovery>> PostSystemDiscovery(SystemDiscoveryModel systemDiscoveryModel)
	{
		var systemDiscovery = SystemDiscoveryConverters.SystemDiscoveryFromModel(systemDiscoveryModel);
		var system = await _context.SolarSystems.FindAsync(systemDiscovery.SolarSystemId);
		if (system != null)
		{
			systemDiscovery.Galaxy = system.Galaxy;
		}
		_context.SystemDiscoveries.Add(systemDiscovery);
		await _context.SaveChangesAsync();

		return CreatedAtAction(nameof(GetSystemDiscovery), new { id = systemDiscovery.Id }, systemDiscovery);
	}

	[HttpPut("{systemDiscoveryId}")]
	public async Task<IActionResult> PutSystemDiscovery(ulong systemDiscoveryId, SystemDiscoveryModel systemDiscoveryModel)
	{
		if (!SystemDiscoveryExists(systemDiscoveryId))
		{
			return NotFound();
		}

		var systemDiscovery = SystemDiscoveryConverters.SystemDiscoveryFromModel(systemDiscoveryModel);
		_context.Entry(systemDiscovery).State = EntityState.Modified;

		await _context.SaveChangesAsync();

		return Ok();
	}

	[HttpDelete("{systemDiscoveryId}")]
	public async Task<IActionResult> DeleteSystemDiscovery(ulong systemDiscoveryId)
	{
		var systemDiscovery = await _context.SystemDiscoveries.FindAsync(systemDiscoveryId);
		if (systemDiscovery == null)
		{
			return NotFound();
		}

		_context.SystemDiscoveries.Remove(systemDiscovery);
		await _context.SaveChangesAsync();

		return Ok();
	}

	private bool SystemDiscoveryExists(ulong id)
	{
		return _context.SystemDiscoveries.Any(systemDiscovery => systemDiscovery.Id == id);
	}
}