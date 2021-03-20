using Pedido.Modelo.Negocio.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pedido.Modelo.Negocio.Gateways
{
	public interface IEstadoGateway
	{
		Task<Estado> FindById(string id);
		Task<IEnumerable<Estado>> List();
	}
}
