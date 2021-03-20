using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Pedido.CasoUso;
using System.Threading.Tasks;

namespace Pedido.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class VendedoresController : ControllerBase
	{

		private readonly ILogger<ClientesController> _logger;
		private readonly IListVendedorUseCase _listVendedorUseCase;

		public VendedoresController(ILogger<ClientesController> logger, IListVendedorUseCase listVendedorUseCase)
		{
			_logger = logger;
			_listVendedorUseCase = listVendedorUseCase;
		}

		[HttpGet()]
		public async Task<IActionResult> ListVendedoresAsync([FromQuery] string nome = "")
		{
			var vendedoresToReturn = await _listVendedorUseCase.List(nome);
			return Ok(vendedoresToReturn);
		}
	}
}
