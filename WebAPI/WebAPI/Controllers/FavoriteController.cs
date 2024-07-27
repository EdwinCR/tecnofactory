using Microsoft.AspNetCore.Mvc;
using WebAPI.Application.Models;
using WebAPI.Application.UseCase.Interfaces;
using WebAPI.Application.UseCase;

namespace WebAPI.Controllers
{
	[ApiController]
	[Route("api/WebAPI/[controller]")]
	public class FavoriteController : Controller
	{
		private readonly IFavoriteUseCase _favoriteUseCase;
		public FavoriteController()
		{
			_favoriteUseCase = new FavoriteUseCase();
		}

		[HttpPost("[action]")]
		public IActionResult RegisterFavorite(FavoriteRequest request)
		{
			var result = _favoriteUseCase.RegisterFavorite(request);
			if (!result.Succeeded)
				return BadRequest();
			return new JsonResult(result);
		}

		[HttpGet("[action]/{docNumber}/{email}")]
		public  IActionResult GetFavoriteByUser(string docNumber, string email)
		{
			var result =  _favoriteUseCase.GetFavoriteByUser(docNumber, email);
			if (!result.Succeeded)
				return BadRequest();
			return new JsonResult(result);
		}


		[HttpPut("[action]/{id}")]
		public IActionResult DeleteFavorite(int id)
		{
			var result = _favoriteUseCase.DeleteFavorite(id);
			if (!result.Succeeded)
				return BadRequest();
			return new JsonResult(result);
		}
	}
}
