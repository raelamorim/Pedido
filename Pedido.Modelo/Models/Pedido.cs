using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pedido.Modelo.Negocio.Models
{
	public class Pedido
	{
		public int Id { get; set; }
		public Cliente Cliente { get; set; }
		public Vendedor Vendedor { get; set; }
		public int IdCliente { get; set; }
		public int IdVendedor { get; set; }
		public List<PedidoProduto> PedidoProdutos { get; set; }
		public decimal ValorTotal => PedidoProdutos.Sum(pp => pp.SubTotal);
	}
}
