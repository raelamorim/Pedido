using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using Pedido.Modelo.Negocio.Gateways;
using System;
using System.Threading.Tasks;

namespace Pedido.Infraestrutura.BancoDados.RedisCache
{
	public class CacheService : ICacheGateway
	{
		public readonly IDistributedCache _repository;

		public CacheService(IDistributedCache repository)
		{
			_repository = repository;
		}

		public async Task<T> GetCacheFrom<T>(string chave)
		{
			string valor = await _repository.GetStringAsync(chave.Trim());

			if (valor == null)
			{
				return default(T);
			}

			return JsonConvert.DeserializeObject<T>(valor);
		}

		public async Task RemoveFrom(string chave) => await _repository.RemoveAsync(chave);

		public async Task SaveCache(string chave, Object valor, TimeSpan expiracao)
		{
			DistributedCacheEntryOptions options = new DistributedCacheEntryOptions();
			options.SetAbsoluteExpiration(expiracao);
			await _repository.SetStringAsync(chave.Trim(), JsonConvert.SerializeObject(valor), options);
		}

		public async Task SaveCache(string chave, Object valor)
		{
			await _repository.SetStringAsync(chave.Trim(), JsonConvert.SerializeObject(valor));
		}
	}
}