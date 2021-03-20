namespace Pedido.CasoUso.Dtos
{
	public class GetClienteResponse
	{
		public int Id { get; set; }
		public string Nome { get; set; }
		public CidadeResponse Cidade { get; set; }
		public EstadoResponse Estado { get; set; }
		public class CidadeResponse
		{
			public int Id { get; set; }
			public string Nome { get; set; }
		}
		public class EstadoResponse
		{
			public string Id { get; set; }
			public string Nome { get; set; }
		}
	}

}