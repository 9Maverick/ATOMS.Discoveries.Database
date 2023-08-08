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
public class FreightersController : ControllerBase
{

	private readonly DiscoveriesContext _context;
	private readonly IMapper _mapper;

	public FreightersController(DiscoveriesContext context, IMapper mapper)
	{
		_context = context;
		_mapper = mapper;
	}

	[HttpGet]
	public async Task<ActionResult<IEnumerable<FreighterDTO>>> GetFreighters([FromQuery] PaginationParameters paginationParameters)
	{
		return await _context.Freighters
			.Skip((int)paginationParameters.Offset)
			.Take((int)paginationParameters.Limit)
			.Select(freighter => new FreighterDTO
			{
				Id = freighter.Id,
				Name = freighter.Name,
				Coordinates = freighter.Coordinates,
				Galaxy = freighter.Galaxy,
				Platform = freighter.Platform.ToString(),
				Version = freighter.Version,
				Tags = freighter.Tags,
				Notes = freighter.Notes,
				DiscovererId = freighter.DiscovererId,
				SolarSystemId = freighter.SolarSystemId,
				Type = freighter.Type,
				Slots = freighter.Slots,
				Colors = freighter.Colors,
			})
			.OrderBy(freighter => freighter.Id)
			.AsNoTracking()
			.ToListAsync();
	}

	[HttpGet("{freighterId}")]
	public async Task<ActionResult<FreighterDTO>> GetFreighter(ulong freighterId)
	{
		var freighter = await _context.Freighters.FindAsync(freighterId);
		if (freighter == null)
		{
			return NotFound();
		}
		return _mapper.Map<Freighter, FreighterDTO>(freighter);
	}

	[HttpPost]
	public async Task<ActionResult<Freighter>> PostFreighter(FreighterModel freighterModel)
	{
		var freighter = _mapper.Map<FreighterModel, Freighter>(freighterModel);
		var system = await _context.SolarSystems.FindAsync(freighterModel.SolarSystemId);
		if (freighter != null)
		{
			freighter.Galaxy = system.Galaxy;
		}
		_context.Freighters.Add(freighter);
		await _context.SaveChangesAsync();

		return CreatedAtAction(nameof(GetFreighter), new { id = freighter.Id }, freighter);
	}

	[HttpPut("{freighterId}")]
	public async Task<IActionResult> PutFreighter(ulong freighterId, FreighterModel freighterModel)
	{
		if (!FreighterExists(freighterId))
		{
			return NotFound();
		}

		var freighter = _mapper.Map<FreighterModel, Freighter>(freighterModel);
		_context.Entry(freighter).State = EntityState.Modified;

		await _context.SaveChangesAsync();

		return Ok();
	}

	[HttpDelete("{freighterId}")]
	public async Task<IActionResult> DeleteFreighter(ulong freighterId)
	{
		var freighter = await _context.Freighters.FindAsync(freighterId);
		if (freighter == null)
		{
			return NotFound();
		}

		_context.Freighters.Remove(freighter);
		await _context.SaveChangesAsync();

		return Ok();
	}

	private bool FreighterExists(ulong id)
	{
		return _context.Freighters.Any(freighter => freighter.Id == id);
	}
}