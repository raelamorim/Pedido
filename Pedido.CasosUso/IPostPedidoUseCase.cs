using Pedido.CasoUso.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pedido.CasoUso
{
	public interface IPostPedidoUseCase
	{
		Task<int> Post(PostPedidoRequest request);
	}
}