using System;
using System.Collections.Generic;
using System.Linq;

namespace PedidosAspNetCore5.Models
{
    public class Pedido
    {
        public int PedidoId { get; set; }
        public int FornecedorId { get; set; }
        public Fornecedor Fornecedor { get; set; }
        public string DataCadastro { get; set; }
        public double Valor { get; set; }
        public ICollection<ItemPedido> Itens { get; set; }
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
                new Pedido { PedidoId = 1, /*Fornecedor = "Maça",*/ DataCadastro = "12/06/2021", Valor = 105.99 });
            Pedido.listagem.Add(
                new Pedido { PedidoId = 2, /*Fornecedor = "Banana",*/ DataCadastro = "12/06/2021", Valor = 1004.99 });
            Pedido.listagem.Add(
                new Pedido { PedidoId = 3, /*Fornecedor = "Abacaxi",*/ DataCadastro = "12/06/2021", Valor = 1003.99 });
            Pedido.listagem.Add(
                new Pedido { PedidoId = 4, /*Fornecedor = "Azeitona",*/ DataCadastro = "12/06/2021", Valor = 1002.99 });
            Pedido.listagem.Add(
                new Pedido { PedidoId = 5, /*Fornecedor = "Acerola",*/ DataCadastro = "12/06/2021", Valor = 1001.99 });
        }

        public static void Salvar(Pedido pedido)
        {
            var pedidoExistente = Pedido.listagem.Find(u => u.PedidoId == pedido.PedidoId);
            if (pedidoExistente != null)
            {
                // pedidoExistente.Fornecedor = pedido.Fornecedor;                
                pedidoExistente.DataCadastro = DateTime.Today.ToString("dd/MM/yyyy");
                pedidoExistente.Valor = pedido.Valor;
            }
            else
            {
                int maiorId = Pedido.Listagem.Max(u => u.PedidoId);
                pedido.PedidoId = maiorId + 1;
                pedido.DataCadastro = DateTime.Today.ToString("dd/MM/yyyy");
                Pedido.listagem.Add(pedido);
            }
        }

        public static void Excluir(int idPedido)
        {
            var pedidoExistente = Pedido.listagem.Find(u => u.PedidoId == idPedido);
            if (pedidoExistente != null)
            {
                Pedido.listagem.Remove(pedidoExistente);
            }
        }

    }
}