using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Pedido.Modelo.Negocio.Gateways;

namespace Pedido.Infraestrutura.BancoDados.RedisCache
{
	public class RedisServices
	{
		public static void ConfigureServices(IServiceCollection services, IConfiguration Configuration)
		{
			services.AddDistributedRedisCache(options =>
			{
				options.Configuration = Configuration.GetConnectionString("Redis");
				options.InstanceName = "APIPedidos-";
			});
			services.AddScoped<ICacheGateway, CacheService>();
		}
	}
}