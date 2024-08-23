using Ardalis.Specification;
using PedidoApi.Domain.Entities;

namespace PedidoApi.Core.Specifications
{
    public class BuscarTodosProdutosSpec : Specification<Produto>
    {
        public BuscarTodosProdutosSpec()
        {
            Query.AsNoTracking();
        }
    }
}
