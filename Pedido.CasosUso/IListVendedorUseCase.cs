using Pedido.CasoUso.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pedido.CasoUso
{
	public interface IListVendedorUseCase
	{
		Task<IEnumerable<ListVendedorResponse>> List(string nome);
	}
}