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
public class UsersController : ControllerBase
{

	private readonly DiscoveriesContext _context;
	private readonly IMapper _mapper;

	public UsersController(DiscoveriesContext context, IMapper mapper)
	{
		_context = context;
		_mapper = mapper;
	}

	[HttpGet]
	public async Task<ActionResult<IEnumerable<UserDTO>>> GetUsers([FromQuery] PaginationParameters paginationParameters)
	{
		return await _context.Users
			.Skip((int)paginationParameters.Offset)
			.Take((int)paginationParameters.Limit)
			.Select(user => new UserDTO
			{
				Id = user.Id,
				NickName = user.NickName
			})
			.OrderBy(user => user.Id)
			.AsNoTracking()
			.ToListAsync();
	}

	[HttpGet("{userId}")]
	public async Task<ActionResult<UserDTO>> GetUser(ulong userId)
	{
		var user = await _context.Users.FindAsync(userId);
		if (user == null)
		{
			return NotFound();
		}
		return _mapper.Map<User, UserDTO>(user);
	}

	[HttpPost]
	public async Task<ActionResult<User>> PostUser(UserModel userModel)
	{
		var user = new User(userModel.NickName);
		_context.Users.Add(user);
		await _context.SaveChangesAsync();

		return CreatedAtAction(nameof(GetUser), new { id = user.Id }, user);
	}

	[HttpPut("{userId}")]
	public async Task<IActionResult> PutUser(ulong userId, UserModel userModel)
	{
		if (!UserExists(userId))
		{
			return NotFound();
		}

		var user = new User(userId, userModel.NickName);
		_context.Entry(user).State = EntityState.Modified;

		await _context.SaveChangesAsync();

		return Ok();
	}

	[HttpDelete("{userId}")]
	public async Task<IActionResult> DeleteUser(ulong userId)
	{
		var user = await _context.Users.FindAsync(userId);
		if (user == null)
		{
			return NotFound();
		}


		_context.Users.Remove(user);
		await _context.SaveChangesAsync();

		return Ok();
	}

	[HttpGet("{userId}/Discoveries")]
	public async Task<ActionResult<IEnumerable<DiscoveryDTO>>> GetDiscoveries([FromQuery] PaginationParameters paginationParameters, ulong userId)
	{
		return await _context.Discoveries
			.Where(discovery => discovery.DiscovererId == userId)
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

	[HttpGet("{userId}/Discoveries/{discoveryId}")]
	public async Task<ActionResult<DiscoveryDTO>> GetDiscovery(ulong discoveryId, ulong userId)
	{
		var discovery = await _context.Discoveries
			.Where(discovery =>
				discovery.DiscovererId == userId && discovery.Id == discoveryId
			)
			.FirstOrDefaultAsync();
		if (discovery == null)
		{
			return NotFound();
		}
		return _mapper.Map<Discovery, DiscoveryDTO>(discovery);
	}

	[HttpPost("{userId}/Discoveries")]
	public async Task<ActionResult<Discovery>> PostDiscovery(DiscoveryModel discoveryModel, ulong userId)
	{
		var discovery = _mapper.Map<DiscoveryModel, Discovery>(discoveryModel);
		discovery.DiscovererId = userId;
		_context.Discoveries.Add(discovery);

		await _context.SaveChangesAsync();

		return CreatedAtAction(nameof(GetDiscovery), new { id = discovery.Id }, discovery);
	}

	[HttpPut("{userId}/Discoveries/{discoveryId}")]
	public async Task<IActionResult> PutDiscovery(ulong discoveryId, DiscoveryModel discoveryModel, ulong userId)
	{
		if (!DiscoveryExists(discoveryId))
		{
			return NotFound();
		}

		var discovery = _mapper.Map<DiscoveryModel, Discovery>(discoveryModel);
		discovery.Id = discoveryId;
		_context.Entry(discovery).State = EntityState.Modified;

		await _context.SaveChangesAsync();

		return Ok();
	}

	[HttpDelete("{userId}/Discoveries/{discoveryId}")]
	public async Task<IActionResult> DeleteDiscovery(ulong discoveryId, ulong userId)
	{
		var discovery = await _context.Discoveries
			.Where(discovery =>
				discovery.DiscovererId == userId && discovery.Id == discoveryId
			)
			.FirstOrDefaultAsync();
		if (discovery == null)
		{
			return NotFound();
		}

		_context.Discoveries.Remove(discovery);
		await _context.SaveChangesAsync();

		return Ok();
	}

	private bool UserExists(ulong id)
	{
		return _context.Users.Any(user => user.Id == id);
	}
	private bool DiscoveryExists(ulong id)
	{
		return _context.Discoveries.Any(discovery => discovery.Id == id);
	}
}