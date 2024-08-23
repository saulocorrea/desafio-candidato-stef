using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using PedidoApi.Domain.Entities;
using PedidoApi.Infrastructure.Data.Configurations;

namespace PedidoApi.Infrastructure.Data
{
    public partial class DesafioDbContext : DbContext
    {
        public DesafioDbContext() { }

        public DesafioDbContext(DbContextOptions<DesafioDbContext> options)
            : base(options) { }

        public virtual DbSet<Pedido> Pedido { get; set; }
        public virtual DbSet<Produto> Produto { get; set; }
        public virtual DbSet<ItemPedido> ItensPedido { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(databaseName: "DesafioDb");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PedidoConfiguration());
            modelBuilder.ApplyConfiguration(new ProdutoConfiguration());
            modelBuilder.ApplyConfiguration(new ItemPedidoConfiguration());

            base.OnModelCreating(modelBuilder);

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
