using Microsoft.AspNetCore.Mvc;
using WebAPI.Application.UseCase.Interfaces;
using WebAPI.Application.UseCase;

namespace WebAPI.Controllers
{
	[ApiController]
	[Route("api/WebAPI/[controller]")]
	public class MarvelController : Controller
	{
		private readonly IMarvelUseCase _marvelUseCase;
		private IConfiguration _configuration;
		public MarvelController(IConfiguration configuration)
		{
			_configuration = configuration;
			_marvelUseCase = new MarvelUseCase(_configuration);
		}

		[HttpGet("[action]/{limit}")]
		public async Task<IActionResult> GetComicsAsync(int limit)
		{
			var result = await _marvelUseCase.GetComicsAsync(limit);
			if (!result.Succeeded)
				return BadRequest();
			return new JsonResult(result);
		}

		[HttpGet("[action]/{id}")]
		public async Task<IActionResult> GetComicIdAsync(int id)
		{
			var result = await _marvelUseCase.GetComicIdAsync(id);
			if (!result.Succeeded)
				return BadRequest();
			return new JsonResult(result);
		}

		[HttpGet("[action]/{docNumber}/{email}")]
		public async Task<IActionResult> GetComicsFavoritesAsync(string docNumber, string email)
		{
			var result = await _marvelUseCase.GetComicsFavoritesAsync(docNumber, email);
			if (!result.Succeeded)
				return BadRequest();
			return new JsonResult(result);
		}
	}
}
