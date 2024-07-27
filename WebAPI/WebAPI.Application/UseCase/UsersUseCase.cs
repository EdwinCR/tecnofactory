using AutoMapper;
using AutoMapper.Extensions.ExpressionMapping;
using System.Linq.Expressions;
using WebAPI.Application.DTO;
using WebAPI.Application.Models;
using WebAPI.Application.Profiles;
using WebAPI.Application.UseCase.Interfaces;
using WebAPI.Domain.Entities;
using WebAPI.Domain.IRepositories;
using WebAPI.Domain.Services;
using WebAPI.Infrastructure.Repositories;
using static WebAPI.Application.Models.GrupoEnum;

namespace WebAPI.Application.UseCase
{
	public class UsersUseCase : IUsersUseCase
	{
		private readonly IMapper _mapper;
		private readonly IUsersRepository _usersRepository;
	
		public UsersUseCase(IUsersRepository usersRepository = null)
        {
            _usersRepository = usersRepository;
			
			var mapConfig = new MapperConfiguration(cfg =>
			{
				cfg.AddProfile<ApplicationProfile>();
				cfg.AddExpressionMapping();
			});
			_mapper = new Mapper(mapConfig);
		}

		public Response<UsersDTO> ValidateUserExists(string docnumber, string email)
		{
			var response = new Response<UsersDTO>();
			try
			{
				using (var usersRepository = _usersRepository ?? new UsersRepository())
				{
					Expression<Func<UsersEntity, bool>> predicado = b => b.DocNumber == docnumber && b.Email == email;
					response.Data = _mapper.Map<UsersDTO>(new UsersService(usersRepository).GetUserByPredicate(predicado));
				}
				response.Succeeded = true;
			}
			catch (Exception e)
			{
				response.Message = e.ToString();
			}

			return response;
		}

		public Response<bool> LoginUser(string email, string password)
		{
			var response = new Response<bool>();
			try
			{
				using (var usersRepository = _usersRepository ?? new UsersRepository())
				{
					var emailSet = email.ToLowerInvariant();
					Expression<Func<UsersEntity, bool>> predicado = b => b.Email == emailSet;
					var dataUser = _mapper.Map<UsersDTO>(new UsersService(usersRepository).GetUserByPredicate(predicado));

					if(dataUser != null)
					{
						response.Data = new UsersService(usersRepository).VerifyPassword(password, dataUser.Password);
					}
				}
				response.Succeeded = true;
			}
			catch (Exception e)
			{
				response.Message = e.ToString();
			}

			return response;
		}


		public Response<UsersDTO> RegisterUsers(UsersRequest user)
		{
			var response = new Response<UsersDTO>();
			try
			{
				using (var usersRepository = _usersRepository ?? new UsersRepository())
				{
					UsersEntity usersEntity = _mapper.Map<UsersEntity>(user);

					var userExists = ValidateUserExists(user.DocNumber, user.Email).Data;

					if (userExists == null)
					{
						usersEntity.Password = new UsersService(usersRepository).HashPassword(usersEntity.Password);
						response.Data = _mapper.Map<UsersDTO>(new UsersService(usersRepository).RegisterUsers(usersEntity));

						response.Message = EnumMessageResponse.Add.ToString();
					}
					else
					{
						response.Message = EnumMessageResponse.Exists.ToString();
					}
				}
				response.Succeeded = true;
			}
			catch (Exception e)
			{
				response.Message = e.ToString();
			}

			return response;
		}
	}
}
