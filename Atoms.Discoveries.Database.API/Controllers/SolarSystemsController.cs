using Atoms.Discoveries.Database.API.Data.DTO;
using Atoms.Discoveries.Database.API.Data.Models;
using Atoms.Discoveries.Database.Data;
using Atoms.Discoveries.Database.Domain;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Atoms.Discoveries.Database.Controllers;

[ApiController]
[Route("/api/[controller]")]
public class SolarSystemsController : ControllerBase
{

	private readonly DiscoveriesContext _context;
	private readonly IMapper _mapper;
	public SolarSystemsController(DiscoveriesContext context, IMapper mapper)
	{
		_context = context;
		_mapper = mapper;
	}

	[HttpGet]
	public async Task<ActionResult<IEnumerable<SolarSystemDTO>>> GetSolarSystems([FromQuery] PaginationParameters paginationParameters)
	{
		return await _context.SolarSystems
			.Skip((int)paginationParameters.Offset)
			.Take((int)paginationParameters.Limit)
			.Select(solarSystem => new SolarSystemDTO
			{
				Id = solarSystem.Id,
				Name = solarSystem.Name,
				DiscoveryType = solarSystem.DiscoveryType,
				Coordinates = solarSystem.Coordinates,
				Galaxy = solarSystem.Galaxy,
				Platform = solarSystem.Platform.ToString(),
				Version = solarSystem.Version,
				Tags = solarSystem.Tags,
				Notes = solarSystem.Notes,
				DiscovererId = solarSystem.DiscovererId,
				DominantLifeform = solarSystem.DominantLifeform.ToString(),
				Economy = solarSystem.Economy.ToString()
			})
			.OrderBy(solarSystem => solarSystem.Id)
			.AsNoTracking()
			.ToListAsync();
	}

	[HttpGet("{solarSystemId}")]
	public async Task<ActionResult<SolarSystemDTO>> GetSolarSystem(ulong solarSystemId)
	{
		var solarSystem = await _context.SolarSystems.FindAsync(solarSystemId);
		if (solarSystem == null)
		{
			return NotFound();
		}
		return _mapper.Map<SolarSystem, SolarSystemDTO>(solarSystem);
	}

	[HttpPost]
	public async Task<ActionResult<SolarSystem>> PostSolarSystem(SolarSystemModel solarSystemModel)
	{
		var solarSystem = _mapper.Map<SolarSystemModel, SolarSystem>(solarSystemModel);
		_context.SolarSystems.Add(solarSystem);
		await _context.SaveChangesAsync();

		return CreatedAtAction(nameof(GetSolarSystem), new { id = solarSystem.Id }, solarSystem);
	}

	[HttpPut("{solarSystemId}")]
	public async Task<IActionResult> PutSolarSystem(ulong solarSystemId, SolarSystemModel solarSystemModel)
	{
		if (!SolarSystemExists(solarSystemId))
		{
			return NotFound();
		}

		var solarSystem = _mapper.Map<SolarSystemModel, SolarSystem>(solarSystemModel);
		_context.Entry(solarSystem).State = EntityState.Modified;

		await _context.SaveChangesAsync();

		return Ok();
	}

	[HttpDelete("{solarSystemId}")]
	public async Task<IActionResult> DeleteSolarSystem(ulong solarSystemId)
	{
		var solarSystem = await _context.SolarSystems.FindAsync(solarSystemId);
		if (solarSystem == null)
		{
			return NotFound();
		}

		_context.SolarSystems.Remove(solarSystem);
		await _context.SaveChangesAsync();

		return Ok();
	}

	[HttpGet("{solarSystemId}/SystemDiscoveries")]
	public async Task<ActionResult<IEnumerable<SystemDiscoveryDTO>>> GetSystemDiscoveries([FromQuery] PaginationParameters paginationParameters, ulong solarSystemId)
	{
		return await _context.SystemDiscoveries
			.Where(systemDiscovery => systemDiscovery.SolarSystemId == solarSystemId)
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

	[HttpGet("{solarSystemId}/SystemDiscoveries/{systemDiscoveryId}")]
	public async Task<ActionResult<SystemDiscoveryDTO>> GetSystemDiscovery(ulong systemDiscoveryId, ulong solarSystemId)
	{
		var systemDiscovery = await _context.SystemDiscoveries
			.Where(systemDiscovery =>
				systemDiscovery.SolarSystemId == solarSystemId && systemDiscovery.Id == systemDiscoveryId
			)
			.FirstOrDefaultAsync();
		if (systemDiscovery == null)
		{
			return NotFound();
		}
		return _mapper.Map<SystemDiscovery, SystemDiscoveryDTO>(systemDiscovery);
	}

	[HttpPost("{solarSystemId}/SystemDiscoveries")]
	public async Task<ActionResult<SystemDiscovery>> PostSystemDiscovery(SystemDiscoveryModel systemDiscoveryModel, ulong solarSystemId)
	{
		var systemDiscovery = _mapper.Map<SystemDiscoveryModel, SystemDiscovery>(systemDiscoveryModel);
		systemDiscovery.SolarSystemId = solarSystemId;
		var system = await _context.SolarSystems.FindAsync(systemDiscovery.SolarSystemId);
		if (system != null)
		{
			systemDiscovery.Galaxy = system.Galaxy;
		}
		_context.SystemDiscoveries.Add(systemDiscovery);
		await _context.SaveChangesAsync();

		return CreatedAtAction(nameof(GetSystemDiscovery), new { id = systemDiscovery.Id }, systemDiscovery);
	}

	[HttpPut("{solarSystemId}/SystemDiscoveries/{systemDiscoveryId}")]
	public async Task<IActionResult> PutSystemDiscovery(ulong systemDiscoveryId, SystemDiscoveryModel systemDiscoveryModel, ulong solarSystemId)
	{
		if (!SystemDiscoveryExists(systemDiscoveryId))
		{
			return NotFound();
		}

		var systemDiscovery = _mapper.Map<SystemDiscoveryModel, SystemDiscovery>(systemDiscoveryModel);
		_context.Entry(systemDiscovery).State = EntityState.Modified;

		await _context.SaveChangesAsync();

		return Ok();
	}

	[HttpDelete("{solarSystemId}/SystemDiscoveries/{systemDiscoveryId}")]
	public async Task<IActionResult> DeleteSystemDiscovery(ulong systemDiscoveryId, ulong solarSystemId)
	{
		var systemDiscovery = await _context.SystemDiscoveries
			.Where(systemDiscovery =>
				systemDiscovery.SolarSystemId == solarSystemId && systemDiscovery.Id == systemDiscoveryId
			)
			.FirstOrDefaultAsync();
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

	private bool SolarSystemExists(ulong id)
	{
		return _context.SolarSystems.Any(solarSystem => solarSystem.Id == id);
	}
}