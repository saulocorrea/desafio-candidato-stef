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
    }
}
