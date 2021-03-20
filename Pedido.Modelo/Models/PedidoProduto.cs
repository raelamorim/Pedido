using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pedido.Modelo.Negocio.Models
{
	public class PedidoProduto
	{
		public Pedido Pedido { get; set; }
		public Produto Produto { get; set; }
		public int IdPedido { get; set; }
		public int IdProduto { get; set; }
		public int Quantidade { get; set; }
		public decimal SubTotal => Quantidade * Produto.ValorUnitario;
	}
}
