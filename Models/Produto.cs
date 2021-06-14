using System;
using System.Collections.Generic;
using System.Linq;

namespace PedidosAspNetCore5.Models
{
    public class Produto
    {
        public int ProdutoId { get; set; }
        public string Descricao { get; set; }
        public string DataCadastro { get; set; }
        public double Preco { get; set; }
        public ICollection<ItemPedido> ItensPedido { get; set; }

        private static List<Produto> listagem = new List<Produto>();
        public static IQueryable<Produto> Listagem
        {
            get
            {
                return listagem.AsQueryable();
            }
        }

        static Produto()
        {
            Produto.listagem.Add(
                new Produto { ProdutoId = 1, Descricao = "Maça", DataCadastro = "12/06/2021", Preco = 5.99 });
            Produto.listagem.Add(
                new Produto { ProdutoId = 2, Descricao = "Banana", DataCadastro = "12/06/2021", Preco = 4.99 });
            Produto.listagem.Add(
                new Produto { ProdutoId = 3, Descricao = "Abacaxi", DataCadastro = "12/06/2021", Preco = 3.99 });
            Produto.listagem.Add(
                new Produto { ProdutoId = 4, Descricao = "Azeitona", DataCadastro = "12/06/2021", Preco = 2.99 });
            Produto.listagem.Add(
                new Produto { ProdutoId = 5, Descricao = "Acerola", DataCadastro = "12/06/2021", Preco = 1.99 });
        }

        public static void Salvar(Produto produto)
        {
            var produtoExistente = Produto.listagem.Find(u => u.ProdutoId == produto.ProdutoId);
            if (produtoExistente != null)
            {
                produtoExistente.Descricao = produto.Descricao;
                produtoExistente.Preco = produto.Preco;
                produtoExistente.DataCadastro = DateTime.Today.ToString("dd/MM/yyyy");
            }
            else
            {
                int maiorId = Produto.Listagem.Max(u => u.ProdutoId);
                produto.ProdutoId = maiorId + 1;
                produto.DataCadastro = DateTime.Today.ToString("dd/MM/yyyy");
                Produto.listagem.Add(produto);
            }
        }

        public static void Excluir(int idProduto)
        {
            var produtoExistente = Produto.listagem.Find(u => u.ProdutoId == idProduto);
            if (produtoExistente != null)
            {
                Produto.listagem.Remove(produtoExistente);
            }
        }

    }
}