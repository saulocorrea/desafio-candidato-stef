using Ardalis.Specification;
using PedidoApi.Domain.Entities;

namespace PedidoApi.Core.Specifications
{
    public class BuscarPedidosDoDiaSpec : Specification<Pedido>
    {
        public BuscarPedidosDoDiaSpec()
        {
            Query.AsNoTracking();
            Query.Include(p => p.ItensPedido).ThenInclude(p => p.Produto);

            Query.Where(a => a.DataCriacao.Date == DateTime.Today.Date);
        }
    }
}
