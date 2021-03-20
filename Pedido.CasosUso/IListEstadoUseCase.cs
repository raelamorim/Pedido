using Pedido.CasoUso.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pedido.CasoUso
{
	public interface IListEstadoUseCase
	{
		Task<IEnumerable<ListEstadoResponse>> List();
	}
}