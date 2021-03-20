using Microsoft.EntityFrameworkCore;
using Pedido.Modelo.Negocio.Gateways;
using Pedido.Modelo.Negocio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pedido.Infraestrutura.BancoDados.MySql.Repositories
{
	public class FaixaRepository : IFaixaGateway
	{
		private readonly DataContext _context;
		public FaixaRepository(DataContext context)
		{
			this._context = context;
		}
		public async Task<IEnumerable<Faixa>> List() => await _context.Faixas.OrderBy(f => f.ValorComissao).ToListAsync();
	}
}
