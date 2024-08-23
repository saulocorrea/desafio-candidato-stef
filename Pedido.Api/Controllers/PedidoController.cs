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
            try
            {
                var pedidos = _pedidoService.ObterTodos();

                if (pedidos == null)
                {
                    return BadRequest();
                }

                return Ok(pedidos);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao obter lista de pedidos");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet]
        [Route("{idPedido}")]
        [ProducesResponseType(typeof(PedidoDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Get([FromRoute] int idPedido)
        {
            try
            {
                var pedido = _pedidoService.ObterPorId(idPedido);

                if (pedido == null)
                {
                    return BadRequest($"Pedido {idPedido} não encontrado");
                }

                return Ok(pedido);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao obter pedido");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPost]
        [ProducesResponseType(typeof(PedidoDto), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Post([FromBody] InserirPedidoDto pedidoDto)
        {
            try
            {
                var pedido = _pedidoService.Inserir(pedidoDto);

                if (pedido == null)
                {
                    return BadRequest();
                }

                pedido = _pedidoService.ObterPorId(pedido.Id);

                return CreatedAtAction(nameof(Post), pedido);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao inserir produto");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPut]
        [Route("{idPedido}")]
        [ProducesResponseType(typeof(ProdutoDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Put([FromRoute] int idPedido, [FromBody] AlterarPedidoDto pedidoDto)
        {
            try
            {
                var pedido = _pedidoService.Alterar(pedidoDto);

                if (pedido == null)
                {
                    return BadRequest($"Pedido {idPedido} não encontrado");
                }

                return Ok(pedido);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao alterar pedido");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpDelete]
        [Route("{idPedido}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Delete([FromRoute] int idPedido)
        {
            try
            {
                var produto = _pedidoService.Remover(idPedido);

                if (produto == null)
                {
                    return BadRequest();
                }

                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao excluir produto");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
