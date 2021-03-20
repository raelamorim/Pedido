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
	public class PostPedidoUseCase : IPostPedidoUseCase
	{
		private readonly IPedidoGateway _repository;
		private readonly IMapper _mapper;

		public PostPedidoUseCase(IPedidoGateway repository, IMapper mapper)
		{
			_mapper = mapper;
			_repository = repository;
		}

		public async Task<int> Post(PostPedidoRequest request)
		{
			var pedidoToSave = _mapper.Map<Modelo.Negocio.Models.Pedido>(request);
			return await _repository.Save(pedidoToSave);
		}
	}
}
