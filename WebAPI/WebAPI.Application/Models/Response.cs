﻿
namespace WebAPI.Application.Models
{
	public class Response<T>
	{

		public T Data { get; set; }
		public bool Succeeded { get; set; }
		public string[] Errors { get; set; }
		public string Message { get; set; }

		public Response() { }

		public Response(T data)
		{
			this.Succeeded = true;
			this.Message = string.Empty;
			this.Errors = null;
			this.Data = data;
		}

	}

	public class GrupoEnum
	{
		public enum EnumMessageResponse
		{
			Add,
			Exists,
			Update
		}

		public enum EnumState
		{
			Activo,
			Eliminado
		}
	}
}
