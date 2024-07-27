using Administrator.Models;
using Administrator.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace Administrator.Services
{
    public class MarvelService : CommonService, IMarvelService
    {
		private string _apiEndpoint;
		public MarvelService(IConfiguration configuration) : base(configuration)
		{
			Configuration = configuration;
			_apiEndpoint = Configuration["HostWebAPIs:WebAPI"];
		}
	

		#region GET
		public async Task<Response<ComicResponseVM>> GetComics(int limit)
		{
			return JsonConvert.DeserializeObject<Response<ComicResponseVM>>(
				await GetReleases($"{_apiEndpoint}Marvel/GetComics/{limit}")
			);
		}

		public async Task<Response<ComicResponseVM>> GetComicId(int id)
		{
			return JsonConvert.DeserializeObject<Response<ComicResponseVM>>(
				await GetReleases($"{_apiEndpoint}Marvel/GetComicId/{id}")
			);
		}

		public async Task<Response<ComicResponseVM>> GetComicsFavorites(string docNumber, string email)
		{
			return JsonConvert.DeserializeObject<Response<ComicResponseVM>>(
				await GetReleases($"{_apiEndpoint}Marvel/GetComicsFavorites/{docNumber}/{email}")
			);
		}
		#endregion

	}
}
