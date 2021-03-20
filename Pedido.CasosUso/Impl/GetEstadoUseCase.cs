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
	public class GetEstadoUseCase : IGetEstadoUseCase
	{
		private const string CHAVE_CACHE_PARTE_FIXA = "Estados-FindById-";
		private readonly ICacheGateway _cache;
		private readonly IEstadoGateway _repository;
		private readonly IMapper _mapper;

		public GetEstadoUseCase(IEstadoGateway repository, IMapper mapper, ICacheGateway cache)
		{
			_mapper = mapper;
			_repository = repository;
			_cache = cache;
		}

		public async Task<GetEstadoResponse> FindBydId(string id)
		{
			var cacheValor = await _cache.GetCacheFrom<GetEstadoResponse>(CHAVE_CACHE_PARTE_FIXA + id);

			if (cacheValor == null)
			{
				var estado = await _repository.FindById(id);
				var estadoToReturn = _mapper.Map<GetEstadoResponse>(estado);
				await _cache.SaveCache(CHAVE_CACHE_PARTE_FIXA + id, estadoToReturn);
				return await Task.FromResult(estadoToReturn);
			}

			return cacheValor;
		}
	}
}
