using Microsoft.EntityFrameworkCore;
using Pedido.Modelo.Negocio.Gateways;
using Pedido.Modelo.Negocio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pedido.Infraestrutura.BancoDados.MySql.Repositories
{
	public class EstadoRepository : IEstadoGateway
	{
		private readonly DataContext _context;
		public EstadoRepository(DataContext context)
		{
			this._context = context;
		}

		public async Task<Estado> FindById(string id) => await _context.Estados
			.Include(e => e.Cidades)
			.FirstOrDefaultAsync(e => e.Id == id);

		public async Task<IEnumerable<Estado>> List() => await _context.Estados.OrderBy(e => e.Id).ToListAsync();
	}
}
