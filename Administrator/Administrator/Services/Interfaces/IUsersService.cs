using Administrator.Models;

namespace Administrator.Services.Interfaces
{
	public interface IUsersService
	{
		Task<Response<UsersVM>> LoginUser(LoginRequest request);
		Task<Response<UsersVM>> RegisterUsers(UserRequest request);
	}
}
