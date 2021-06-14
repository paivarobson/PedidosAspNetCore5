namespace PedidosAspNetCore5.Models
{
    public class ItemPedido
    {
        public int PedidoId { get; set; }
        public Pedido Pedido { get; set; }
        public int ProdutoId { get; set; }
        public Produto Produto { get; set; }
        public int QtdeProduto { get; set; }
        public double PrecoUnitario { get; set; }
        public double ValorTotal { get; set; }

    }
}