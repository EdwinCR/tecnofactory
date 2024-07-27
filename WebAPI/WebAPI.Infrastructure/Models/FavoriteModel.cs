using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebAPI.Infrastructure.Models
{
	[Table("favorite", Schema = "dbo")]
	public class FavoriteModel
	{
		[Key]
		[Column("id", TypeName = "int4")]
		public int Id { get; set; }

		[Column("docnumber", TypeName = "varchar(20)")]
		[Required]
		public string DocNumber { get; set; }

		[Column("email", TypeName = "varchar(100)")]
		[Required]
		public string Email { get; set; }

		[Column("idcomic", TypeName = "int")]
		[Required]
		public int IdComic { get; set; }

		[Column("state", TypeName = "varchar(20)")]
		public string State { get; set; }

	}

	public class GrupoEnum
	{
		public enum EnumState
		{
			Activo,
			Eliminado
		}
	}
}
