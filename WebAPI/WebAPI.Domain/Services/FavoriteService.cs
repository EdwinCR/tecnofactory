using System.Linq.Expressions;
using WebAPI.Domain.Entities;
using WebAPI.Domain.IRepositories;

namespace WebAPI.Domain.Services
{
	public class FavoriteService
	{
		private readonly IFavoriteRepository _favoriteRepository;

		public FavoriteService(IFavoriteRepository favoriteRepository)
		{
			_favoriteRepository = favoriteRepository;
		}
		public List<FavoriteEntity> GetFavoriteByPredicate(Expression<Func<FavoriteEntity, bool>> predicado)
		{
			return _favoriteRepository.GetFavoriteByPredicate(predicado);
		}

		public FavoriteEntity RegisterFavorite(FavoriteEntity favorite)
		{
			return _favoriteRepository.RegisterFavorite(favorite);
		}

		public void UpdateFavoriteId(int id, string state)
		{
			_favoriteRepository.UpdateFavoriteId(id, state);
		}
	}
}
