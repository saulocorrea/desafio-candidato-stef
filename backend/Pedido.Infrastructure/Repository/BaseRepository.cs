using Ardalis.Specification;
using Ardalis.Specification.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PedidoApi.Domain.Entities;
using PedidoApi.Infrastructure.Data;

namespace PedidoApi.Infrastructure.Repository
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity>
        where TEntity : EntidadeBase, new()
    {
        protected readonly DbContext _dbContext;
        protected readonly DbSet<TEntity> _dbSet;

        public BaseRepository(DesafioDbContext dbContext)
            : this(dbContext, SpecificationEvaluator.Default)
        {

        }

        public BaseRepository(DesafioDbContext dbContext, ISpecificationEvaluator specificationEvaluator)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<TEntity>();
        }

        public TEntity Buscar(params object[] keys)
        {
            return _dbSet.Find(keys);
        }

        public IList<TEntity> BuscarPorSpec(ISpecification<TEntity> specification)
        {
            return SpecificationEvaluator.Default
                .GetQuery(_dbSet.AsQueryable(), specification)
                .ToList();
        }

        public void Remover(TEntity entity)
        {
            _dbSet.Remove(entity);
            _dbContext.SaveChanges();
        }

        public void Inserir(TEntity entity)
        {
            _dbSet.Add(entity);
            _dbContext.SaveChanges();
        }

        public void InserirRange(IEnumerable<TEntity> entity)
        {
            _dbSet.AddRange(entity);
            _dbContext.SaveChanges();
        }

        public void Alterar(TEntity entity)
        {
            _dbSet.Update(entity);
            _dbContext.SaveChanges();
        }

        public void AlterarRange(IEnumerable<TEntity> entity)
        {
            _dbSet.UpdateRange(entity);
            _dbContext.SaveChanges();
        }
    }
}
