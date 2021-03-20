using Pedido.Modelo.Negocio.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pedido.Modelo.Negocio.Gateways
{
	public interface IVendedorGateway
	{
		Task<IEnumerable<Vendedor>> List(string nome);
	}
}
