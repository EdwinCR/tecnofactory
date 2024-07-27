using Microsoft.AspNetCore.Mvc;
using WebAPI.Application.Models;
using WebAPI.Application.UseCase;
using WebAPI.Application.UseCase.Interfaces;

namespace WebAPI.Controllers
{
	[ApiController]
	[Route("api/WebAPI/[controller]")]
	public class UsersController : Controller
	{
		private readonly IUsersUseCase _usersUseCase;
		
		public UsersController()
        {
			_usersUseCase = new UsersUseCase();
        }

		[HttpPost("[action]")]
		public IActionResult RegisterUsers(UsersRequest request)
		{
			var result = _usersUseCase.RegisterUsers(request);
			if (!result.Succeeded)
				return BadRequest();
			return new JsonResult(result);
		}

		[HttpPost("[action]")]
		public IActionResult LoginUser(LoginRequest login)
		{
			var result = _usersUseCase.LoginUser(login.Email, login.Password);
			if (!result.Succeeded)
				return BadRequest();

			if (result.Data)
			{
				return Ok();
			}
			else
			{
				return Unauthorized();
			}
		}
	}
}
