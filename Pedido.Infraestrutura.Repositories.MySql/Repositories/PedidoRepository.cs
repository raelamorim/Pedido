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
	public class PedidoRepository : IPedidoGateway
	{
		private readonly DataContext _context;
		public PedidoRepository(DataContext context)
		{
			this._context = context;
		}

		public async Task<IEnumerable<Modelo.Negocio.Models.Pedido>> List(int idCliente) => await _context.Pedidos
			.Include(p => p.Cliente)
			.Include(p => p.Vendedor)
			.OrderBy(p => p.Id)
			.Where(p => p.IdCliente == idCliente)
			.ToListAsync();

		public async Task<Modelo.Negocio.Models.Pedido> FindById(int id) => await _context.Pedidos
			.Include(p => p.Cliente)
			.Include(p => p.Cliente.Cidade)
			.Include(p => p.Cliente.Cidade.Estado)
			.Include(p => p.Vendedor)
			.Include(p => p.Vendedor.Faixa)
			.Include(p => p.PedidoProdutos)
			.ThenInclude(pp => pp.Produto)
			.ThenInclude(p => p.Unidade)
			.OrderBy(p => p.Id)
			.FirstOrDefaultAsync(p => p.Id == id);

		public async Task<int> Save(Modelo.Negocio.Models.Pedido pedidoToSave)
		{
			await _context.Pedidos.AddAsync(pedidoToSave);
			await _context.SaveChangesAsync();
			return pedidoToSave.Id;
		}
	}
}
