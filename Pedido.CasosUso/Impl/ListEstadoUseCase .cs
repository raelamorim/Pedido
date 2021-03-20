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
	public class ListEstadoUseCase : IListEstadoUseCase
	{
		private const string CHAVE_CACHE_PARTE_FIXA = "Estados-List";
		private readonly ICacheGateway _cache;
		private readonly IEstadoGateway _repository;
		private readonly IMapper _mapper;

		public ListEstadoUseCase(IEstadoGateway repository, IMapper mapper, ICacheGateway cache)
		{
			_mapper = mapper;
			_repository = repository;
			_cache = cache;
		}

		public async Task<IEnumerable<ListEstadoResponse>> List()
		{
			var cacheValor = await _cache.GetCacheFrom<IEnumerable<ListEstadoResponse>>(CHAVE_CACHE_PARTE_FIXA);

			if (cacheValor == null)
			{
				var estados = await _repository.List();
				var estadosToReturn = _mapper.Map<IEnumerable<ListEstadoResponse>>(estados);
				await _cache.SaveCache(CHAVE_CACHE_PARTE_FIXA, estadosToReturn);
				return await Task.FromResult(estadosToReturn);
			}

			return cacheValor;
		}
	}
}
