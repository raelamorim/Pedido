using AutoMapper;
using Pedido.Modelo.Negocio.Gateways;
using Pedido.CasoUso;
using Pedido.CasoUso.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pedido.UseCases.Impl
{
	public class ListPedidoUseCase : IListPedidoUseCase
	{
		private const string CHAVE_CACHE_PARTE_FIXA = "Pedidos-List-";
		private readonly ICacheGateway _cache;
		private readonly IPedidoGateway _repository;
		private readonly IMapper _mapper;

		public ListPedidoUseCase(IPedidoGateway repository, IMapper mapper, ICacheGateway cache)
		{
			_mapper = mapper;
			_repository = repository;
			_cache = cache;
		}

		public async Task<IEnumerable<ListPedidoResponse>> List(int idCliente)
		{
			var cacheValor = await _cache.GetCacheFrom<IEnumerable<ListPedidoResponse>>(CHAVE_CACHE_PARTE_FIXA + idCliente);

			if (cacheValor == null)
			{
				var pedidos = await _repository.List(idCliente);
				var pedidosToReturn = _mapper.Map<IEnumerable<ListPedidoResponse>>(pedidos);
				await _cache.SaveCache(CHAVE_CACHE_PARTE_FIXA + idCliente, pedidosToReturn, TimeSpan.FromSeconds(30));
				return await Task.FromResult(pedidosToReturn);
			}

			return cacheValor;
		}
	}
}
