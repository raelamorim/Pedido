using Pedido.CasoUso.Dtos;
using System.Threading.Tasks;

namespace Pedido.CasoUso
{
	public interface IGetPedidoUseCase
	{
		Task<GetPedidoResponse> FindBydId(int id);
	}
}