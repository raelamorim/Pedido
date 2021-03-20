using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pedido.Modelo.Negocio.Models
{
	public class Produto
	{
		public int Id { get; set; }
		public string Descricao { get; set; }
		public decimal ValorUnitario { get; set; }
		public Unidade Unidade { get; set; }
		public int IdUnidade { get; set; }
		public List<PedidoProduto> PedidoProdutos { get; set; }
	}
}
