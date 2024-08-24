using Microsoft.AspNetCore.Mvc;
using PedidoApi.Core.Dtos;
using PedidoApi.Core.Services.Interface;

namespace PedidoApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProdutoController : ControllerBase
    {
        private readonly ILogger<ProdutoController> _logger;
        private readonly IProdutoService _produtoService;

        public ProdutoController(ILogger<ProdutoController> logger, IProdutoService produtoService)
        {
            _logger = logger;
            _produtoService = produtoService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<ProdutoDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Get()
        {
            try
            {
                var produtos = _produtoService.ObterTodos();

                if (produtos == null)
                {
                    return BadRequest();
                }

                return Ok(produtos);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao obter lista de produtos");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet]
        [Route("{idProduto}")]
        [ProducesResponseType(typeof(ProdutoDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Get([FromRoute] int idProduto)
        {
            try
            {
                var produto = _produtoService.ObterPorId(idProduto);

                if (produto == null)
                {
                    return NotFound($"Produto {idProduto} não encontrado");
                }

                return Ok(produto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao obter produto");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPost]
        [ProducesResponseType(typeof(ProdutoDto), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Post([FromBody] CadastroProdutoDto produtoDto)
        {
            try
            {
                var produto = _produtoService.Inserir(produtoDto);

                if (produto == null)
                {
                    return BadRequest();
                }

                return CreatedAtAction(nameof(Post), produto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao inserir produto");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPut]
        [Route("{idProduto}")]
        [ProducesResponseType(typeof(ProdutoDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Put([FromRoute] int idProduto, [FromBody] CadastroProdutoDto produtoDto)
        {
            try
            {
                var produto = _produtoService.Alterar(produtoDto);

                if (produto == null)
                {
                    return NotFound($"Produto {idProduto} não encontrado");
                }

                return Ok(produto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao alterar produto");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpDelete]
        [Route("{idProduto}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Delete([FromRoute] int idProduto)
        {
            try
            {
                var produto = _produtoService.Remover(idProduto);

                if (produto == null)
                {
                    return BadRequest();
                }

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao excluir produto");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
