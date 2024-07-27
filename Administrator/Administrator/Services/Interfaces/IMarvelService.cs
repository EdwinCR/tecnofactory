using Administrator.Models;

namespace Administrator.Services.Interfaces
{
	public interface IMarvelService
	{
		Task<Response<ComicResponseVM>> GetComics(int limit);
		Task<Response<ComicResponseVM>> GetComicId(int id);
		Task<Response<ComicResponseVM>> GetComicsFavorites(string docNumber, string email);
	}
}
