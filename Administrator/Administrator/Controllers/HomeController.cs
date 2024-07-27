using Administrator.Authorization;
using Administrator.Models;
using Administrator.Services;
using Administrator.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Reflection;
using System.Text.Json;
using static Administrator.Models.GrupoEnum;

namespace Administrator.Controllers
{
	[ValidateSession]
	public class HomeController : Controller
	{
        private readonly IMarvelService _marvelService;
        private readonly IFavoriteService _favoriteService;
        private IConfiguration _configuration;
        public HomeController(IConfiguration configuration)
		{
            _configuration = configuration;
            _marvelService = new MarvelService(_configuration);
            _favoriteService = new FavoriteService(_configuration);
        }

		public async Task<IActionResult> Index()
		{
			var model = new ComicResponseVM();
			var result = await _marvelService.GetComics(10);

            if (result != null)
            {
                if (result.Succeeded)
                {
                    model = result.Data;
                }
            }

            return View(model);
        }

        public async Task<IActionResult> AddFavorite(int idComic)
        {
            var userSession = HttpContext.Session.GetString("User");
            var dataUser = userSession == null ? new UsersVM() : JsonSerializer.Deserialize<UsersVM>(userSession);

            var request = new FavoriteRequest();
			request.State = EnumState.Activo.ToString();
			request.IdComic = idComic;
			request.Email = dataUser.Email;
			request.DocNumber = dataUser.DocNumber;

            var result = await _favoriteService.RegisterFavorite(request);

            return Json(new { EsValido = result.Succeeded, Mensaje = result.Message });
        }

        public async Task<IActionResult> RemoveFavorite(int idComic)
        {
            var userSession = HttpContext.Session.GetString("User");
            var dataUser = userSession == null ? new UsersVM() : JsonSerializer.Deserialize<UsersVM>(userSession);

            var request = new FavoriteRequest();
            request.IdComic = idComic;
            request.Email = dataUser.Email;
            request.DocNumber = dataUser.DocNumber;

            var result = await _favoriteService.DeleteFavorite(request);

            return Json(new { EsValido = result.Succeeded, Mensaje = result.Message });
        }

        public async Task<IActionResult> Favorites()
        {
            var model = new ComicResponseVM();
            var userSession = HttpContext.Session.GetString("User");
            var dataUser = userSession == null ? new UsersVM() : JsonSerializer.Deserialize<UsersVM>(userSession);

            var result = await _marvelService.GetComicsFavorites(dataUser.DocNumber, dataUser.Email);

           if(result != null)
            {
                if (result.Succeeded)
                {
                    model = result.Data;
                }
            }

            return View(model);
        }

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
