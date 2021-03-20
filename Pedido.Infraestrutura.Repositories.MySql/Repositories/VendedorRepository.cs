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
	public class VendedorRepository : IVendedorGateway
	{
		private readonly DataContext _context;
		public VendedorRepository(DataContext context)
		{
			this._context = context;
		}

		public async Task<IEnumerable<Vendedor>> List(string nome)
		{
			return nome == string.Empty
				? await _context.Vendedores
					.OrderBy(c => c.Id)
					.ToListAsync()
				: await _context.Vendedores
					.Where(c => c.Nome.Contains(nome))
					.OrderBy(c => c.Id)
					.ToListAsync();
		}
	}
}
