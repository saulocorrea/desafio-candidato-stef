using PedidoApi.Domain.Entities;

namespace PedidoApi.Core.Dtos
{
    public class ProdutoDto
    {

        public int Id { get; set; }
        public string NomeProduto { get; set; }
        public double Valor { get; set; }
        
        public static explicit operator ProdutoDto(Produto produto)
        {
            ArgumentNullException.ThrowIfNull(produto, nameof(produto));
            
            return new ProdutoDto
            {
                Id = produto.Id,
                NomeProduto = produto.NomeProduto,
                Valor = produto.Valor,
            };
        }
    }
}
