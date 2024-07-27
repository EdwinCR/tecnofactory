using AutoMapper;
using AutoMapper.Extensions.ExpressionMapping;
using Microsoft.Extensions.Configuration;
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
	public class MarvelUseCase : IMarvelUseCase
	{
		private readonly IMapper _mapper;
		private readonly IMarvelRepository _marvelRepository;
		private IConfiguration _configuration;
		private readonly IFavoriteRepository _favoriteRepository;
		public MarvelUseCase(IConfiguration configuration, IFavoriteRepository favoriteRepository = null, IMarvelRepository marvelRepository = null)
		{
			_marvelRepository = marvelRepository;
			_configuration = configuration;
			_favoriteRepository = favoriteRepository;

			var mapConfig = new MapperConfiguration(cfg =>
			{
				cfg.AddProfile<ApplicationProfile>();
				cfg.AddExpressionMapping();
			});
			_mapper = new Mapper(mapConfig);
		}

		public async Task<Response<ComicResponseDTO>> GetComicsAsync(int limit)
		{
			var response = new Response<ComicResponseDTO>();
			try
			{
				using (var marvelRepository = _marvelRepository ?? new MarvelRepository(_configuration))
				{
					response.Data = _mapper.Map<ComicResponseDTO>(await new MarvelService(marvelRepository).GetComicsAsync(limit));
				}
				response.Succeeded = true;
			}
			catch (Exception e)
			{
				response.Message = e.ToString();
			}

			return response;
		}

		public async Task<Response<ComicResponseDTO>> GetComicsFavoritesAsync(string docNumber, string email)
		{
			var response = new Response<ComicResponseDTO>();
			try
			{
				using (var marvelRepository = _marvelRepository ?? new MarvelRepository(_configuration))
				using (var favoriteRepository = _favoriteRepository ?? new FavoriteRepository())
				{
					var listComic = _mapper.Map<ComicResponseDTO>(await new MarvelService(marvelRepository).GetComicsAsync(30));

					Expression<Func<FavoriteEntity, bool>> predicado = b => b.DocNumber == docNumber && b.Email == email && b.State == EnumState.Activo.ToString();
					var listFavorite = _mapper.Map<List<FavoriteDTO>>(new FavoriteService(favoriteRepository).GetFavoriteByPredicate(predicado));

					List<string> listComicFav = listFavorite.Select(x => x.IdComic.ToString()).ToList();

					var data = listComic.Data.Results.Where(x => listComicFav.Contains(x.Id)).ToList();

					listComic.Data.Results = data;
					response.Data = listComic;
				}
				response.Succeeded = true;
			}
			catch (Exception e)
			{
				response.Message = e.ToString();
			}

			return response;
		}

		public async Task<Response<ComicResponseDTO>> GetComicIdAsync(int id)
		{
			var response = new Response<ComicResponseDTO>();
			try
			{
				using (var marvelRepository = _marvelRepository ?? new MarvelRepository(_configuration))
				{
					response.Data = _mapper.Map<ComicResponseDTO>(await new MarvelService(marvelRepository).GetComicIdAsync(id));
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
