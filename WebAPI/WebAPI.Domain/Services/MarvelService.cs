using WebAPI.Domain.Entities;
using WebAPI.Domain.IRepositories;

namespace WebAPI.Domain.Services
{
	public class MarvelService
	{
		private readonly IMarvelRepository _marvelRepository;

		public MarvelService(IMarvelRepository marvelRepository)
		{
			_marvelRepository = marvelRepository;
		}

		public async Task<ComicResponseEntity> GetComicsAsync(int limit)
		{
			return await _marvelRepository.GetComicsAsync(limit);
		}

		public async Task<ComicResponseEntity> GetComicIdAsync(int id)
		{
			return await _marvelRepository.GetComicIdAsync(id);
		}
	}
}
