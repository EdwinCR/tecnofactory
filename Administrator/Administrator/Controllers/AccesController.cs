using Administrator.Models;
using Administrator.Services;
using Administrator.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using static Administrator.Models.GrupoEnum;

namespace Administrator.Controllers
{
	public class AccesController : Controller
	{
		private readonly IUsersService _usersService;
		private IConfiguration _configuration;
        public AccesController(IConfiguration configuration)
        {
			_configuration = configuration;
			_usersService = new UsersService(_configuration);
        }

        public IActionResult LoginUser()
		{
			return View();
		}


		public IActionResult RegisterUser()
		{
			return View();
		}


		[HttpPost]
		public async Task<IActionResult> LoginUserAsync(LoginRequest request)
		{
			var result = await _usersService.LoginUser(request);

			if (result.Succeeded)
			{
				if (result.Message == Ok().StatusCode.ToString())
				{
					HttpContext.Session.SetString("User", JsonSerializer.Serialize(result.Data));

					return Json(new { EsValido = result.Succeeded, Mensaje = result.Message, Acceso = true });
				}
				else
				{
					return Json(new { EsValido = result.Succeeded, Mensaje = result.Message, Acceso = false });
				}
			}
			else
			{
				return Json(new { EsValido = result.Succeeded, Mensaje = result.Message, Acceso = false });
			}
		}

		[HttpPost]
		public async Task<JsonResult> RegisterUserAsync(UserRequest request)
		{
			request.State = EnumState.Activo.ToString();
			var result = await _usersService.RegisterUsers(request);

			return Json(new { EsValido = result.Succeeded, Mensaje = result.Message });
		}

        public IActionResult Logout()
        {
            HttpContext.Session.Remove("User");
            return RedirectToAction("LoginUser", "Acces");
        }
    }
}
