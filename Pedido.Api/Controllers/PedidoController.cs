using Microsoft.AspNetCore.Mvc;
using PedidoApi.Core.Dtos;
using PedidoApi.Core.Services.Interface;

namespace PedidoApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PedidoController : ControllerBase
    {
        private readonly ILogger<PedidoController> _logger;
        private readonly IPedidoService _pedidoService;

        public PedidoController(ILogger<PedidoController> logger, IPedidoService pedidoService)
        {
            _logger = logger;
            _pedidoService = pedidoService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<PedidoDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Get()
        {
            return Ok(new List<PedidoDto>());
        }

        [HttpGet]
        [Route("{idPedido}")]
        [ProducesResponseType(typeof(IEnumerable<PedidoDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Get([FromRoute] int idPedido)
        {
            var pedido = _pedidoService.ObterPedidoPorId(idPedido);

            if (pedido == null)
            {
                return BadRequest($"Pedido {idPedido} não encontrado");
            }

            return Ok(pedido);
        }
    }
}
