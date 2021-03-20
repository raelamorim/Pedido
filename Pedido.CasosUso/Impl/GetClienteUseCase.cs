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
	public class GetClienteUseCase : IGetClienteUseCase
	{
		private const string CHAVE_CACHE_PARTE_FIXA = "Clientes-FindBydId-";
		private readonly ICacheGateway _cache;
		private readonly IClienteGateway _repository;
		private readonly IMapper _mapper;

		public GetClienteUseCase(IClienteGateway repository, IMapper mapper, ICacheGateway cache)
		{
			_mapper = mapper;
			_repository = repository;
			_cache = cache;
		}

		public async Task<GetClienteResponse> FindBydId(int id)
		{
			var cacheValor = await _cache.GetCacheFrom<GetClienteResponse>(CHAVE_CACHE_PARTE_FIXA + id);

			if (cacheValor == null)
			{
				var cliente = await _repository.FindById(id);
				var clienteToReturn = _mapper.Map<GetClienteResponse>(cliente);
				await _cache.SaveCache(CHAVE_CACHE_PARTE_FIXA + id, clienteToReturn);
				return await Task.FromResult(clienteToReturn);
			}

			return cacheValor;
		}
	}
}
