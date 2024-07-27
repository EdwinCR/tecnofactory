namespace Administrator.Models
{
	public class ComicResponseVM
	{
		public string Code { get; set; }
		public string Status { get; set; }
		public string Copyright { get; set; }
		public string AttributionText { get; set; }
		public string AttributionHTML { get; set; }
		public string Etag { get; set; }
		public ComicDataVM Data { get; set; }
	}

	public class ComicDataVM
	{
		public string Offset { get; set; }
		public string Limit { get; set; }
		public string Total { get; set; }
		public string Count { get; set; }
		public List<ComicVM> Results { get; set; }
	}

	public class ComicVM
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
		public List<TextObjectVM> TextObjects { get; set; }
		public string ResourceURI { get; set; }
		public List<UrlVM> Urls { get; set; }
		public SeriesVM Series { get; set; }
		public List<VariantVM> Variants { get; set; }
		public List<CollectionVM> Collections { get; set; }
		public List<CollectedIssueVM> CollectedIssues { get; set; }
		public List<DateVM> Dates { get; set; }
		public List<PriceVM> Prices { get; set; }
		public ThumbnailVM Thumbnail { get; set; }
		public List<ImageVM> Images { get; set; }
		public CreatorsVM Creators { get; set; }
		public CharactersVM Characters { get; set; }
		public StoriesVM Stories { get; set; }
		public EventsVM Events { get; set; }
	}

	public class TextObjectVM
	{
		public string Type { get; set; }
		public string Language { get; set; }
		public string Text { get; set; }
	}

	public class UrlVM
	{

	}

	public class SeriesVM
	{
		public string ResourceURI { get; set; }
		public string Name { get; set; }
	}

	public class VariantVM
	{
		public string ResourceURI { get; set; }
		public string Name { get; set; }
	}

	public class CollectionVM
	{
		public string ResourceURI { get; set; }
		public string Name { get; set; }
	}

	public class CollectedIssueVM
	{
		public string ResourceURI { get; set; }
		public string Name { get; set; }
	}

	public class DateVM
	{
		public string Type { get; set; }
		public string Dates { get; set; }
	}

	public class PriceVM
	{
		public string Type { get; set; }
		public string Prices { get; set; }
	}

	public class ThumbnailVM
	{
		public string Path { get; set; }
		public string Extension { get; set; }
	}

	public class ImageVM
	{
		public string Path { get; set; }
		public string Extension { get; set; }
	}

	public class CreatorsVM
	{
		public string Available { get; set; }
		public string CollectionURI { get; set; }
		public List<CreatorVM> Items { get; set; }
	}

	public class CreatorVM
	{
		public string ResourceURI { get; set; }
		public string Name { get; set; }
		public string Role { get; set; }
	}

	public class CharactersVM
	{
		public string Available { get; set; }
		public string CollectionURI { get; set; }
		public List<CharacterVM> Items { get; set; }
	}

	public class CharacterVM
	{
		public string ResourceURI { get; set; }
		public string Name { get; set; }
	}

	public class StoriesVM
	{
		public string Available { get; set; }
		public string CollectionURI { get; set; }
		public List<StoryVM> Items { get; set; }
	}

	public class StoryVM
	{
		public string ResourceURI { get; set; }
		public string Name { get; set; }
		public string Type { get; set; }
	}

	public class EventsVM
	{
		public string Available { get; set; }
		public string CollectionURI { get; set; }
		public List<EventVM> Items { get; set; }
	}

	public class EventVM
	{
		public string ResourceURI { get; set; }
		public string Name { get; set; }
	}
}
