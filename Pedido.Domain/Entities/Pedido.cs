namespace PedidoApi.Domain.Entities
{
    public class Pedido : EntidadeBase
    {
        public string NomeCliente { get; set; }
        public string EmailCliente { get; set; }
        public DateTime DataCriacao { get; set; }
        public bool Pago { get; set; }
        public virtual ICollection<ItemPedido> ItensPedido { get; set; } = [];
    }
}
