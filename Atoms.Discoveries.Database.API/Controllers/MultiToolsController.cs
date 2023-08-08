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
public class MultiToolsController : ControllerBase
{

	private readonly DiscoveriesContext _context;
	private readonly IMapper _mapper;

	public MultiToolsController(DiscoveriesContext context, IMapper mapper)
	{
		_context = context;
		_mapper = mapper;
	}

	[HttpGet]
	public async Task<ActionResult<IEnumerable<MultiToolDTO>>> GetMultiTools([FromQuery] PaginationParameters paginationParameters)
	{
		return await _context.MultiTools
			.Skip((int)paginationParameters.Offset)
			.Take((int)paginationParameters.Limit)
			.Select(multiTool => new MultiToolDTO
			{
				Id = multiTool.Id,
				Name = multiTool.Name,
				DiscoveryType = multiTool.DiscoveryType,
				Coordinates = multiTool.Coordinates,
				Galaxy = multiTool.Galaxy,
				Platform = multiTool.Platform.ToString(),
				Version = multiTool.Version,
				Tags = multiTool.Tags,
				Notes = multiTool.Notes,
				DiscovererId = multiTool.DiscovererId,
				SolarSystemId = multiTool.SolarSystemId,
				PlanetId = multiTool.PlanetId,
				Type = multiTool.Type,
				Size = multiTool.Size,
				Colors = multiTool.Colors,
				Class = multiTool.Class.ToString(),
			})
			.OrderBy(multiTool => multiTool.Id)
			.AsNoTracking()
			.ToListAsync();
	}

	[HttpGet("{multiToolId}")]
	public async Task<ActionResult<MultiToolDTO>> GetMultiTool(ulong multiToolId)
	{
		var multiTool = await _context.MultiTools.FindAsync(multiToolId);
		if (multiTool == null)
		{
			return NotFound();
		}
		return _mapper.Map<MultiTool, MultiToolDTO>(multiTool);
	}

	[HttpPost]
	public async Task<ActionResult<MultiTool>> PostMultiTool(MultiToolModel multiToolModel)
	{
		var multiTool = _mapper.Map<MultiToolModel, MultiTool>(multiToolModel);
		var planet = await _context.Planets.FindAsync(multiTool.PlanetId);
		var system = await _context.SolarSystems.FindAsync(multiTool.SolarSystemId);
		if (planet != null)
		{
			multiTool.Galaxy = planet.Galaxy;
			multiTool.Coordinates = planet.Coordinates;
			multiTool.SolarSystemId = planet.SolarSystemId;
		}
		else if (system != null)
		{
			multiTool.Galaxy = system.Galaxy;
		}
		_context.MultiTools.Add(multiTool);
		await _context.SaveChangesAsync();

		return CreatedAtAction(nameof(GetMultiTool), new { id = multiTool.Id }, multiTool);
	}

	[HttpPut("{multiToolId}")]
	public async Task<IActionResult> PutMultiTool(ulong multiToolId, MultiToolModel multiToolModel)
	{
		if (!MultiToolExists(multiToolId))
		{
			return NotFound();
		}

		var multiTool = _mapper.Map<MultiToolModel, MultiTool>(multiToolModel);
		_context.Entry(multiTool).State = EntityState.Modified;

		await _context.SaveChangesAsync();

		return Ok();
	}

	[HttpDelete("{multiToolId}")]
	public async Task<IActionResult> DeleteMultiTool(ulong multiToolId)
	{
		var multiTool = await _context.MultiTools.FindAsync(multiToolId);
		if (multiTool == null)
		{
			return NotFound();
		}

		_context.MultiTools.Remove(multiTool);
		await _context.SaveChangesAsync();

		return Ok();
	}

	private bool MultiToolExists(ulong id)
	{
		return _context.MultiTools.Any(multiTool => multiTool.Id == id);
	}
}