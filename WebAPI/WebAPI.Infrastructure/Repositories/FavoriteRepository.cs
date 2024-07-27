using AutoMapper;
using AutoMapper.Extensions.ExpressionMapping;
using System.Linq.Expressions;
using WebAPI.Domain.Entities;
using WebAPI.Domain.IRepositories;
using WebAPI.Infrastructure.Contexts;
using WebAPI.Infrastructure.Models;
using WebAPI.Infrastructure.Profiles;

namespace WebAPI.Infrastructure.Repositories
{
	public class FavoriteRepository : IFavoriteRepository
	{
		private readonly IMapper _mapper;
		private readonly WebAPIContext _context;
		public FavoriteRepository()
        {
			var mapConfig = new MapperConfiguration(cfg =>
			{
				cfg.AddProfile<InfrastructureProfile>();
				cfg.AddExpressionMapping();
			});
			_context = new WebAPIContext();
			_mapper = new Mapper(mapConfig);
		}

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		protected virtual void Dispose(bool disposing)
		{
			// Cleanup
		}

		public List<FavoriteEntity> GetFavoriteByPredicate(Expression<Func<FavoriteEntity, bool>> predicado)
		{
			try
			{
				var predicadoMapped = _mapper.Map<Expression<Func<FavoriteModel, bool>>>(predicado);
				return _mapper.Map<List<FavoriteEntity>>(
					_context.FavoriteModel.Where(predicadoMapped).ToList()
				);
			}
			catch (Exception e)
			{
				throw new ArgumentNullException(e.ToString());
			}
		}

		private int GetMaxId()
		{
			if(_context.FavoriteModel.Count() == 0)
			{
				return 1;
			}
			else
			{
				return _context.FavoriteModel.Max(x => x.Id) + 1;
			}
		}

		public FavoriteEntity RegisterFavorite(FavoriteEntity favorite)
		{
			try
			{
				FavoriteModel favoriteModel = _mapper.Map<FavoriteModel>(favorite);
				_context.FavoriteModel.Add(favoriteModel);
				_context.SaveChanges();
				return _mapper.Map<FavoriteEntity>(favoriteModel);
			}
			catch (Exception e)
			{
				throw new ArgumentNullException(e.ToString());
			}
		}

		public void UpdateFavoriteId(int id, string state)
		{
			try
			{
				var register = _context.FavoriteModel.Where(x => x.Id == id).FirstOrDefault();
				register.State = state;
				_context.SaveChanges();
			}
			catch (Exception e)
			{
				throw new ArgumentNullException(e.ToString());
			}
		}
	}
}
