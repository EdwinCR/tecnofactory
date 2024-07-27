using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Security.Cryptography;
using System.Text;
using WebAPI.Infrastructure.Helpers;
using WebAPI.Infrastructure.Models;
using WebAPI.Domain.IRepositories;
using AutoMapper;
using AutoMapper.Extensions.ExpressionMapping;
using WebAPI.Infrastructure.Profiles;
using WebAPI.Domain.Entities;

namespace WebAPI.Infrastructure.Repositories
{
	public class MarvelRepository : CommonService, IMarvelRepository
	{
		private readonly IMapper _mapper;
		private string _apiEndpoint;
		private readonly string _apiKey;
		private readonly string _privateKey;

		public MarvelRepository(IConfiguration configuration = null) : base(configuration)
		{
			var mapConfig = new MapperConfiguration(cfg =>
			{
				cfg.AddProfile<InfrastructureProfile>();
				cfg.AddExpressionMapping();
			});

			_mapper = new Mapper(mapConfig);
			Configuration = configuration;
			_apiEndpoint = Configuration["HostWebAPIs:MarvelAPIUrl"];
			_apiKey = Configuration["MarvelApi:ApiKey"];
			_privateKey = Configuration["MarvelApi:PrivateKey"];
		}

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		protected virtual void Dispose(bool disposing)
		{
			// Cleanup
		}

		private string GenerateMd5Hash(string input)
		{
			using (var md5 = MD5.Create())
			{
				byte[] inputBytes = Encoding.ASCII.GetBytes(input);
				byte[] hashBytes = md5.ComputeHash(inputBytes);

				StringBuilder sb = new StringBuilder();
				for (int i = 0; i < hashBytes.Length; i++)
				{
					sb.Append(hashBytes[i].ToString("X2"));
				}
				return sb.ToString().ToLower();
			}
		}

		public async Task<ComicResponseEntity> GetComicsAsync(int limit)
		{
			try
			{
				var ts = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
				var hash = GenerateMd5Hash($"{ts}{_privateKey}{_apiKey}"); 

				var comicResponse = JsonConvert.DeserializeObject<ComicResponseModel>(
				await GetReleases($"{_apiEndpoint}v1/public/comics?ts={ts}&apikey={_apiKey}&hash={hash}&limit={limit}&format=comic&orderBy=-onsaleDate"));
				return _mapper.Map<ComicResponseEntity>(comicResponse);
				
			}
			catch (Exception e)
			{
				throw new ArgumentNullException(e.ToString());
			}
		}

		public async Task<ComicResponseEntity> GetComicIdAsync(int id)
		{
			try
			{
				var ts = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
				var hash = GenerateMd5Hash($"{ts}{_privateKey}{_apiKey}");

				var comicResponse = JsonConvert.DeserializeObject<ComicResponseModel>(
				await GetReleases($"{_apiEndpoint}v1/public/comics/{id}?ts={ts}&apikey={_apiKey}&hash={hash}"));
				return _mapper.Map<ComicResponseEntity>(comicResponse);

			}
			catch (Exception e)
			{
				throw new ArgumentNullException(e.ToString());
			}
		}
	}
}
