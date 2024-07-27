
namespace WebAPI.Domain.Entities
{
	public class ComicResponseEntity
	{ 
		public string Code { get; set; }
		public string Status { get; set; }
		public string Copyright { get; set; }
		public string AttributionText { get; set; }
		public string AttributionHTML { get; set; }
		public string Etag { get; set; }
		public ComicDataEntity Data { get; set; }
	}

	public class ComicDataEntity
	{
		public string Offset { get; set; }
		public string Limit { get; set; }
		public string Total { get; set; }
		public string Count { get; set; }
		public List<ComicEntity> Results { get; set; }
	}

	public class ComicEntity
	{
		public string Id { get; set; }
		public string DigitalId { get; set; }
		public string Title { get; set; }
		public string IssueNumber { get; set; }
		public string VariantDescription { get; set; }
		public string Description { get; set; }
		public string Modified { get; set; }
		public string Isbn { get; set; }
		public string Upc { get; set; }
		public string DiamondCode { get; set; }
		public string Ean { get; set; }
		public string Issn { get; set; }
		public string Format { get; set; }
		public string PageCount { get; set; }
		public List<TextObjectEntity> TextObjects { get; set; }
		public string ResourceURI { get; set; }
		public List<UrlEntity> Urls { get; set; }
		public SeriesEntity Series { get; set; }
		public List<VariantEntity> Variants { get; set; }
		public List<CollectionEntity> Collections { get; set; }
		public List<CollectedIssueEntity> CollectedIssues { get; set; }
		public List<DateEntity> Dates { get; set; }
		public List<PriceEntity> Prices { get; set; }
		public ThumbnailEntity Thumbnail { get; set; }
		public List<ImageEntity> Images { get; set; }
		public CreatorsEntity Creators { get; set; }
		public CharactersEntity Characters { get; set; }
		public StoriesEntity Stories { get; set; }
		public EventsEntity Events { get; set; }
	}

	public class TextObjectEntity
	{
		public string Type { get; set; }
		public string Language { get; set; }
		public string Text { get; set; }
	}

	public class UrlEntity
	{

	}

	public class SeriesEntity
	{
		public string ResourceURI { get; set; }
		public string Name { get; set; }
	}

	public class VariantEntity
	{
		public string ResourceURI { get; set; }
		public string Name { get; set; }
	}

	public class CollectionEntity
	{
		public string ResourceURI { get; set; }
		public string Name { get; set; }
	}

	public class CollectedIssueEntity
	{
		public string ResourceURI { get; set; }
		public string Name { get; set; }
	}

	public class DateEntity
	{
		public string Type { get; set; }
		public string Dates { get; set; }
	}

	public class PriceEntity
	{
		public string Type { get; set; }
		public string Prices { get; set; }
	}

	public class ThumbnailEntity
	{
		public string Path { get; set; }
		public string Extension { get; set; }
	}

	public class ImageEntity
	{
		public string Path { get; set; }
		public string Extension { get; set; }
	}

	public class CreatorsEntity
	{
		public string Available { get; set; }
		public string CollectionURI { get; set; }
		public List<CreatorEntity> Items { get; set; }
	}

	public class CreatorEntity
	{
		public string ResourceURI { get; set; }
		public string Name { get; set; }
		public string Role { get; set; }
	}

	public class CharactersEntity
	{
		public string Available { get; set; }
		public string CollectionURI { get; set; }
		public List<CharacterEntity> Items { get; set; }
	}

	public class CharacterEntity
	{
		public string ResourceURI { get; set; }
		public string Name { get; set; }
	}

	public class StoriesEntity
	{
		public string Available { get; set; }
		public string CollectionURI { get; set; }
		public List<StoryEntity> Items { get; set; }
	}

	public class StoryEntity
	{
		public string ResourceURI { get; set; }
		public string Name { get; set; }
		public string Type { get; set; }
	}

	public class EventsEntity
	{
		public string Available { get; set; }
		public string CollectionURI { get; set; }
		public List<EventEntity> Items { get; set; }
	}

	public class EventEntity
	{
		public string ResourceURI { get; set; }
		public string Name { get; set; }
	}

}
