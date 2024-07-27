
namespace WebAPI.Application.DTO
{
	public class ComicResponseDTO
	{
		public string Code { get; set; }
		public string Status { get; set; }
		public string Copyright { get; set; }
		public string AttributionText { get; set; }
		public string AttributionHTML { get; set; }
		public string Etag { get; set; }
		public ComicDataDTO Data { get; set; }
	}

	public class ComicDataDTO
	{
		public string Offset { get; set; }
		public string Limit { get; set; }
		public string Total { get; set; }
		public string Count { get; set; }
		public List<ComicDTO> Results { get; set; }
	}

	public class ComicDTO
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
		public List<TextObjectDTO> TextObjects { get; set; }
		public string ResourceURI { get; set; }
		public List<UrlDTO> Urls { get; set; }
		public SeriesDTO Series { get; set; }
		public List<VariantDTO> Variants { get; set; }
		public List<CollectionDTO> Collections { get; set; }
		public List<CollectedIssueDTO> CollectedIssues { get; set; }
		public List<DateDTO> Dates { get; set; }
		public List<PriceDTO> Prices { get; set; }
		public ThumbnailDTO Thumbnail { get; set; }
		public List<ImageDTO> Images { get; set; }
		public CreatorsDTO Creators { get; set; }
		public CharactersDTO Characters { get; set; }
		public StoriesDTO Stories { get; set; }
		public EventsDTO Events { get; set; }
	}

	public class TextObjectDTO
	{
		public string Type { get; set; }
		public string Language { get; set; }
		public string Text { get; set; }
	}

	public class UrlDTO
	{

	}

	public class SeriesDTO
	{
		public string ResourceURI { get; set; }
		public string Name { get; set; }
	}

	public class VariantDTO
	{
		public string ResourceURI { get; set; }
		public string Name { get; set; }
	}

	public class CollectionDTO
	{
		public string ResourceURI { get; set; }
		public string Name { get; set; }
	}

	public class CollectedIssueDTO
	{
		public string ResourceURI { get; set; }
		public string Name { get; set; }
	}

	public class DateDTO
	{
		public string Type { get; set; }
		public string Dates { get; set; }
	}

	public class PriceDTO
	{
		public string Type { get; set; }
		public string Prices { get; set; }
	}

	public class ThumbnailDTO
	{
		public string Path { get; set; }
		public string Extension { get; set; }
	}

	public class ImageDTO
	{
		public string Path { get; set; }
		public string Extension { get; set; }
	}

	public class CreatorsDTO
	{
		public string Available { get; set; }
		public string CollectionURI { get; set; }
		public List<CreatorDTO> Items { get; set; }
	}

	public class CreatorDTO
	{
		public string ResourceURI { get; set; }
		public string Name { get; set; }
		public string Role { get; set; }
	}

	public class CharactersDTO
	{
		public string Available { get; set; }
		public string CollectionURI { get; set; }
		public List<CharacterDTO> Items { get; set; }
	}

	public class CharacterDTO
	{
		public string ResourceURI { get; set; }
		public string Name { get; set; }
	}

	public class StoriesDTO
	{
		public string Available { get; set; }
		public string CollectionURI { get; set; }
		public List<StoryDTO> Items { get; set; }
	}

	public class StoryDTO
	{
		public string ResourceURI { get; set; }
		public string Name { get; set; }
		public string Type { get; set; }
	}

	public class EventsDTO
	{
		public string Available { get; set; }
		public string CollectionURI { get; set; }
		public List<EventDTO> Items { get; set; }
	}

	public class EventDTO
	{
		public string ResourceURI { get; set; }
		public string Name { get; set; }
	}
}
