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
	public class ListVendedorUseCase : IListVendedorUseCase
	{
		private const string CHAVE_CACHE_PARTE_FIXA = "Vendedores-List-";
		private readonly ICacheGateway _cache;
		private readonly IVendedorGateway _repository;
		private readonly IMapper _mapper;

		public ListVendedorUseCase(IVendedorGateway repository, IMapper mapper, ICacheGateway cache)
		{
			_mapper = mapper;
			_repository = repository;
			_cache = cache;
		}

		public async Task<IEnumerable<ListVendedorResponse>> List(string nome)
		{
			var cacheValor = await _cache.GetCacheFrom<IEnumerable<ListVendedorResponse>>(CHAVE_CACHE_PARTE_FIXA + nome);

			if (cacheValor == null)
			{
				var vendedores = await _repository.List(nome);
				var vendedoresToReturn = _mapper.Map<IEnumerable<ListVendedorResponse>>(vendedores);
				await _cache.SaveCache(CHAVE_CACHE_PARTE_FIXA + nome, vendedoresToReturn, TimeSpan.FromSeconds(30));
				return await Task.FromResult(vendedoresToReturn);
			}

			return cacheValor;
		}
	}
}
