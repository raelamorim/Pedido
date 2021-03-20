using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Pedido.Modelo.Negocio.Gateways
{
	public interface IPedidoGateway
	{
		Task<Modelo.Negocio.Models.Pedido> FindById(int id);
		Task<int> Save(Models.Pedido pedidoToSave);
		Task<IEnumerable<Modelo.Negocio.Models.Pedido>> List(int idCliente);
	}
}
