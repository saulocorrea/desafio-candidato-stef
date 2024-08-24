namespace PedidoApi.Domain.Entities
{
    public class Produto : EntidadeBase
    {
        public string NomeProduto { get; set; }
        public double Valor { get; set; }
        public virtual ICollection<ItemPedido> ItensPedido { get; set; } = [];
    }
}
