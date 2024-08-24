namespace PedidoApi.Domain.Entities
{
    public class ItemPedido : EntidadeBase
    {
        public int IdPedido { get; set; }
        public int IdProduto { get; set; }
        public int Quantidade { get; set; }
        public virtual Pedido Pedido { get; set; }
        public virtual Produto Produto { get; set; }
    }
}
