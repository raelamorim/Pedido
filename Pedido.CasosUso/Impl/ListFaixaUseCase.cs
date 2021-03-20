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
	public class ListFaixaUseCase : IListFaixaUseCase
	{
		private const string CHAVE_CACHE_PARTE_FIXA = "Faixas-List";
		private readonly ICacheGateway _cache;
		private readonly IFaixaGateway _repository;
		private readonly IMapper _mapper;

		public ListFaixaUseCase(IFaixaGateway repository, IMapper mapper, ICacheGateway cache)
		{
			_mapper = mapper;
			_repository = repository;
			_cache = cache;
		}

		public async Task<IEnumerable<ListFaixaResponse>> List()
		{
			var cacheValor = await _cache.GetCacheFrom<IEnumerable<ListFaixaResponse>>(CHAVE_CACHE_PARTE_FIXA);

			if (cacheValor == null)
			{
				var faixas = await _repository.List();
				var faixasToReturn = _mapper.Map<IEnumerable<ListFaixaResponse>>(faixas);
				await _cache.SaveCache(CHAVE_CACHE_PARTE_FIXA, faixasToReturn);
				return await Task.FromResult(faixasToReturn);
			}

			return cacheValor;
		}
	}
}
