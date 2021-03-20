using Pedido.CasoUso.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pedido.CasoUso
{
	public interface IListUnidadeUseCase
	{
		Task<IEnumerable<ListUnidadeResponse>> List();
	}
}