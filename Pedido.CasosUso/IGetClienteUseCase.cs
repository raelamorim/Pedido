using Pedido.CasoUso.Dtos;
using System.Threading.Tasks;

namespace Pedido.CasoUso
{
	public interface IGetClienteUseCase
	{
		Task<GetClienteResponse> FindBydId(int id);
	}
}