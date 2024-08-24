using PedidoApi.Core.Dtos;
using PedidoApi.Core.Services.Interface;
using PedidoApi.Core.Specifications;
using PedidoApi.Domain.Entities;
using PedidoApi.Infrastructure.Repository;

namespace PedidoApi.Core.Services
{
    public class ProdutoService : IProdutoService
    {
        private readonly IBaseRepository<Produto> _produtoRepository;

        public ProdutoService(IBaseRepository<Produto> produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        public ProdutoDto ObterPorId(int id)
        {
            var entidade = _produtoRepository.Buscar(id);

            if (entidade == null)
            {
                return null;
            }

            return (ProdutoDto)entidade;
        }

        public IEnumerable<ProdutoDto> ObterTodos()
        {
            var listaEntidades = _produtoRepository.BuscarPorSpec(new BuscarTodosProdutosSpec());

            if (listaEntidades == null)
            {
                return null;
            }

            return listaEntidades.Select(entidade => (ProdutoDto)entidade);
        }

        public ProdutoDto Inserir(CadastroProdutoDto produtoDto)
        {
            var produto = new Produto
            {
                NomeProduto = produtoDto.NomeProduto,
                Valor = produtoDto.Valor,
            };
            _produtoRepository.Inserir(produto);

            return (ProdutoDto)produto;
        }

        public ProdutoDto Alterar(CadastroProdutoDto produtoDto)
        {
            var produto = _produtoRepository.Buscar(produtoDto.Id);

            if (produto == null)
            {
                return null;
            }

            produto.NomeProduto = produtoDto.NomeProduto;
            produto.Valor = produtoDto.Valor;

            _produtoRepository.Alterar(produto);

            return (ProdutoDto)produto;
        }

        public ProdutoDto Remover(int id)
        {
            var produto = _produtoRepository.Buscar(id);

            if (produto == null)
            {
                return null;
            }

            _produtoRepository.Remover(produto);

            return (ProdutoDto)produto;
        }

        public void AdicionarProdutos()
        {
            var produtos = new List<Produto>
            {
                new() { NomeProduto = "Mouse Gamer", Valor = 129.99 },
                new() { NomeProduto = "Teclado Mecânico", Valor = 359.90 },
                new() { NomeProduto = "Monitor LED 24\"", Valor = 899.99 },
                new() { NomeProduto = "SSD 1TB", Valor = 599.90 },
                new() { NomeProduto = "Memória RAM 16GB DDR4", Valor = 389.99 },
                new() { NomeProduto = "Placa de Vídeo GTX 1660", Valor = 1899.90 },
                new() { NomeProduto = "Processador Intel Core i5", Valor = 999.90 },
                new() { NomeProduto = "Placa-Mãe ATX", Valor = 549.99 },
                new() { NomeProduto = "Fonte 600W 80 Plus Bronze", Valor = 349.90 },
                new() { NomeProduto = "Gabinete Gamer", Valor = 499.99 },
                new() { NomeProduto = "Headset com Microfone", Valor = 249.90 },
                new() { NomeProduto = "Webcam Full HD", Valor = 199.99 },
                new() { NomeProduto = "Notebook i7 16GB RAM", Valor = 4599.90 },
                new() { NomeProduto = "Impressora Multifuncional", Valor = 749.99 },
                new() { NomeProduto = "Mousepad Gamer RGB", Valor = 79.90 },
                new() { NomeProduto = "Cooler para CPU", Valor = 119.90 },
                new() { NomeProduto = "Switch de Rede 8 Portas", Valor = 159.99 },
                new() { NomeProduto = "Adaptador USB Wi-Fi", Valor = 59.99 },
                new() { NomeProduto = "Cabo HDMI 2 metros", Valor = 29.99 },
                new() { NomeProduto = "Hub USB 4 portas", Valor = 39.99 }
            };

            _produtoRepository.InserirRange(produtos);
        }
    }
}
