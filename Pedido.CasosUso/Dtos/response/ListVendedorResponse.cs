namespace Pedido.CasoUso.Dtos
{
	public class ListVendedorResponse
	{
		public int Id { get; set; }
		public string Nome { get; set; }
		public double Salario { get; set; }
		public FaixaResponse Faixa { get; set; }

		public class FaixaResponse
		{
			public int Id { get; set; }
			public double ValorComissao { get; set; }
		}
	}
}
