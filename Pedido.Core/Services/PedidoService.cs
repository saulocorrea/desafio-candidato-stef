using Microsoft.Extensions.Logging;
using PedidoApi.Core.Dtos;
using PedidoApi.Core.Services.Interface;
using PedidoApi.Core.Specifications;
using PedidoApi.Domain.Entities;
using PedidoApi.Infrastructure.Repository;

namespace PedidoApi.Core.Services
{
    public class PedidoService : IPedidoService
    {
        private readonly ILogger<PedidoService> _logger;
        private readonly IBaseRepository<Pedido> _pedidoRepository;

        public PedidoService(
            //ILogger<PedidoService> logger,
            IBaseRepository<Pedido> pedidoRepository)
        {
            // _logger = logger;
            _pedidoRepository = pedidoRepository;
        }

        public PedidoDto ObterPedidoPorId(int idPedido)
        {
            var pedido = _pedidoRepository.Buscar(idPedido);

            if (pedido == null)
            {
                return null;
            }

            return (PedidoDto)pedido;
        }

        public IEnumerable<PedidoDto> ObterTodos()
        {
            var pedidosDoDia = _pedidoRepository.BuscarPorSpec(new BuscarPedidosDoDiaSpec());

            if (pedidosDoDia == null)
            {
                return null;
            }

            return pedidosDoDia.Select(pedido => (PedidoDto)pedido);
        }

        //public PedidoDto Inserir () { }
    }
}
