using System;
using System.Collections.Generic;
using System.Text;

namespace Pedido.CasoUso.Dtos
{
	public class ListPedidoResponse
	{
		public int Id { get; set; }
		public ClienteResponse Cliente { get; set; }
		public VendedorResponse Vendedor { get; set; }
		public class ClienteResponse
		{
			public int Id { get; set; }
			public string Nome { get; set; }
		}
		public class VendedorResponse
		{
			public string Id { get; set; }
			public string Nome { get; set; }
		}
	}
}
