using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Pedido.CasoUso;
using System.Threading.Tasks;

namespace Pedido.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class ClientesController : ControllerBase
	{

		private readonly ILogger<ClientesController> _logger;
		private readonly IGetClienteUseCase _getClienteUseCase;
		private readonly IListClienteUseCase _listClienteUseCase;

		public ClientesController(ILogger<ClientesController> logger, IGetClienteUseCase getClienteUseCase, IListClienteUseCase listClienteUseCase)
		{
			_logger = logger;
			_getClienteUseCase = getClienteUseCase;
			_listClienteUseCase = listClienteUseCase;
		}

		[HttpGet("{id}", Name = "GetClienteAsync")]
		public async Task<IActionResult> GetClienteAsync(int id)
		{
			var clienteToReturn = await _getClienteUseCase.FindBydId(id);
			return Ok(clienteToReturn);
		}

		[HttpGet()]
		public async Task<IActionResult> ListClientesAsync([FromQuery] string nome = "")
		{
			var clientesToReturn = await _listClienteUseCase.List(nome);
			return Ok(clientesToReturn);
		}
	}
}
