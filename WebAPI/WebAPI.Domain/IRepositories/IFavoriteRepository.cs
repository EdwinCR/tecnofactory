using System.Linq.Expressions;
using WebAPI.Domain.Entities;

namespace WebAPI.Domain.IRepositories
{
	public interface IFavoriteRepository : IDisposable
	{
		List<FavoriteEntity> GetFavoriteByPredicate(Expression<Func<FavoriteEntity, bool>> predicado);
		FavoriteEntity RegisterFavorite(FavoriteEntity favorite);
		void UpdateFavoriteId(int id, string state);
	}
}
