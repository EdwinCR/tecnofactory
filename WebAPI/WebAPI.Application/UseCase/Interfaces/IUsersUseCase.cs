using WebAPI.Application.DTO;
using WebAPI.Application.Models;

namespace WebAPI.Application.UseCase.Interfaces
{
	public interface IUsersUseCase
	{
		Response<UsersDTO> ValidateUserExists(string docnumber, string email);
		Response<UsersDTO> RegisterUsers(UsersRequest user);
		Response<UsersDTO> LoginUser(string email, string password);
	}
}
