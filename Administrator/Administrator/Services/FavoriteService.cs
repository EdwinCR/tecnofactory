using Administrator.Models;
using Administrator.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace Administrator.Services
{
	public class FavoriteService : CommonService, IFavoriteService
	{
		private string _apiEndpoint;
		public FavoriteService(IConfiguration configuration) : base(configuration)
		{
			Configuration = configuration;
			_apiEndpoint = Configuration["HostWebAPIs:WebAPI"];
		}

		#region GET
		public async Task<Response<List<FavoriteVM>>> GetFavoriteByUser(string docNumber, string email)
		{
			return JsonConvert.DeserializeObject<Response<List<FavoriteVM>>>(
				await GetReleases($"{_apiEndpoint}Favorite/GetFavoriteByUser/{docNumber}/{email}")
			);
		}
		#endregion

		#region POST
		public async Task<Response<FavoriteVM>> RegisterFavorite(FavoriteRequest request)
		{
			return JsonConvert.DeserializeObject<Response<FavoriteVM>>(
				await PostContent($"{_apiEndpoint}Favorite/RegisterFavorite", request)
			);
		}
		#endregion

		#region PUT
		public async Task<Response<FavoriteVM>> DeleteFavorite(FavoriteRequest favorite)
		{
			return JsonConvert.DeserializeObject<Response<FavoriteVM>>(
				await PutContent($"{_apiEndpoint}Favorite/DeleteFavorite", favorite)
			);
		}
		#endregion
	}
}
