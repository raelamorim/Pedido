using System.Collections.Generic;

namespace Pedido.CasoUso.Dtos
{
	public class GetEstadoResponse
	{
		public string Id { get; set; }
		public string Nome { get; set; }
		public List<CidadeResponse> Cidades { get; set; }
		public class CidadeResponse
		{
			public int Id { get; set; }
			public string Nome { get; set; }
		}
	}
}