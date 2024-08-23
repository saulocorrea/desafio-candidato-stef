using Ardalis.Specification;
using PedidoApi.Domain.Entities;

namespace PedidoApi.Core.Specifications
{
    public class BuscarPedidoPorIdSpec : Specification<Pedido>
    {
        public BuscarPedidoPorIdSpec(int id)
        {
            Query.Include(p => p.ItensPedido).ThenInclude(i => i.Produto);

            Query.Where(a => a.Id == id);
        }
    }
}
