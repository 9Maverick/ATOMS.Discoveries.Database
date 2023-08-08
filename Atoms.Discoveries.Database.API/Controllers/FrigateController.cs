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
public class FrigatesController : ControllerBase
{

	private readonly DiscoveriesContext _context;
	private readonly IMapper _mapper;

	public FrigatesController(DiscoveriesContext context, IMapper mapper)
	{
		_context = context;
		_mapper = mapper;
	}

	[HttpGet]
	public async Task<ActionResult<IEnumerable<FrigateDTO>>> GetFrigates([FromQuery] PaginationParameters paginationParameters)
	{
		return await _context.Frigates
			.Skip((int)paginationParameters.Offset)
			.Take((int)paginationParameters.Limit)
			.Select(frigate => new FrigateDTO
			{
				Id = frigate.Id,
				Name = frigate.Name,
				Coordinates = frigate.Coordinates,
				Galaxy = frigate.Galaxy,
				Platform = frigate.Platform.ToString(),
				Version = frigate.Version,
				Tags = frigate.Tags,
				Notes = frigate.Notes,
				DiscovererId = frigate.DiscovererId,
				SolarSystemId = frigate.SolarSystemId,
				Type = frigate.Type,
				Colors = frigate.Colors,
			})
			.OrderBy(frigate => frigate.Id)
			.AsNoTracking()
			.ToListAsync();
	}

	[HttpGet("{frigateId}")]
	public async Task<ActionResult<FrigateDTO>> GetFrigate(ulong frigateId)
	{
		var frigate = await _context.Frigates.FindAsync(frigateId);
		if (frigate == null)
		{
			return NotFound();
		}
		return _mapper.Map<Frigate, FrigateDTO>(frigate);
	}

	[HttpPost]
	public async Task<ActionResult<Frigate>> PostFrigate(FrigateModel frigateModel)
	{
		var frigate = _mapper.Map<FrigateModel, Frigate>(frigateModel);
		var system = await _context.SolarSystems.FindAsync(frigateModel.SolarSystemId);
		if (frigate != null)
		{
			frigate.Galaxy = system.Galaxy;
		}
		_context.Frigates.Add(frigate);
		await _context.SaveChangesAsync();

		return CreatedAtAction(nameof(GetFrigate), new { id = frigate.Id }, frigate);
	}

	[HttpPut("{frigateId}")]
	public async Task<IActionResult> PutFrigate(ulong frigateId, FrigateModel frigateModel)
	{
		if (!FrigateExists(frigateId))
		{
			return NotFound();
		}

		var frigate = _mapper.Map<FrigateModel, Frigate>(frigateModel);
		_context.Entry(frigate).State = EntityState.Modified;

		await _context.SaveChangesAsync();

		return Ok();
	}

	[HttpDelete("{frigateId}")]
	public async Task<IActionResult> DeleteFrigate(ulong frigateId)
	{
		var frigate = await _context.Frigates.FindAsync(frigateId);
		if (frigate == null)
		{
			return NotFound();
		}

		_context.Frigates.Remove(frigate);
		await _context.SaveChangesAsync();

		return Ok();
	}

	private bool FrigateExists(ulong id)
	{
		return _context.Frigates.Any(frigate => frigate.Id == id);
	}
}