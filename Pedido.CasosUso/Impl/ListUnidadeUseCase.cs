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
	public class ListUnidadeUseCase : IListUnidadeUseCase
	{
		private const string CHAVE_CACHE_PARTE_FIXA = "Unidades-List";
		private readonly ICacheGateway _cache;
		private readonly IUnidadeGateway _repository;
		private readonly IMapper _mapper;

		public ListUnidadeUseCase(IUnidadeGateway repository, IMapper mapper, ICacheGateway cache)
		{
			_mapper = mapper;
			_repository = repository;
			_cache = cache;
		}

		public async Task<IEnumerable<ListUnidadeResponse>> List()
		{
			var cacheValor = await _cache.GetCacheFrom<IEnumerable<ListUnidadeResponse>>(CHAVE_CACHE_PARTE_FIXA);

			if (cacheValor == null)
			{
				var unidades = await _repository.List();
				var unidadesToReturn = _mapper.Map<IEnumerable<ListUnidadeResponse>>(unidades);
				await _cache.SaveCache(CHAVE_CACHE_PARTE_FIXA, unidadesToReturn);
				return await Task.FromResult(unidadesToReturn);
			}

			return cacheValor;
		}
	}
}
