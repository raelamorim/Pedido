using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Pedido.UseCases.Impl;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pedido.CasoUso
{
	public class CasoUsoServices
	{
		public static void ConfigureServices(IServiceCollection services)
		{
			var mappingConfig = new MapperConfiguration(mc =>
			{
				mc.AddProfile(new AutoMapperProfiles());
			});
			IMapper mapper = mappingConfig.CreateMapper();
			services.AddSingleton(mapper);
			services.AddScoped<IGetClienteUseCase, GetClienteUseCase>();
			services.AddScoped<IListClienteUseCase, ListClienteUseCase>();
			services.AddScoped<IGetEstadoUseCase, GetEstadoUseCase>();
			services.AddScoped<IListEstadoUseCase, ListEstadoUseCase>();
			services.AddScoped<IListFaixaUseCase, ListFaixaUseCase>();
			services.AddScoped<IListUnidadeUseCase, ListUnidadeUseCase>();
			services.AddScoped<IGetPedidoUseCase, GetPedidoUseCase>();
			services.AddScoped<IListPedidoUseCase, ListPedidoUseCase>();
			services.AddScoped<IListVendedorUseCase, ListVendedorUseCase>();
			services.AddScoped<IPostPedidoUseCase, PostPedidoUseCase>();
		}
	}
}
