using AutoMapper;
using Pedido.CasoUso.Dtos;
using Pedido.Modelo.Negocio.Models;
using System.Linq;

namespace Pedido.CasoUso
{
	public class AutoMapperProfiles : Profile
	{
		public AutoMapperProfiles()
		{
			GetClienteResponse();
			CreateMap<Cliente, ListClienteResponse>();
			CreateMap<Estado, ListEstadoResponse>();
			GetEstadoResponse();
			CreateMap<Faixa, ListFaixaResponse>();
			CreateMap<Unidade, ListUnidadeResponse>();
			ListVendedorResponse();
			ListPedidoResponse();
			GetPedidoResponse();
			PostPedidoRequest();
		}

		private void GetClienteResponse()
		{
			CreateMap<Cidade, GetClienteResponse.CidadeResponse>();
			CreateMap<Estado, GetClienteResponse.EstadoResponse>();
			CreateMap<Cliente, GetClienteResponse>()
				.ForMember(dest => dest.Cidade, opt => opt.MapFrom(src => src.Cidade))
				.ForMember(dest => dest.Estado, opt => opt.MapFrom(src => src.Cidade.Estado));
		}

		private void GetEstadoResponse()
		{
			CreateMap<Cidade, GetEstadoResponse.CidadeResponse>();
			CreateMap<Estado, GetEstadoResponse>()
				.ForMember(dest => dest.Cidades, opt => opt.MapFrom(src => src.Cidades.OrderBy(c => c.Nome))); ;
		}

		private void GetPedidoResponse()
		{
			CreateMap<Cliente, GetPedidoResponse.ClienteResponse>();
			CreateMap<Vendedor, GetPedidoResponse.VendedorResponse>();
			CreateMap<Produto, GetPedidoResponse.ProdutoResponse>();
			CreateMap<PedidoProduto, GetPedidoResponse.ProdutoResponse>()
				.ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Produto.Id))
				.ForMember(dest => dest.Descricao, opt => opt.MapFrom(src => src.Produto.Descricao))
				.ForMember(dest => dest.ValorUnitario, opt => opt.MapFrom(src => src.Produto.ValorUnitario))
				.ForMember(dest => dest.NomeUnidade, opt => opt.MapFrom(src => src.Produto.Unidade.Nome));
			CreateMap<Modelo.Negocio.Models.Pedido, GetPedidoResponse>()
				.ForMember(dest => dest.Cliente, opt => opt.MapFrom(src => src.Cliente))
				.ForMember(dest => dest.Vendedor, opt => opt.MapFrom(src => src.Vendedor))
				.ForPath(dest => dest.Cliente.NomeCidade, opt => opt.MapFrom(src => src.Cliente.Cidade.Nome))
				.ForPath(dest => dest.Cliente.NomeEstado, opt => opt.MapFrom(src => src.Cliente.Cidade.Estado.Nome))
				.ForPath(dest => dest.Cliente.SiglaEstado, opt => opt.MapFrom(src => src.Cliente.Cidade.Estado.Id))
				.ForPath(dest => dest.Vendedor.ValorComissao, opt => opt.MapFrom(src => src.Vendedor.Faixa.ValorComissao))
				.ForMember(dest => dest.Produtos, opt => opt.MapFrom(src => src.PedidoProdutos.OrderBy(pp => pp.IdProduto)));
		}

		private void ListPedidoResponse()
		{
			CreateMap<Cliente, ListPedidoResponse.ClienteResponse>();
			CreateMap<Vendedor, ListPedidoResponse.VendedorResponse>();
			CreateMap<Modelo.Negocio.Models.Pedido, ListPedidoResponse>()
				.ForMember(dest => dest.Cliente, opt => opt.MapFrom(src => src.Cliente))
				.ForMember(dest => dest.Vendedor, opt => opt.MapFrom(src => src.Vendedor));
		}

		private void PostPedidoRequest()
		{
			CreateMap<PostPedidoRequest.ProdutoRequest, PedidoProduto>();
			CreateMap<PostPedidoRequest, Modelo.Negocio.Models.Pedido>()
				.ForMember(dest => dest.PedidoProdutos, opt => opt.MapFrom(src => src.Produtos));
		}

		private void ListVendedorResponse()
		{
			CreateMap<Faixa, ListVendedorResponse.FaixaResponse>();
			CreateMap<Vendedor, ListVendedorResponse>()
				.ForMember(dest => dest.Faixa, opt => opt.MapFrom(src => src.Faixa));
		}
	}
}
