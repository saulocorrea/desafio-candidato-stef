using PedidoApi.Core.Dtos;

namespace PedidoApi.Core.Services.Interface
{
    public interface IPedidoService
    {
        IEnumerable<PedidoDto> ObterTodos();
        PedidoDto ObterPedidoPorId(int idPedido);
    }
}
