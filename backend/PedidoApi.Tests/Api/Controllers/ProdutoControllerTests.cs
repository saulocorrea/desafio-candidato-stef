using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NSubstitute;
using PedidoApi.Controllers;
using PedidoApi.Core.Dtos;
using PedidoApi.Core.Services;
using PedidoApi.Core.Services.Interface;

namespace PedidoApi.Tests.Api.Controllers
{
    [TestClass]
    public class ProdutoControllerTests
    {
        private readonly ILogger<ProdutoController> _logger = Substitute.For<ILogger<ProdutoController>>();
        private readonly IProdutoService _produtoService = Substitute.For<IProdutoService>();

        private ProdutoController _produtoController;
        private ProdutoDto _produtoDto;
        private CadastroProdutoDto _cadastroProdutoDto;

        [TestInitialize]
        public void Initialize()
        {
            _produtoController = new ProdutoController(_logger, _produtoService);
            _produtoDto = new ProdutoDto { Id = 1, NomeProduto = "1", Valor = 1 };
            _cadastroProdutoDto = new CadastroProdutoDto { Id = 1, NomeProduto = "1", Valor = 1 };
        }

        [TestMethod]
        public void CriarProdutoComSucesso()
        {
            // Act
            var result = _produtoController.Post(_cadastroProdutoDto);

            // Assert
            result.Should().As<CreatedAtActionResult>();
        }

        [TestMethod]
        public void BuscarListaDeProdutosDeveRetornarSucesso()
        {
            // Arrange
            var produtos = new List<ProdutoDto>() { _produtoDto };

            _produtoService.ObterTodos().Returns(produtos);

            // Act
            var result = _produtoController.Get();

            // Assert
            result.Should().As<OkObjectResult>();
        }

        [TestMethod]
        public void BuscarProdutoEspecificoDeveRetornarSucesso()
        {
            // Arrange
            var idProduto = 1;
            _produtoService.ObterPorId(Arg.Any<int>()).Returns(_produtoDto);

            // Act
            var result = _produtoController.Get(idProduto);

            // Assert
            result.Should().As<OkObjectResult>();
        }

        [TestMethod]
        public void AlterarProdutoDeveRetornarSucesso()
        {
            // Arrange
            var idProduto = 1;
            _produtoService.Alterar(Arg.Any<CadastroProdutoDto>()).Returns(_produtoDto);

            // Act
            var result = _produtoController.Put(idProduto, _cadastroProdutoDto);

            // Assert
            result.Should().As<OkObjectResult>();
        }


        [TestMethod]
        public void DeletarProdutoDeveRetornarSucesso()
        {
            // Arrange
            var idProduto = 1;
            _produtoService.Remover(Arg.Any<int>()).Returns(_produtoDto);

            // Act
            var result = _produtoController.Delete(idProduto);

            // Assert
            result.Should().As<OkObjectResult>();
        }
    }
}
