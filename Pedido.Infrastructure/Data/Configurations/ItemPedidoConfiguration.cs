using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PedidoApi.Domain.Entities;

namespace PedidoApi.Infrastructure.Data.Configurations
{
    public partial class ItemPedidoConfiguration : IEntityTypeConfiguration<ItemPedido>
    {
        public void Configure(EntityTypeBuilder<ItemPedido> builder)
        {
            builder.ToTable("ItensPedido");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("Id");

            builder.Property(e => e.IdPedido)
                .HasColumnName("IdPedido");

            builder.Property(e => e.IdProduto)
                .HasColumnName("IdProduto");

            builder.Property(e => e.Quantidade)
                .HasColumnName("Quantidade");

            builder.HasOne(e => e.Pedido)
                .WithMany(e => e.ItensPedido)
                .HasForeignKey(e => e.IdPedido);

            builder.HasOne(e => e.Produto)
                .WithMany(e => e.ItensPedido)
                .HasForeignKey(e => e.IdProduto);

            OnConfigurePartial(builder);
        }

        partial void OnConfigurePartial(EntityTypeBuilder<ItemPedido> builder);
    }
}
