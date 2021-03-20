using Microsoft.EntityFrameworkCore;
using Pedido.Modelo.Negocio.Gateways;
using Pedido.Modelo.Negocio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pedido.Infraestrutura.BancoDados.MySql.Repositories
{
	public class UnidadeRepository : IUnidadeGateway
	{
		private readonly DataContext _context;
		public UnidadeRepository(DataContext context)
		{
			this._context = context;
		}

		public async Task<IEnumerable<Unidade>> List() => await _context.Unidades.OrderBy(u => u.Nome).ToListAsync();
	}
}
