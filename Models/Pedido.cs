using System;
using System.Collections.Generic;
using System.Linq;

namespace PedidosAspNetCore5.Models
{
    public class Pedido
    {
        public int IdPedido { get; set; }
        public string DataCadastro { get; set; }
        // public string Produto { get; set; }
        // public int QtdeProduto { get; set; }
        // public string Fornecedor { get; set; }
        public double ValorTotal { get; set; }

        private static List<Pedido> listagem = new List<Pedido>();
        public static IQueryable<Pedido> Listagem
        {
            get
            {
                return listagem.AsQueryable();
            }
        }

        static Pedido()
        {
            Produto produto = new Produto();

            Pedido.listagem.Add(
                new Pedido { IdPedido = 1, /*Fornecedor = "Maça",*/ DataCadastro = "12/06/2021", ValorTotal = 105.99 });
            Pedido.listagem.Add(
                new Pedido { IdPedido = 2, /*Fornecedor = "Banana",*/ DataCadastro = "12/06/2021", ValorTotal = 1004.99 });
            Pedido.listagem.Add(
                new Pedido { IdPedido = 3, /*Fornecedor = "Abacaxi",*/ DataCadastro = "12/06/2021", ValorTotal = 1003.99 });
            Pedido.listagem.Add(
                new Pedido { IdPedido = 4, /*Fornecedor = "Azeitona",*/ DataCadastro = "12/06/2021", ValorTotal = 1002.99 });
            Pedido.listagem.Add(
                new Pedido { IdPedido = 5, /*Fornecedor = "Acerola",*/ DataCadastro = "12/06/2021", ValorTotal = 1001.99 });
        }

        public static void Salvar(Pedido pedido)
        {
            var pedidoExistente = Pedido.listagem.Find(u => u.IdPedido == pedido.IdPedido);
            if (pedidoExistente != null)
            {
                // pedidoExistente.Fornecedor = pedido.Fornecedor;                
                pedidoExistente.DataCadastro = DateTime.Today.ToString("dd/MM/yyyy");
                pedidoExistente.ValorTotal = pedido.ValorTotal;
            }
            else
            {
                int maiorId = Pedido.Listagem.Max(u => u.IdPedido);
                pedido.IdPedido = maiorId + 1;
                pedido.DataCadastro = DateTime.Today.ToString("dd/MM/yyyy");
                Pedido.listagem.Add(pedido);
            }
        }

        public static void Excluir(int idPedido)
        {
            var pedidoExistente = Pedido.listagem.Find(u => u.IdPedido == idPedido);
            if (pedidoExistente != null)
            {
                Pedido.listagem.Remove(pedidoExistente);
            }
        }

    }
}