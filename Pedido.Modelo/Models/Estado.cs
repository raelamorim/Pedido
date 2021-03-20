using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pedido.Modelo.Negocio.Models
{
	public class Estado
	{
		public string Id { get; set; }
		public string Nome { get; set; }
		public List<Cidade> Cidades { get; set; }
	}
}
