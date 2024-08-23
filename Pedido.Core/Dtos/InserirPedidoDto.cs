namespace PedidoApi.Core.Dtos
{
    public class InserirPedidoDto
    {
        public string NomeCliente { get; set; }
        public string EmailCliente { get; set; }
        public bool Pago { get; set; }
        public double ValorTotal { get; set; }
        public IEnumerable<CadastroPedidoItemDto> ItensPedido { get; set; } = [];
    }
}