using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PedidoApi.Domain.Entities;

namespace PedidoApi.Infrastructure.Data.Configurations
{
    public partial class ProdutoConfiguration : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.ToTable("Produto");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("Id");

            builder.Property(e => e.NomeProduto)
                .HasMaxLength(20)
                .HasColumnName("NomeProduto");

            builder.Property(e => e.Valor)
                .HasColumnName("Valor");

            builder.HasMany(e => e.ItensPedido)
                .WithOne(e => e.Produto)
                .HasForeignKey(e => e.IdProduto)
                .OnDelete(DeleteBehavior.SetNull);

            OnConfigurePartial(builder);
        }

        partial void OnConfigurePartial(EntityTypeBuilder<Produto> builder);
    }
}
