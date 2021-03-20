using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Pedido.Infraestrutura.BancoDados.MySql.Repositories;
using Pedido.Modelo.Negocio.Gateways;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pedido.Infraestrutura.BancoDados.MySql
{
	public class MySqlServices
	{
		public static void ConfigureServices(IServiceCollection services, IConfiguration Configuration)
		{
			services.AddDbContext<DataContext>(x => x.UseMySql
				   (Configuration.GetConnectionString("MySql")));
			services.AddScoped<IClienteGateway, ClienteRepository>();
			services.AddScoped<IEstadoGateway, EstadoRepository>();
			services.AddScoped<IFaixaGateway, FaixaRepository>();
			services.AddScoped<IPedidoGateway, PedidoRepository>();
			services.AddScoped<IUnidadeGateway, UnidadeRepository>();
			services.AddScoped<IVendedorGateway, VendedorRepository>();
		}
	}
}
