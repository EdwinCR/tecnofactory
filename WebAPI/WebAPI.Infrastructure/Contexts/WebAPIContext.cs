using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using WebAPI.Infrastructure.Helpers;
using WebAPI.Infrastructure.Models;

namespace WebAPI.Infrastructure.Contexts
{
	public class WebAPIContext : DbContext
	{
		public IConfiguration configuration { get; set; }

		public DbSet<UsersModel> UsersModel { get; set; }
		public DbSet<FavoriteModel> FavoriteModel { get; set; }

		public WebAPIContext()
        {
			configuration = AppSettings.GetConfiguration();
		}

		public WebAPIContext(DbContextOptions<WebAPIContext> options) : base(options)
		{
			configuration = AppSettings.GetConfiguration();
		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer(configuration.GetConnectionString("SqlserverConnection"));
		}
	}
}
