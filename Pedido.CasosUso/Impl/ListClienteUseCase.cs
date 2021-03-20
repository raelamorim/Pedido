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
	public class ListClienteUseCase : IListClienteUseCase
	{
		private const string CHAVE_CACHE_PARTE_FIXA = "Clientes-List-";
		private readonly ICacheGateway _cache;
		private readonly IClienteGateway _repository;
		private readonly IMapper _mapper;

		public ListClienteUseCase(IClienteGateway repository, IMapper mapper, ICacheGateway cache)
		{
			_mapper = mapper;
			_repository = repository;
			_cache = cache;
		}

		public async Task<IEnumerable<ListClienteResponse>> List(string nome)
		{
			var cacheValor = await _cache.GetCacheFrom<IEnumerable<ListClienteResponse>>(CHAVE_CACHE_PARTE_FIXA + nome);

			if (cacheValor == null)
			{
				var clientes = await _repository.List(nome);
				var clienteToReturn = _mapper.Map<IEnumerable<ListClienteResponse>>(clientes);
				await _cache.SaveCache(CHAVE_CACHE_PARTE_FIXA + nome, clienteToReturn, TimeSpan.FromSeconds(30));
				return await Task.FromResult(clienteToReturn);
			}

			return cacheValor;
		}
	}
}
