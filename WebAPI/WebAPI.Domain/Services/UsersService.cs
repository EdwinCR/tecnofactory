using System.Linq.Expressions;
using WebAPI.Domain.Entities;
using WebAPI.Domain.IRepositories;

namespace WebAPI.Domain.Services
{
	public class UsersService
	{
		private readonly IUsersRepository _usersRepository;

		public UsersService(IUsersRepository usersRepository)
		{
			_usersRepository = usersRepository;
		}

		public UsersEntity GetUserByPredicate(Expression<Func<UsersEntity, bool>> predicado)
		{
			return _usersRepository.GetUserByPredicate(predicado);
		}

		public UsersEntity RegisterUsers(UsersEntity user)
		{
			return _usersRepository.RegisterUsers(user);
		}

		public string HashPassword(string password)
		{
			return _usersRepository.HashPassword(password);
		}

		public bool VerifyPassword(string password, string hashedPassword)
		{
			return _usersRepository.VerifyPassword(password, hashedPassword);
		}
	}
}
