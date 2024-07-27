using WebAPI.Application.DTO;
using WebAPI.Application.Models;

namespace WebAPI.Application.UseCase.Interfaces
{
	public interface IMarvelUseCase
	{
		Task<Response<ComicResponseDTO>> GetComicsAsync(int limit);
		Task<Response<ComicResponseDTO>> GetComicIdAsync(int id);
		Task<Response<ComicResponseDTO>> GetComicsFavoritesAsync(string docNumber, string email);
	}
}
