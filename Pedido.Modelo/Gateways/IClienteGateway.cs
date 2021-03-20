using Pedido.Modelo.Negocio.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pedido.Modelo.Negocio.Gateways
{
	public interface IClienteGateway
	{
		Task<Cliente> FindById(int id);
		Task<IEnumerable<Cliente>> List(string nome);
	}
}
