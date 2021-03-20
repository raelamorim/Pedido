using System;
using System.Collections.Generic;
using System.Text;

namespace Pedido.CasoUso.Dtos
{
	public class PostPedidoRequest
	{
		public int IdCliente { get; set; }
		public string IdVendedor { get; set; }
		public List<ProdutoRequest> Produtos { get; set; }
		public class ProdutoRequest
		{
			public int IdProduto { get; set; }
			public int Quantidade { get; set; }
		}
	}

}
