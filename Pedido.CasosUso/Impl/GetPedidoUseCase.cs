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
	public class GetPedidoUseCase : IGetPedidoUseCase
	{
		private const string CHAVE_CACHE_PARTE_FIXA = "Pedidos-FindBydId-";
		private readonly ICacheGateway _cache;
		private readonly IPedidoGateway _repository;
		private readonly IMapper _mapper;

		public GetPedidoUseCase(IPedidoGateway repository, IMapper mapper, ICacheGateway cache)
		{
			_mapper = mapper;
			_repository = repository;
			_cache = cache;
		}

		public async Task<GetPedidoResponse> FindBydId(int id)
		{
			var cacheValor = await _cache.GetCacheFrom<GetPedidoResponse>(CHAVE_CACHE_PARTE_FIXA + id);

			if (cacheValor == null)
			{
				var pedido = await _repository.FindById(id);
				var pedidoToReturn = _mapper.Map<GetPedidoResponse>(pedido);
				await _cache.SaveCache(CHAVE_CACHE_PARTE_FIXA + id, pedidoToReturn, TimeSpan.FromSeconds(30));
				return await Task.FromResult(pedidoToReturn);
			}

			return cacheValor;
		}
	}
}
