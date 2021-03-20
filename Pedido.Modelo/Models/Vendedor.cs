using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pedido.Modelo.Negocio.Models
{
	public class Vendedor
	{
		public int Id { get; set; }
		public string Nome { get; set; }
		public decimal Salario { get; set; }
		public Faixa Faixa { get; set; }
		public int IdFaixa { get; set; }
	}
}
