using System;
using System.Collections.Generic;
using System.Text;

namespace Pedido.CasoUso.Dtos
{
	public class GetPedidoResponse
	{
		public int Id { get; set; }
		public double ValorTotal { get; set; }
		public ClienteResponse Cliente { get; set; }
		public VendedorResponse Vendedor { get; set; }
		public List<ProdutoResponse> Produtos { get; set; }
		public class ClienteResponse
		{
			public int Id { get; set; }
			public string Nome { get; set; }
			public string NomeCidade { get; set; }
			public string SiglaEstado { get; set; }
			public string NomeEstado { get; set; }
		}
		public class VendedorResponse
		{
			public int Id { get; set; }
			public string Nome { get; set; }
			public double ValorComissao { get; set; }
		}
		public class ProdutoResponse
		{
			public int Id { get; set; }
			public string Descricao { get; set; }
			public int Quantidade { get; set; }
			public decimal ValorUnitario { get; set; }
			public string NomeUnidade { get; set; }
			public double Subtotal { get; set; }
		}
	}
}
