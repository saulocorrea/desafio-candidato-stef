namespace PedidoApi.Core.Dtos
{
    public class AlterarPedidoDto
    {
        public int Id { get; set; }
        public string NomeCliente { get; set; }
        public string EmailCliente { get; set; }
        public bool Pago { get; set; }
        public IEnumerable<CadastroPedidoItemDto> ItensPedido { get; set; } = [];
    }
}