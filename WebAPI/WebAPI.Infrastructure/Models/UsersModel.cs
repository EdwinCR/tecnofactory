using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI.Infrastructure.Models
{
	[Table("users", Schema = "dbo")]
	public class UsersModel
	{
		[Key]
		[Column("id", TypeName = "int4")]
		public int Id { get; set; }

		[Column("docnumber", TypeName = "varchar(20)")]
		[Required]
		public string DocNumber { get; set; }

		[Column("username", TypeName = "varchar(50)")]
		[Required]
		public string UserName { get; set; }

		[Column("password", TypeName = "varchar(50)")]
		[Required]
		public string Password { get; set; }

		[Column("email", TypeName = "varchar(100)")]
		[Required]
		public string Email { get; set; }

		[Column("state", TypeName = "varchar(20)")]
		public string State { get; set; }
	}
}
