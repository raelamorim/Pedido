using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Pedido.CasoUso;
using System.Threading.Tasks;

namespace Pedido.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class UnidadesController : ControllerBase
	{

		private readonly ILogger<UnidadesController> _logger;
		private readonly IListUnidadeUseCase _listUnidadeUseCase;

		public UnidadesController(ILogger<UnidadesController> logger, IListUnidadeUseCase listUnidadeUseCase)
		{
			_logger = logger;
			_listUnidadeUseCase = listUnidadeUseCase;
		}

		[HttpGet()]
		public async Task<IActionResult> ListUnidadesAsync()
		{
			var unidadesToReturn = await _listUnidadeUseCase.List();
			return Ok(unidadesToReturn);
		}
	}
}
