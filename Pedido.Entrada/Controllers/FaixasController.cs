using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Pedido.CasoUso;
using System.Threading.Tasks;

namespace Pedido.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class FaixasController : ControllerBase
	{

		private readonly ILogger<FaixasController> _logger;
		private readonly IListFaixaUseCase _listFaixaUseCase;

		public FaixasController(ILogger<FaixasController> logger, IListFaixaUseCase listFaixaUseCase)
		{
			_logger = logger;
			_listFaixaUseCase = listFaixaUseCase;
		}

		[HttpGet()]
		public async Task<IActionResult> ListFaixasAsync()
		{
			var faixasToReturn = await _listFaixaUseCase.List();
			return Ok(faixasToReturn);
		}
	}
}
