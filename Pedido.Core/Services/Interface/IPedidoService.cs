using PedidoApi.Core.Dtos;

namespace PedidoApi.Core.Services.Interface
{
    public interface IPedidoService
    {
        IEnumerable<PedidoDto> ObterTodos();
        PedidoDto ObterPorId(int idPedido);
        PedidoDto Inserir(InserirPedidoDto pedidoDto);
        PedidoDto Alterar(AlterarPedidoDto pedidoDto);
        PedidoDto Remover(int id);
    }
}
