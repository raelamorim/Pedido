using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pedido.Modelo.Negocio.Models
{
	public class Cliente
	{
		public int Id { get; set; }
		public string Nome { get; set; }
		public Cidade Cidade { get; set; }
		public int IdCidade { get; set; }
	}
}
