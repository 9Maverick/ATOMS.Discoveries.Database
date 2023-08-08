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
public class FaunaController : ControllerBase
{

	private readonly DiscoveriesContext _context;
	private readonly IMapper _mapper;

	public FaunaController(DiscoveriesContext context, IMapper mapper)
	{
		_context = context;
		_mapper = mapper;
	}

	[HttpGet]
	public async Task<ActionResult<IEnumerable<FaunaDTO>>> GetFauna([FromQuery] PaginationParameters paginationParameters)
	{
		return await _context.Fauna
			.Skip((int)paginationParameters.Offset)
			.Take((int)paginationParameters.Limit)
			.Select(fauna => new FaunaDTO
			{
				Id = fauna.Id,
				Name = fauna.Name,
				Coordinates = fauna.Coordinates,
				Galaxy = fauna.Galaxy,
				Platform = fauna.Platform.ToString(),
				Version = fauna.Version,
				Tags = fauna.Tags,
				Notes = fauna.Notes,
				DiscovererId = fauna.DiscovererId,
				SolarSystemId = fauna.SolarSystemId,
				PlanetId = fauna.PlanetId,
				Species = fauna.Species,
				TameProduct = fauna.TameProduct,
				Height = fauna.Height,
			})
			.OrderBy(fauna => fauna.Id)
			.AsNoTracking()
			.ToListAsync();
	}

	[HttpGet("{faunaId}")]
	public async Task<ActionResult<FaunaDTO>> GetFauna(ulong faunaId)
	{
		var fauna = await _context.Fauna.FindAsync(faunaId);
		if (fauna == null)
		{
			return NotFound();
		}
		return _mapper.Map<Fauna, FaunaDTO>(fauna);
	}

	[HttpPost]
	public async Task<ActionResult<Fauna>> PostFauna(FaunaModel faunaModel)
	{
		var fauna = _mapper.Map<FaunaModel, Fauna>(faunaModel);
		var planet = await _context.Planets.FindAsync(fauna.PlanetId);
		var system = await _context.SolarSystems.FindAsync(fauna.SolarSystemId);
		if (planet != null)
		{
			fauna.Galaxy = planet.Galaxy;
			fauna.Coordinates = planet.Coordinates;
			fauna.SolarSystemId = planet.SolarSystemId;
		}
		else if (system != null)
		{
			fauna.Galaxy = system.Galaxy;
		}
		_context.Fauna.Add(fauna);
		await _context.SaveChangesAsync();

		return CreatedAtAction(nameof(GetFauna), new { id = fauna.Id }, fauna);
	}

	[HttpPut("{faunaId}")]
	public async Task<IActionResult> PutFauna(ulong faunaId, FaunaModel faunaModel)
	{
		if (!FaunaExists(faunaId))
		{
			return NotFound();
		}

		var fauna = _mapper.Map<FaunaModel, Fauna>(faunaModel);
		_context.Entry(fauna).State = EntityState.Modified;

		await _context.SaveChangesAsync();

		return Ok();
	}

	[HttpDelete("{faunaId}")]
	public async Task<IActionResult> DeleteFauna(ulong faunaId)
	{
		var fauna = await _context.Fauna.FindAsync(faunaId);
		if (fauna == null)
		{
			return NotFound();
		}

		_context.Fauna.Remove(fauna);
		await _context.SaveChangesAsync();

		return Ok();
	}

	private bool FaunaExists(ulong id)
	{
		return _context.Fauna.Any(fauna => fauna.Id == id);
	}
}