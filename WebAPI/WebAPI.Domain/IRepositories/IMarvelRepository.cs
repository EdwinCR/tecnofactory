using WebAPI.Domain.Entities;

namespace WebAPI.Domain.IRepositories
{
	public interface IMarvelRepository : IDisposable
	{
		Task<ComicResponseEntity> GetComicsAsync(int limit);
		Task<ComicResponseEntity> GetComicIdAsync(int id);
	}
}
