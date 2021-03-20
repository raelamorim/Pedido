using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Pedido.CasoUso;
using System.Threading.Tasks;

namespace Pedido.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class EstadosController : ControllerBase
	{

		private readonly ILogger<EstadosController> _logger;
		private readonly IListEstadoUseCase _listEstadoUseCase;
		private readonly IGetEstadoUseCase _getEstadoUseCase;

		public EstadosController(ILogger<EstadosController> logger, IListEstadoUseCase listEstadoUseCase, IGetEstadoUseCase getEstadoUseCase)
		{
			_logger = logger;
			_listEstadoUseCase = listEstadoUseCase;
			_getEstadoUseCase = getEstadoUseCase;
		}

		[HttpGet()]
		public async Task<IActionResult> ListEstadosAsync()
		{
			var estadosToReturn = await _listEstadoUseCase.List();
			return Ok(estadosToReturn);
		}

		[HttpGet("{id}", Name = "GetEstadoAsync")]
		public async Task<IActionResult> GetEstadoAsync(string id)
		{
			var estadoToReturn = await _getEstadoUseCase.FindBydId(id);
			return Ok(estadoToReturn);
		}
	}
}
