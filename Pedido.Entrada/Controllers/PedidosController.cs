using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Pedido.CasoUso;
using Pedido.CasoUso.Dtos;
using System.Threading.Tasks;

namespace Pedido.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class PedidosController : ControllerBase
	{

		private readonly ILogger<PedidosController> _logger;
		private readonly IGetPedidoUseCase _getPedidoUseCase;
		private readonly IListPedidoUseCase _listPedidoUseCase;
		private readonly IPostPedidoUseCase _postPedidoUseCase;

		public PedidosController(ILogger<PedidosController> logger, IGetPedidoUseCase getPedidoUseCase, IListPedidoUseCase listPedidoUseCase, IPostPedidoUseCase postPedidoUseCase)
		{
			_logger = logger;
			_getPedidoUseCase = getPedidoUseCase;
			_listPedidoUseCase = listPedidoUseCase;
			_postPedidoUseCase = postPedidoUseCase;
		}

		[HttpPost]
		public async Task<IActionResult> PostPedidoAsync(PostPedidoRequest request)
		{
			var idPedido = await _postPedidoUseCase.Post(request);
			return Created($"pedidos/{idPedido}", "Pedido criado com sucesso!");
		}

		[HttpGet("{id}", Name = "GetPedidoAsync")]
		public async Task<IActionResult> GetPedidoAsync(int id)
		{
			var pedidoToReturn = await _getPedidoUseCase.FindBydId(id);
			return Ok(pedidoToReturn);
		}

		[HttpGet()]
		public async Task<IActionResult> ListPedidosAsync([FromQuery] int idCliente)
		{
			var pedidosToReturn = await _listPedidoUseCase.List(idCliente);
			return Ok(pedidosToReturn);
		}
	}
}
