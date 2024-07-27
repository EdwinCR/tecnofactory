using AutoMapper;
using AutoMapper.Extensions.ExpressionMapping;
using System.Linq.Expressions;
using WebAPI.Application.DTO;
using WebAPI.Application.Models;
using WebAPI.Application.Profiles;
using WebAPI.Application.UseCase.Interfaces;
using WebAPI.Domain.Entities;
using WebAPI.Domain.IRepositories;
using WebAPI.Domain.Services;
using WebAPI.Infrastructure.Repositories;
using static WebAPI.Application.Models.GrupoEnum;

namespace WebAPI.Application.UseCase
{
	public class FavoriteUseCase : IFavoriteUseCase
	{
		private readonly IMapper _mapper;
		private readonly IFavoriteRepository _favoriteRepository;

		public FavoriteUseCase(IFavoriteRepository favoriteRepository = null)
		{
			_favoriteRepository = favoriteRepository;

			var mapConfig = new MapperConfiguration(cfg =>
			{
				cfg.AddProfile<ApplicationProfile>();
				cfg.AddExpressionMapping();
			});
			_mapper = new Mapper(mapConfig);
		}

		public Response<List<FavoriteDTO>> GetFavoriteByUser(string docnumber, string email)
		{
			var response = new Response<List<FavoriteDTO>>();
			try
			{
				using (var favoriteRepository = _favoriteRepository ?? new FavoriteRepository())
				{
					Expression<Func<FavoriteEntity, bool>> predicado = b => b.DocNumber == docnumber && b.Email == email && b.State == EnumState.Activo.ToString();
					response.Data = _mapper.Map<List<FavoriteDTO>>(new FavoriteService(favoriteRepository).GetFavoriteByPredicate(predicado));
				}
				response.Succeeded = true;
			}
			catch (Exception e)
			{
				response.Message = e.ToString();
			}

			return response;
		}

		public Response<FavoriteDTO> ValidateFavoriteExists(string docnumber, string email, int idComic)
		{
			var response = new Response<FavoriteDTO>();
			try
			{
				using (var favoriteRepository = _favoriteRepository ?? new FavoriteRepository())
				{
					Expression<Func<FavoriteEntity, bool>> predicado = b => b.DocNumber == docnumber && b.Email == email && b.IdComic == idComic;
					response.Data = _mapper.Map<FavoriteDTO>(new FavoriteService(favoriteRepository).GetFavoriteByPredicate(predicado).FirstOrDefault());
				}
				response.Succeeded = true;
			}
			catch (Exception e)
			{
				response.Message = e.ToString();
			}

			return response;
		}

		public Response<FavoriteDTO> RegisterFavorite(FavoriteRequest favorite)
		{
			var response = new Response<FavoriteDTO>();
			try
			{
				using (var favoriteRepository = _favoriteRepository ?? new FavoriteRepository())
				{
					FavoriteEntity favoriteEntity = _mapper.Map<FavoriteEntity>(favorite);

					var favoriteExists = ValidateFavoriteExists(favorite.DocNumber, favorite.Email, favorite.IdComic).Data;

					if (favoriteExists == null)
					{
						response.Data = _mapper.Map<FavoriteDTO>(new FavoriteService(favoriteRepository).RegisterFavorite(favoriteEntity));

						response.Message = EnumMessageResponse.Add.ToString();
					}
					else
					{
						if(favoriteExists.State == EnumState.Eliminado.ToString())
						{
							new FavoriteService(favoriteRepository).UpdateFavoriteId(favoriteExists.Id, EnumState.Activo.ToString());
							response.Message = EnumMessageResponse.Update.ToString();
						}
						else
						{
							response.Message = EnumMessageResponse.Exists.ToString();
						}
						
					}
				}
				response.Succeeded = true;
			}
			catch (Exception e)
			{
				response.Message = e.ToString();
			}

			return response;
		}

		public Response<FavoriteDTO> DeleteFavorite(int id)
		{
			var response = new Response<FavoriteDTO>();
			try
			{
				using (var favoriteRepository = _favoriteRepository ?? new FavoriteRepository())
				{
					new FavoriteService(favoriteRepository).UpdateFavoriteId(id, EnumState.Eliminado.ToString());
					response.Message = EnumMessageResponse.Update.ToString();
				}
				response.Succeeded = true;
			}
			catch (Exception e)
			{
				response.Message = e.ToString();
			}

			return response;
		}
	}
}
