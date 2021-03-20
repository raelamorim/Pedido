using Microsoft.EntityFrameworkCore;
using Pedido.Infraestrutura.BancoDados.MySql.Seed;
using Pedido.Modelo.Negocio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pedido.Infraestrutura.BancoDados.MySql
{
	public class DataContext : DbContext
	{
		public DataContext(DbContextOptions<DataContext> options) : base(options)
		{
			this.Database.EnsureCreated();
		}
		public DbSet<Cidade> Cidades { get; set; }
		public DbSet<Cliente> Clientes { get; set; }
		public DbSet<Estado> Estados { get; set; }
		public DbSet<Faixa> Faixas { get; set; }
		public DbSet<Modelo.Negocio.Models.Pedido> Pedidos { get; set; }
		public DbSet<PedidoProduto> PedidoProdutos { get; set; }
		public DbSet<Produto> Produtos { get; set; }
		public DbSet<Unidade> Unidades { get; set; }
		public DbSet<Vendedor> Vendedores { get; set; }

		protected override void OnModelCreating(ModelBuilder builder)
		{
			MapeiaCidade(builder);
			MapeiaCliente(builder);
			MapeiaEstado(builder);
			MapeiaFaixa(builder);
			MapeiaPedido(builder);
			MapeiaProduto(builder);
			MapeiaPedidoProduto(builder);
			MapeiaUnidade(builder);
			MapeiaVendedor(builder);
		}

		#region Seed
		public void Seed()
		{
			if (!Estados.Any())
			{
				AddRange(DataSeeder.SeedEstados());
				SaveChanges();
			}

			if (!Cidades.Any())
			{
				AddRange(DataSeeder.SeedCidades());
				SaveChanges();
			}

			if (!Unidades.Any())
			{
				AddRange(DataSeeder.SeedUnidades());
				SaveChanges();
			}

			if (!Faixas.Any())
			{
				AddRange(DataSeeder.SeedFaixas());
				SaveChanges();
			}

			if (!Clientes.Any())
			{
				AddRange(DataSeeder.SeedClientes());
				SaveChanges();
			}

			if (!Vendedores.Any())
			{
				AddRange(DataSeeder.SeedVendedores());
				SaveChanges();
			}

			if (!Produtos.Any())
			{
				AddRange(DataSeeder.SeedProdutos());
				SaveChanges();
			}

			if (!Pedidos.Any())
			{
				AddRange(DataSeeder.SeedPedidos());
				SaveChanges();
			}

			if (!PedidoProdutos.Any())
			{
				AddRange(DataSeeder.SeedPedidosProdutos());
				SaveChanges();
			}
		}
		#endregion

		#region Cidade
		private static void MapeiaCidade(ModelBuilder builder)
		{
			builder.Entity<Cidade>()
				.ToTable("cidade");

			builder.Entity<Cidade>()
				.Property(p => p.Id)
				.HasColumnName("id_cidade");

			builder.Entity<Cidade>()
				.Property(p => p.Nome)
				.HasColumnName("nome")
				.HasColumnType("varchar(100)");

			builder.Entity<Cidade>()
				.Property(p => p.IdEstado)
				.HasColumnName("id_estado");

			builder.Entity<Cidade>()
				.HasOne(c => c.Estado)
				.WithMany(e => e.Cidades)
				.HasForeignKey(f => f.IdEstado);

			builder.Entity<Cidade>()
				.HasKey(k => new { k.Id });
		}
		#endregion

		#region Cliente
		private static void MapeiaCliente(ModelBuilder builder)
		{
			builder.Entity<Cliente>()
				.ToTable("cliente");

			builder.Entity<Cliente>()
				.Property(p => p.Id)
				.HasColumnName("id_cliente");

			builder.Entity<Cliente>()
				.Property(p => p.Nome)
				.HasColumnName("nome")
				.HasColumnType("varchar(100)");

			builder.Entity<Cliente>()
				.Property(p => p.IdCidade)
				.HasColumnName("id_cidade");

			builder.Entity<Cliente>()
				.HasOne(c => c.Cidade)
				.WithMany()
				.HasForeignKey(f => f.IdCidade);

			builder.Entity<Cliente>()
				.HasKey(k => new { k.Id });
		}
		#endregion

	    #region Estado
		private static void MapeiaEstado(ModelBuilder builder)
		{
			builder.Entity<Estado>()
				.ToTable("estado");

			builder.Entity<Estado>()
				.Property(p => p.Id)
				.HasColumnName("id_estado")
				.HasColumnType("char(2)");

			builder.Entity<Estado>()
				.Property(p => p.Nome)
				.HasColumnName("nome")
				.HasColumnType("varchar(100)");

			builder.Entity<Estado>()
				.HasKey(k => new { k.Id });
		}
		#endregion

		#region Faixa
		private static void MapeiaFaixa(ModelBuilder builder)
		{
			builder.Entity<Faixa>()
				.ToTable("faixa");

			builder.Entity<Faixa>()
				.Property(p => p.Id)
				.HasColumnName("id_faixa");

			builder.Entity<Faixa>()
				.Property(p => p.ValorComissao)
				.HasColumnName("valor_comissao")
				.HasColumnType("double");

			builder.Entity<Faixa>()
							.HasKey(k => new { k.Id });
		}
		#endregion

		#region Pedido
		private static void MapeiaPedido(ModelBuilder builder)
		{
			builder.Entity<Modelo.Negocio.Models.Pedido>()
				.ToTable("pedido");

			builder.Entity<Modelo.Negocio.Models.Pedido>()
				.Property(p => p.Id)
				.HasColumnName("id_pedido");

			builder.Entity<Modelo.Negocio.Models.Pedido>()
				.Property(p => p.IdCliente)
				.HasColumnName("id_cliente");

			builder.Entity<Modelo.Negocio.Models.Pedido>()
				.Property(p => p.IdVendedor)
				.HasColumnName("id_vendedor");

			builder.Entity<Modelo.Negocio.Models.Pedido>()
				.HasOne(c => c.Cliente)
				.WithMany()
				.HasForeignKey(f => f.IdCliente);

			builder.Entity<Modelo.Negocio.Models.Pedido>()
				.HasOne(v => v.Vendedor)
				.WithMany()
				.HasForeignKey(f => f.IdVendedor);

			builder.Entity<Modelo.Negocio.Models.Pedido>()
				.HasKey(k => new { k.Id });
		}
		#endregion

		#region PedidoProduto
		private static void MapeiaPedidoProduto(ModelBuilder builder)
		{
			builder.Entity<PedidoProduto>()
				.ToTable("pedido_produto");

			builder.Entity<PedidoProduto>()
				.Property(p => p.IdPedido)
				.HasColumnName("id_pedido")
				.IsRequired();

			builder.Entity<PedidoProduto>()
				.Property(p => p.IdProduto)
				.HasColumnName("id_produto")
				.IsRequired();

			builder.Entity<PedidoProduto>()
				.Property(p => p.Quantidade)
				.HasColumnName("quantidade");

			builder.Entity<PedidoProduto>()
				.HasOne(c => c.Pedido)
				.WithMany(pp => pp.PedidoProdutos)
				.HasForeignKey(f => f.IdPedido);

			builder.Entity<PedidoProduto>()
				.HasOne(c => c.Produto)
				.WithMany(pp => pp.PedidoProdutos)
				.HasForeignKey(f => f.IdProduto);

			builder.Entity<PedidoProduto>()
				.HasKey(k => new { k.IdPedido, k.IdProduto });
		}
		#endregion

		#region Produto
		private static void MapeiaProduto(ModelBuilder builder)
		{
			builder.Entity<Produto>()
				.ToTable("produto");

			builder.Entity<Produto>()
				.Property(p => p.Id)
				.HasColumnName("id_produto");

			builder.Entity<Produto>()
				.Property(p => p.Descricao)
				.HasColumnName("descricao")
				.HasColumnType("varchar(100)");

			builder.Entity<Produto>()
				.Property(p => p.ValorUnitario)
				.HasColumnName("valor_unitario")
				.HasColumnType("double");

			builder.Entity<Produto>()
				.Property(p => p.IdUnidade)
				.HasColumnName("id_unidade");

			builder.Entity<Produto>()
				.HasOne(c => c.Unidade)
				.WithMany()
				.HasForeignKey(f => f.IdUnidade);

			builder.Entity<Produto>()
							.HasKey(k => new { k.Id });
		}
		#endregion

		#region Unidade
		private static void MapeiaUnidade(ModelBuilder builder)
		{
			builder.Entity<Unidade>()
				.ToTable("unidade");

			builder.Entity<Unidade>()
				.Property(p => p.Id)
				.HasColumnName("id_unidade");

			builder.Entity<Unidade>()
				.Property(p => p.Nome)
				.HasColumnName("descricao")
				.HasColumnType("varchar(20)");

			builder.Entity<Unidade>()
							.HasKey(k => new { k.Id });
		}
		#endregion
		
		#region Vendedor
		private static void MapeiaVendedor(ModelBuilder builder)
		{
			builder.Entity<Vendedor>()
				.ToTable("vendedor");

			builder.Entity<Vendedor>()
				.Property(p => p.Id)
				.HasColumnName("id_vendedor");

			builder.Entity<Vendedor>()
				.Property(p => p.Nome)
				.HasColumnName("nome")
				.HasColumnType("varchar(100)");

			builder.Entity<Vendedor>()
				.Property(p => p.Salario)
				.HasColumnName("salario")
				.HasColumnType("double");

			builder.Entity<Vendedor>()
				.Property(p => p.IdFaixa)
				.HasColumnName("id_faixa");

			builder.Entity<Vendedor>()
				.HasOne(v => v.Faixa)
				.WithMany()
				.HasForeignKey(f => f.IdFaixa);

			builder.Entity<Vendedor>()
							.HasKey(k => new { k.Id });
		}
		#endregion
	}
}
