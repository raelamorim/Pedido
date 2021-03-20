using Microsoft.EntityFrameworkCore;
using Pedido.Infraestrutura.BancoDados.MySql;
using Pedido.Modelo.Negocio.Gateways;
using Pedido.Modelo.Negocio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pedido.Infraestrutura.BancoDados.MySql.Repositories
{
	public class ClienteRepository : IClienteGateway
	{
		private readonly DataContext _context;
		public ClienteRepository(DataContext context)
		{
			this._context = context;
		}
		public async Task<Cliente> FindById(int id) => await _context.Clientes
			.Include(c => c.Cidade)
			.Include(c => c.Cidade.Estado)
			.FirstOrDefaultAsync(c => c.Id == id);

		public async Task<IEnumerable<Cliente>> List(string nome)
		{
			return nome == string.Empty
				? await _context.Clientes
					.OrderBy(c => c.Id)
					.ToListAsync()
				: await _context.Clientes
					.Where(c => c.Nome.Contains(nome))
					.OrderBy(c => c.Id)
					.ToListAsync();
		}
	}
}
