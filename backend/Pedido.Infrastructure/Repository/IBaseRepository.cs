using Ardalis.Specification;
using PedidoApi.Domain.Entities;

namespace PedidoApi.Infrastructure.Repository
{
    public interface IBaseRepository<TEntity> where TEntity : EntidadeBase, new()
    {
        TEntity Buscar(params object[] keys);

        IList<TEntity> BuscarPorSpec(ISpecification<TEntity> specification);

        void Inserir(TEntity entity);

        void InserirRange(IEnumerable<TEntity> entity);

        void Alterar(TEntity entity);

        void AlterarRange(IEnumerable<TEntity> entity);

        void Remover(TEntity entity);
    }
}
