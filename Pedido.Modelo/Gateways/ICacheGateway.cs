using Pedido.Modelo.Negocio.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pedido.Modelo.Negocio.Gateways
{
	public interface ICacheGateway
	{
		Task<T> GetCacheFrom<T>(string chave);
		Task RemoveFrom(string chave);
		Task SaveCache(string chave, Object valor, TimeSpan expiracao);
		Task SaveCache(string chave, Object valor);
	}
}
