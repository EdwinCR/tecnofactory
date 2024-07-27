
namespace WebAPI.Application.Models
{
	public class UsersRequest
	{
		public string DocNumber { get; set; }
		public string UserName { get; set; }
		public string Password { get; set; }
		public string Email { get; set; }
		public string State { get; set; }
	}
}
