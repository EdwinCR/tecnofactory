using System.Linq.Expressions;
using WebAPI.Domain.Entities;

namespace WebAPI.Domain.IRepositories
{
	public interface IUsersRepository : IDisposable
	{
		UsersEntity GetUserByPredicate(Expression<Func<UsersEntity, bool>> predicado);
		UsersEntity RegisterUsers(UsersEntity user);
		string HashPassword(string password);
		bool VerifyPassword(string password, string hashedPassword);
	}
}
