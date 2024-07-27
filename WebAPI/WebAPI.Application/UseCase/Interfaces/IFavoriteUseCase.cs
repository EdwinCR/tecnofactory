using WebAPI.Application.DTO;
using WebAPI.Application.Models;

namespace WebAPI.Application.UseCase.Interfaces
{
	public interface IFavoriteUseCase
	{
		Response<List<FavoriteDTO>> GetFavoriteByUser(string docnumber, string email);
		Response<FavoriteDTO> RegisterFavorite(FavoriteRequest favorite);
		Response<FavoriteDTO> DeleteFavorite(FavoriteRequest favorite);
	}
}
