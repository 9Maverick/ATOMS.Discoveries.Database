using Atoms.Discoveries.Database.API.Data.DTO;
using Atoms.Discoveries.Database.API.Data.Models;
using Atoms.Discoveries.Database.Domain;
using Atoms.Discoveries.Database.Domain.Enums;
using AutoMapper;

namespace Atoms.Discoveries.Database.API.Data.Helpers;

public class AutoMappingProfiles : Profile
{
	public AutoMappingProfiles()
	{
		CreateUserMap();

		CreateImageMap();

		CreateDiscoveryMap();

		CreateSolarSystemMap();

		CreateSystemDiscoveryMap();

		CreateFreighterMap();

		CreateFrigateMap();

		CreatePlanetMap();

		CreatePlanetDiscoveryMap();

		CreateFaunaMap();

		CreateShipMap();

		CreateMultiToolMap();
	}

	private void CreateUserMap()
	{
		CreateMap<User, UserDTO>().ReverseMap();
	}

	private void CreateImageMap()
	{
		CreateMap<Image, ImageDTO>().ReverseMap();
	}

	private void CreateDiscoveryMap()
	{
		CreateMap<Discovery, DiscoveryDTO>()
		.ForMember
		(
			dest => dest.Platform,
			opt => opt.MapFrom(src => src.Platform.ToString())
		)
		.ReverseMap();

		CreateMap<DiscoveryModel, Discovery>()
		.ForMember
		(
			dest => dest.Platform,
			opt => opt.MapFrom(src => Enum.Parse<Platform>(src.Platform))
		)
		.ReverseMap();
	}

	private void CreateSolarSystemMap()
	{
		CreateMap<SolarSystem, SolarSystemDTO>()
		.ForMember
		(
			dest => dest.Platform,
			opt => opt.MapFrom(src => src.Platform.ToString())
		)
		.ForMember
		(
			dest => dest.DominantLifeform,
			opt => opt.MapFrom(src => src.DominantLifeform.ToString())
		)
		.ForMember
		(
			dest => dest.Economy,
			opt => opt.MapFrom(src => src.Economy.ToString())
		)
		.ReverseMap();

		CreateMap<SolarSystemModel, SolarSystem>()
		.ForMember
		(
			dest => dest.Platform,
			opt => opt.MapFrom(src => Enum.Parse<Platform>(src.Platform))
		)
		.ForMember
		(
			dest => dest.DominantLifeform,
			opt => opt.MapFrom(src => Enum.Parse<Lifeform>(src.DominantLifeform))
		)
		.ForMember
		(
			dest => dest.Economy,
			opt => opt.MapFrom(src => Enum.Parse<Economy>(src.Economy))
		)
		.ReverseMap();
	}

	private void CreateSystemDiscoveryMap()
	{
		CreateMap<SystemDiscovery, SystemDiscoveryDTO>()
		.ForMember
		(
			dest => dest.Platform,
			opt => opt.MapFrom(src => src.Platform.ToString())
		)
		.ReverseMap();

		CreateMap<SystemDiscoveryModel, SystemDiscovery>()
		.ForMember
		(
			dest => dest.Platform,
			opt => opt.MapFrom(src => Enum.Parse<Platform>(src.Platform))
		)
		.ReverseMap();
	}

	private void CreateFreighterMap()
	{
		CreateMap<Freighter, FreighterDTO>()
		.ForMember
		(
			dest => dest.Platform,
			opt => opt.MapFrom(src => src.Platform.ToString())
		)
		.ReverseMap();

		CreateMap<FreighterModel, Freighter>()
		.ForMember
		(
			dest => dest.Platform,
			opt => opt.MapFrom(src => Enum.Parse<Platform>(src.Platform))
		)
		.ReverseMap();
	}

	private void CreateFrigateMap()
	{
		CreateMap<Frigate, FrigateDTO>()
		.ForMember
		(
			dest => dest.Platform,
			opt => opt.MapFrom(src => src.Platform.ToString())
		)
		.ReverseMap();

		CreateMap<FrigateModel, Frigate>()
		.ForMember
		(
			dest => dest.Platform,
			opt => opt.MapFrom(src => Enum.Parse<Platform>(src.Platform))
		)
		.ReverseMap();
	}

	private void CreatePlanetMap()
	{
		CreateMap<Planet, PlanetDTO>()
		.ForMember
		(
			dest => dest.Platform,
			opt => opt.MapFrom(src => src.Platform.ToString())
		)
		.ForMember
		(
			dest => dest.SentinelsActivity,
			opt => opt.MapFrom(src => src.SentinelsActivity.ToString())
		)
		.ReverseMap();

		CreateMap<PlanetModel, Planet>()
		.ForMember
		(
			dest => dest.SentinelsActivity,
			opt => opt.MapFrom(src => Enum.Parse<Sentinels>(src.SentinelsActivity))
		)
		.ReverseMap();
	}

	private void CreatePlanetDiscoveryMap()
	{
		CreateMap<PlanetDiscovery, PlanetDiscoveryDTO>()
		.ForMember
		(
			dest => dest.Platform,
			opt => opt.MapFrom(src => src.Platform.ToString())
		)
		.ReverseMap();

		CreateMap<PlanetDiscoveryModel, PlanetDiscovery>()
		.ForMember
		(
			dest => dest.Platform,
			opt => opt.MapFrom(src => Enum.Parse<Platform>(src.Platform))
		)
		.ReverseMap();
	}

	private void CreateFaunaMap()
	{
		CreateMap<Fauna, FaunaDTO>()
		.ForMember
		(
			dest => dest.Platform,
			opt => opt.MapFrom(src => src.Platform.ToString())
		)
		.ReverseMap();

		CreateMap<FaunaModel, Fauna>()
		.ForMember
		(
			dest => dest.Platform,
			opt => opt.MapFrom(src => Enum.Parse<Platform>(src.Platform))
		)
		.ReverseMap();
	}

	private void CreateShipMap()
	{
		CreateMap<Ship, ShipDTO>()
		.ForMember
		(
			dest => dest.Platform,
			opt => opt.MapFrom(src => src.Platform.ToString())
		)
		.ForMember
		(
			dest => dest.Class,
			opt => opt.MapFrom(src => src.Class.ToString())
		)
		.ReverseMap();

		CreateMap<ShipModel, Ship>()
		.ForMember
		(
			dest => dest.Class,
			opt => opt.MapFrom(src => Enum.Parse<Class>(src.Class))
		)
		.ReverseMap();
	}

	private void CreateMultiToolMap()
	{
		CreateMap<MultiTool, MultiToolDTO>()
		.ForMember
		(
			dest => dest.Platform,
			opt => opt.MapFrom(src => src.Platform.ToString())
		)
		.ForMember
		(
			dest => dest.Class,
			opt => opt.MapFrom(src => src.Class.ToString())
		)
		.ReverseMap();

		CreateMap<MultiToolModel, MultiTool>()
		.ForMember
		(
			dest => dest.Class,
			opt => opt.MapFrom(src => Enum.Parse<Class>(src.Class))
		)
		.ReverseMap();
	}
}
