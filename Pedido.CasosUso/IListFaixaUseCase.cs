using Pedido.CasoUso.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pedido.CasoUso
{
	public interface IListFaixaUseCase
	{
		Task<IEnumerable<ListFaixaResponse>> List();
	}
}