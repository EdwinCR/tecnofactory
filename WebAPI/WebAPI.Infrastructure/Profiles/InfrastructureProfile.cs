using AutoMapper;
using WebAPI.Domain.Entities;
using WebAPI.Infrastructure.Models;

namespace WebAPI.Infrastructure.Profiles
{
	public class InfrastructureProfile : Profile
	{
		public InfrastructureProfile()
		{ 
			CreateMap<UsersModel, UsersEntity>().ReverseMap();
			CreateMap<FavoriteModel, FavoriteEntity>().ReverseMap();

			CreateMap<ComicResponseModel, ComicResponseEntity>().ReverseMap();
			CreateMap<ComicDataModel, ComicDataEntity>().ReverseMap();
			CreateMap<ComicModel, ComicEntity>().ReverseMap();
			CreateMap<TextObjectModel, TextObjectEntity>().ReverseMap();
			CreateMap<UrlModel, UrlEntity>().ReverseMap();
			CreateMap<SeriesModel, SeriesEntity>().ReverseMap();
			CreateMap<VariantModel, VariantEntity>().ReverseMap();
			CreateMap<CollectionModel, CollectionEntity>().ReverseMap();
			CreateMap<CollectedIssueModel, CollectedIssueEntity>().ReverseMap();
			CreateMap<DateModel, DateEntity>().ReverseMap();
			CreateMap<PriceModel, PriceEntity>().ReverseMap();
			CreateMap<ThumbnailModel, ThumbnailEntity>().ReverseMap();
			CreateMap<ImageModel, ImageEntity>().ReverseMap();
			CreateMap<CreatorsModel, CreatorsEntity>().ReverseMap();
			CreateMap<CreatorModel, CreatorEntity>().ReverseMap();
			CreateMap<CharactersModel, CharactersEntity>().ReverseMap();
			CreateMap<CharacterModel, CharacterEntity>().ReverseMap();
			CreateMap<StoriesModel, StoriesEntity>().ReverseMap();
			CreateMap<StoryModel, StoryEntity>().ReverseMap();
			CreateMap<EventsModel, EventsEntity>().ReverseMap();
			CreateMap<EventModel, EventEntity>().ReverseMap();
		}
	}
}
