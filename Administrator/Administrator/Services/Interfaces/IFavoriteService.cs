using Administrator.Models;

namespace Administrator.Services.Interfaces
{
	public interface IFavoriteService
	{
		Task<Response<List<FavoriteVM>>> GetFavoriteByUser(string docNumber, string email);
		Task<Response<FavoriteVM>> RegisterFavorite(FavoriteRequest request);
		Task<Response<FavoriteVM>> DeleteFavorite(FavoriteRequest favorite);
	}
}
