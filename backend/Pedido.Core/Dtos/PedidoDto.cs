using PedidoApi.Domain.Entities;

namespace PedidoApi.Core.Dtos
{
    public class PedidoDto
    {

        public int Id { get; set; }
        public string NomeCliente { get; set; }
        public string EmailCliente { get; set; }
        public bool Pago { get; set; }
        public double ValorTotal { get; set; }
        public IEnumerable<ItemPedidoDto> ItensPedido { get; set; } = [];

        public static explicit operator PedidoDto(Pedido pedido)
        {
            ArgumentNullException.ThrowIfNull(pedido, nameof(pedido));
            
            return new PedidoDto
            {
                Id = pedido.Id,
                NomeCliente = pedido.NomeCliente,
                EmailCliente = pedido.EmailCliente,
                Pago = pedido.Pago,
                ItensPedido = pedido.ItensPedido.Select(i => new ItemPedidoDto
                {
                    Id = i.Id,
                    IdProduto = i.IdProduto,
                    NomeProduto = i.Produto?.NomeProduto,
                    Quantidade = i.Quantidade,
                    ValorUnitario = i.Produto?.Valor ?? 0,
                }),
                ValorTotal = pedido.ItensPedido.Sum(x => x.Quantidade * x.Produto?.Valor ?? 0),
            };
        }
    }
}
