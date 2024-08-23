using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PedidoApi.Domain.Entities;

namespace PedidoApi.Infrastructure.Data.Configurations
{
    public partial class PedidoConfiguration : IEntityTypeConfiguration<Pedido>
    {
        public void Configure(EntityTypeBuilder<Pedido> builder)
        {
            builder.ToTable("Pedido");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("Id");

            builder.Property(e => e.NomeCliente)
                .HasMaxLength(60)
                .HasColumnName("NomeCliente");

            builder.Property(e => e.EmailCliente)
                .HasMaxLength(60)
                .HasColumnName("EmailCliente");

            builder.Property(e => e.DataCriacao)
                .HasColumnName("DataCriacao");

            builder.Property(e => e.Pago)
                .HasDefaultValue(false)
                .HasColumnName("Pago");

            builder.HasMany(e => e.ItensPedido)
                .WithOne(e => e.Pedido)
                .HasForeignKey(e => e.IdPedido)
                .OnDelete(DeleteBehavior.Cascade);

            OnConfigurePartial(builder);
        }

        partial void OnConfigurePartial(EntityTypeBuilder<Pedido> builder);
    }
}
