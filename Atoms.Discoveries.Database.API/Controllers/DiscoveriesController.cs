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
public class DiscoveriesController : ControllerBase
{

	private readonly DiscoveriesContext _context;

	public DiscoveriesController(DiscoveriesContext context)
	{
		_context = context;
	}

	[HttpGet]
	public async Task<ActionResult<IEnumerable<DiscoveryDTO>>> GetDiscoveries([FromQuery] PaginationParameters paginationParameters)
	{
		return await _context.Discoveries
			.Skip((int)paginationParameters.Offset)
			.Take((int)paginationParameters.Limit)
			.Select(discovery => new DiscoveryDTO
			{
				Id = discovery.Id,
				Name = discovery.Name,
				DiscoveryType = discovery.DiscoveryType,
				Coordinates = discovery.Coordinates,
				Galaxy = discovery.Galaxy,
				Platform = discovery.Platform.ToString(),
				Version = discovery.Version,
				Tags = discovery.Tags,
				Notes = discovery.Notes,
				DiscovererId = discovery.DiscovererId
			})
			.OrderBy(discovery => discovery.Id)
			.AsNoTracking()
			.ToListAsync();
	}

	[HttpGet("{discoveryId}")]
	public async Task<ActionResult<DiscoveryDTO>> GetDiscovery(ulong discoveryId)
	{
		var discovery = await _context.Discoveries.FindAsync(discoveryId);
		if (discovery == null)
		{
			return NotFound();
		}
		return DiscoveryConverters.DiscoveryToDTO(discovery);
	}

	[HttpPost]
	public async Task<ActionResult<Discovery>> PostDiscovery(DiscoveryModel discoveryModel)
	{
		var discovery = DiscoveryConverters.DiscoveryFromModel(discoveryModel);
		_context.Discoveries.Add(discovery);

		await _context.SaveChangesAsync();

		return CreatedAtAction(nameof(GetDiscovery), new { id = discovery.Id }, discovery);
	}

	[HttpPut("{discoveryId}")]
	public async Task<IActionResult> PutDiscovery(ulong discoveryId, DiscoveryModel discoveryModel)
	{
		if (!DiscoveryExists(discoveryId))
		{
			return NotFound();
		}

		var discovery = DiscoveryConverters.DiscoveryFromModel(discoveryModel);
		discovery.Id = discoveryId;
		_context.Entry(discovery).State = EntityState.Modified;

		await _context.SaveChangesAsync();

		return Ok();
	}

	[HttpDelete("{discoveryId}")]
	public async Task<IActionResult> DeleteDiscovery(ulong discoveryId)
	{
		var discovery = await _context.Discoveries.FindAsync(discoveryId);
		if (discovery == null)
		{
			return NotFound();
		}

		_context.Discoveries.Remove(discovery);
		await _context.SaveChangesAsync();

		return Ok();
	}

	[HttpGet("{discoveryId}/Images")]
	public async Task<ActionResult<IEnumerable<ImageDTO>>> GetImages([FromQuery] PaginationParameters paginationParameters, ulong discoveryId)
	{
		return await _context.Images
			.Where(image => image.DiscoveryId == discoveryId)
			.Skip((int)paginationParameters.Offset)
			.Take((int)paginationParameters.Limit)
			.Select(image => new ImageDTO
			{
				Id = image.Id,
				Data = image.Data,
				Description = image.Description,
				DiscoveryId = image.DiscoveryId
			})
			.OrderBy(image => image.Id)
			.AsNoTracking()
			.ToListAsync();
	}

	[HttpGet("{discoveryId}/Images/{imageId}")]
	public async Task<ActionResult<ImageDTO>> GetImage(ulong imageId, ulong discoveryId)
	{
		var image = await _context.Images
			.Where(image =>
				image.DiscoveryId == discoveryId && image.Id == imageId
			)
			.FirstOrDefaultAsync();
		if (image == null)
		{
			return NotFound();
		}
		return ImageConverters.ImageToDTO(image);
	}

	[HttpPost("{discoveryId}/Images")]
	public async Task<ActionResult<Image>> PostImage(ImagePostModel imageModel, ulong discoveryId)
	{
		var image = new Image(0, imageModel.Data, discoveryId);
		_context.Images.Add(image);
		await _context.SaveChangesAsync();

		return CreatedAtAction(nameof(GetImage), new { id = image.Id }, image);
	}

	[HttpPut("{discoveryId}/Images/{imageId}")]
	public async Task<IActionResult> PutImage(ulong imageId, ImagePutModel imageModel, ulong discoveryId)
	{
		if (!ImageExists(imageId))
		{
			return NotFound();
		}

		var image = new Image(imageId, imageModel.Data, imageModel.DiscoveryId);
		_context.Images.Entry(image).State = EntityState.Modified;

		await _context.SaveChangesAsync();

		return Ok();
	}

	[HttpDelete("{discoveryId}/Images/{imageId}")]
	public async Task<IActionResult> DeleteImage(ulong imageId, ulong discoveryId)
	{
		var image = await _context.Images
			.Where(image =>
				image.DiscoveryId == discoveryId && image.Id == imageId
			)
			.FirstOrDefaultAsync();

		if (image == null)
		{
			return NotFound();
		}

		_context.Images.Remove(image);
		await _context.SaveChangesAsync();

		return Ok();
	}

	private bool DiscoveryExists(ulong id)
	{
		return _context.Discoveries.Any(discovery => discovery.Id == id);
	}

	private bool ImageExists(ulong id)
	{
		return _context.Images.Any(image => image.Id == id);
	}
}