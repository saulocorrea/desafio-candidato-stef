using FluentAssertions;
using Microsoft.Extensions.Logging;
using NSubstitute;
using PedidoApi.Core.Dtos;
using PedidoApi.Core.Services;
using PedidoApi.Core.Services.Interface;
using PedidoApi.Domain.Entities;
using PedidoApi.Infrastructure.Repository;

namespace PedidoApi.Tests.Core.Services
{
    [TestClass]
    public class ProdutoServiceTests
    {
        private readonly IBaseRepository<Produto> _produtoRepository = Substitute.For<IBaseRepository<Produto>>();
        private IProdutoService _produtoService;

        [TestInitialize]
        public void Initialize()
        {
            _produtoService = new ProdutoService(_produtoRepository);
        }

        [TestMethod]
        public void InserirProdutoDeveRetornarSucesso()
        {
            // Arrange
            var cadastroDto = new CadastroProdutoDto
            {
                Id = 1,
                NomeProduto = "1",
                Valor = 1
            };
            _produtoRepository.Inserir(Arg.Any<Produto>());

            // Act
            var result = _produtoService.Inserir(cadastroDto);

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void AlterarProdutoDeveRetornarSucesso()
        {
            // Arrange
            var cadastroDto = new CadastroProdutoDto { Id = 1, NomeProduto = "1", Valor = 1 };
            var produto = new Produto { Id = 1, NomeProduto = "1", Valor = 1 };

            _produtoRepository.Buscar(Arg.Any<int>()).Returns(produto);
            _produtoRepository.Alterar(Arg.Any<Produto>());

            // Act
            var result = _produtoService.Alterar(cadastroDto);

            // Assert
            Assert.IsNotNull(result);
        }

    }
}
