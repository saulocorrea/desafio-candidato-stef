using PedidoApi.Core.Dtos;

namespace PedidoApi.Core.Services.Interface
{
    public interface IProdutoService
    {
        ProdutoDto ObterPorId(int id);
        IEnumerable<ProdutoDto> ObterTodos();
        ProdutoDto Inserir(CadastroProdutoDto produtoDto);
        ProdutoDto Alterar(CadastroProdutoDto produtoDto);
        ProdutoDto Remover(int id);
    }
}
