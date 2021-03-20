using Pedido.CasoUso.Dtos;
using System.Threading.Tasks;

namespace Pedido.CasoUso
{
	public interface IGetEstadoUseCase
	{
		Task<GetEstadoResponse> FindBydId(string id);
	}
}