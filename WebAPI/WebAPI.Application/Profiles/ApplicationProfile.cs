using AutoMapper;
using WebAPI.Application.DTO;
using WebAPI.Application.Models;
using WebAPI.Domain.Entities;

namespace WebAPI.Application.Profiles
{
	public class ApplicationProfile : Profile
	{
		public ApplicationProfile()
		{
			CreateMap<UsersDTO, UsersEntity>().ReverseMap();
			CreateMap<FavoriteDTO, FavoriteEntity>().ReverseMap();

			CreateMap<UsersRequest, UsersEntity>().ReverseMap();
			CreateMap<FavoriteRequest, FavoriteEntity>().ReverseMap();

			CreateMap<ComicResponseDTO, ComicResponseEntity>().ReverseMap();
			CreateMap<ComicDataDTO, ComicDataEntity>().ReverseMap();
			CreateMap<ComicDTO, ComicEntity>().ReverseMap();
			CreateMap<TextObjectDTO, TextObjectEntity>().ReverseMap();
			CreateMap<UrlDTO, UrlEntity>().ReverseMap();
			CreateMap<SeriesDTO, SeriesEntity>().ReverseMap();
			CreateMap<VariantDTO, VariantEntity>().ReverseMap();
			CreateMap<CollectionDTO, CollectionEntity>().ReverseMap();
			CreateMap<CollectedIssueDTO, CollectedIssueEntity>().ReverseMap();
			CreateMap<DateDTO, DateEntity>().ReverseMap();
			CreateMap<PriceDTO, PriceEntity>().ReverseMap();
			CreateMap<ThumbnailDTO, ThumbnailEntity>().ReverseMap();
			CreateMap<ImageDTO, ImageEntity>().ReverseMap();
			CreateMap<CreatorsDTO, CreatorsEntity>().ReverseMap();
			CreateMap<CreatorDTO, CreatorEntity>().ReverseMap();
			CreateMap<CharactersDTO, CharactersEntity>().ReverseMap();
			CreateMap<CharacterDTO, CharacterEntity>().ReverseMap();
			CreateMap<StoriesDTO, StoriesEntity>().ReverseMap();
			CreateMap<StoryDTO, StoryEntity>().ReverseMap();
			CreateMap<EventsDTO, EventsEntity>().ReverseMap();
			CreateMap<EventDTO, EventEntity>().ReverseMap();
		}
	}
}
