using Administrator.Models;
using Administrator.Services.Interfaces;
using Newtonsoft.Json;

namespace Administrator.Services
{
	public class UsersService : CommonService, IUsersService
	{
		private string _apiEndpoint;
		public UsersService(IConfiguration configuration) : base(configuration)
		{
			Configuration = configuration;
			_apiEndpoint = Configuration["HostWebAPIs:WebAPI"];
		}


		#region POST
		public async Task<Response<UsersVM>> LoginUser(LoginRequest request)
		{
			return JsonConvert.DeserializeObject<Response<UsersVM>>(
				await PostContent($"{_apiEndpoint}Users/LoginUser", request)
			);
		}

		public async Task<Response<UsersVM>> RegisterUsers(UserRequest request)
		{
			return JsonConvert.DeserializeObject<Response<UsersVM>>(
				await PostContent($"{_apiEndpoint}Users/RegisterUsers", request)
			);
		}
		#endregion
	}
}
