using PedidoApi.Core.Dtos;
using PedidoApi.Core.Services.Interface;
using PedidoApi.Core.Specifications;
using PedidoApi.Domain.Entities;
using PedidoApi.Infrastructure.Repository;

namespace PedidoApi.Core.Services
{
    public class PedidoService : IPedidoService
    {
        private readonly IBaseRepository<Pedido> _pedidoRepository;
        private readonly IBaseRepository<ItemPedido> _itemPedidoRepository;

        public PedidoService(
            IBaseRepository<Pedido> pedidoRepository,
            IBaseRepository<ItemPedido> itmRepository)
        {
            _pedidoRepository = pedidoRepository;
            _itemPedidoRepository = itmRepository;
        }

        public PedidoDto ObterPorId(int idPedido)
        {
            var pedido = _pedidoRepository
                .BuscarPorSpec(new BuscarPedidoPorIdSpec(idPedido))
                .FirstOrDefault();

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

        public PedidoDto Inserir(InserirPedidoDto pedidoDto)
        {
            var pedido = new Pedido
            {
                NomeCliente = pedidoDto.NomeCliente,
                EmailCliente = pedidoDto.EmailCliente,
                Pago = pedidoDto.Pago,
                DataCriacao = DateTime.Now,
                ItensPedido = pedidoDto.ItensPedido.Select(i => new ItemPedido
                {
                    IdProduto = i.IdProduto,
                    Quantidade = i.Quantidade,
                }).ToList()
            };
            _pedidoRepository.Inserir(pedido);

            return (PedidoDto)pedido;
        }

        public PedidoDto Alterar(AlterarPedidoDto pedidoDto)
        {
            var pedido = _pedidoRepository.BuscarPorSpec(new BuscarPedidoPorIdSpec(pedidoDto.Id))
                .FirstOrDefault();

            if (pedido == null)
            {
                return null;
            }

            pedido.Pago = pedidoDto.Pago;
            pedido.NomeCliente = pedidoDto.NomeCliente;
            pedido.EmailCliente = pedidoDto.EmailCliente;

            pedido.ItensPedido.ToList().ForEach(itm =>
            {
                var itmRemover = _itemPedidoRepository.Buscar(itm.Id);

                _itemPedidoRepository.Remover(itmRemover);
            });

            pedido.ItensPedido = pedidoDto.ItensPedido.Select(i => new ItemPedido
            {
                IdPedido = pedidoDto.Id,
                IdProduto = i.IdProduto,
                Quantidade = i.Quantidade,
            }).ToList();

            _pedidoRepository.Alterar(pedido);

            return (PedidoDto)pedido;
        }

        public PedidoDto Remover(int id)
        {
            var pedido = _pedidoRepository.Buscar(id);

            if (pedido == null)
            {
                return null;
            }

            _pedidoRepository.Remover(pedido);

            return (PedidoDto)pedido;
        }

        public bool SetarPedidoPago(int id)
        {
            var pedido = _pedidoRepository.Buscar(id);

            if (pedido == null)
            {
                return false;
            }

            pedido.Pago = true;

            _pedidoRepository.Alterar(pedido);

            return true;
        }
    }
}
