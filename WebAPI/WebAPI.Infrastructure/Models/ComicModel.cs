
namespace WebAPI.Infrastructure.Models
{
	public class ComicResponseModel
	{
		public string Code { get; set; }
		public string Status { get; set; }
		public string Copyright { get; set; }
		public string AttributionText { get; set; }
		public string AttributionHTML { get; set; }
		public string Etag { get; set; }
		public ComicDataModel Data { get; set; }
	}

	public class ComicDataModel
	{
		public string Offset { get; set; }
		public string Limit { get; set; }
		public string Total { get; set; }
		public string Count { get; set; }
		public List<ComicModel> Results { get; set; }
	}

	public class ComicModel
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
		public List<TextObjectModel> TextObjects { get; set; }
		public string ResourceURI { get; set; }
		public List<UrlModel> Urls { get; set; }
		public SeriesModel Series { get; set; }
		public List<VariantModel> Variants { get; set; }
		public List<CollectionModel> Collections { get; set; }
		public List<CollectedIssueModel> CollectedIssues { get; set; }
		public List<DateModel> Dates { get; set; }
		public List<PriceModel> Prices { get; set; }
		public ThumbnailModel Thumbnail { get; set; }
		public List<ImageModel> Images { get; set; }
		public CreatorsModel Creators { get; set; }
		public CharactersModel Characters { get; set; }
		public StoriesModel Stories { get; set; }
		public EventsModel Events { get; set; }
	}

	public class TextObjectModel
	{
		public string Type { get; set; }
		public string Language { get; set; }
		public string Text { get; set; }
	}

	public class UrlModel
	{
		
	}

	public class SeriesModel
	{
		public string ResourceURI { get; set; }
		public string Name { get; set; }
	}

	public class VariantModel
	{
		public string ResourceURI { get; set; }
		public string Name { get; set; }
	}

	public class CollectionModel
	{
		public string ResourceURI { get; set; }
		public string Name { get; set; }
	}

	public class CollectedIssueModel
	{
		public string ResourceURI { get; set; }
		public string Name { get; set; }
	}

	public class DateModel
	{
		public string Type { get; set; }
		public string Date { get; set; }
	}

	public class PriceModel
	{
		public string Type { get; set; }
		public string Prices { get; set; }
	}

	public class ThumbnailModel
	{
		public string Path { get; set; }
		public string Extension { get; set; }
	}

	public class ImageModel
	{
		public string Path { get; set; }
		public string Extension { get; set; }
	}

	public class CreatorsModel
	{
		public string Available { get; set; }
		public string CollectionURI { get; set; }
		public List<CreatorModel> Items { get; set; }
	}

	public class CreatorModel
	{
		public string ResourceURI { get; set; }
		public string Name { get; set; }
		public string Role { get; set; }
	}

	public class CharactersModel
	{
		public string Available { get; set; }
		public string CollectionURI { get; set; }
		public List<CharacterModel> Items { get; set; }
	}

	public class CharacterModel
	{
		public string ResourceURI { get; set; }
		public string Name { get; set; }
	}

	public class StoriesModel
	{
		public string Available { get; set; }
		public string CollectionURI { get; set; }
		public List<StoryModel> Items { get; set; }
	}

	public class StoryModel
	{
		public string ResourceURI { get; set; }
		public string Name { get; set; }
		public string Type { get; set; }
	}

	public class EventsModel
	{
		public string Available { get; set; }
		public string CollectionURI { get; set; }
		public List<EventModel> Items { get; set; }
	}

	public class EventModel
	{
		public string ResourceURI { get; set; }
		public string Name { get; set; }
	}
}
