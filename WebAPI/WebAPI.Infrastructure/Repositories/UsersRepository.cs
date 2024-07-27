using AutoMapper;
using AutoMapper.Extensions.ExpressionMapping;
using System.Linq.Expressions;
using System.Security.Cryptography;
using WebAPI.Domain.Entities;
using WebAPI.Domain.IRepositories;
using WebAPI.Infrastructure.Contexts;
using WebAPI.Infrastructure.Models;
using WebAPI.Infrastructure.Profiles;

namespace WebAPI.Infrastructure.Repositories
{
	public class UsersRepository : IUsersRepository
	{
		private readonly IMapper _mapper;
		private readonly WebAPIContext _context;
		public UsersRepository()
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

		public UsersEntity GetUserByPredicate(Expression<Func<UsersEntity, bool>> predicado)
		{
			try
			{
				var predicadoMapped = _mapper.Map<Expression<Func<UsersModel, bool>>>(predicado);
				return _mapper.Map<UsersEntity>(
					_context.UsersModel.Where(predicadoMapped).FirstOrDefault()
				);
			}
			catch (Exception e)
			{
				throw new ArgumentNullException(e.ToString());
			}
		}

		public UsersEntity RegisterUsers(UsersEntity user)
		{
			try
			{
				UsersModel usersModel = _mapper.Map<UsersModel>(user);
				usersModel.Email = usersModel.Email.ToLowerInvariant();
				_context.UsersModel.Add(usersModel);
				_context.SaveChanges();
				return _mapper.Map<UsersEntity>(usersModel);
			}
			catch (Exception e)
			{
				throw new ArgumentNullException(e.ToString());
			}
		}


		#region Password
		public string HashPassword(string password)
		{
			byte[] salt = new byte[16];
			using (var rng = new RNGCryptoServiceProvider())
			{
				rng.GetBytes(salt);
			}

			var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 10000);
			byte[] hash = pbkdf2.GetBytes(20);

			byte[] hashBytes = new byte[36];
			Array.Copy(salt, 0, hashBytes, 0, 16);
			Array.Copy(hash, 0, hashBytes, 16, 20);

			string hashedPassword = Convert.ToBase64String(hashBytes);
			return hashedPassword;
		}

		public bool VerifyPassword(string password, string hashedPassword)
		{
			byte[] hashBytes = Convert.FromBase64String(hashedPassword);
			byte[] salt = new byte[16];
			Array.Copy(hashBytes, 0, salt, 0, 16);

			var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 10000);
			byte[] hash = pbkdf2.GetBytes(20);

			for (int i = 0; i < 20; i++)
			{
				if (hashBytes[i + 16] != hash[i])
				{
					return false;
				}
			}

			return true;
		}
		#endregion

	}
}
