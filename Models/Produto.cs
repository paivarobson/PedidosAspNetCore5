using System;
using System.Collections.Generic;
using System.Linq;

namespace PedidosAspNetCore5.Models
{
    public class Produto
    {
        public int IdProduto { get; set; }
        public string Descricao { get; set; }
        public string DataCadastro { get; set; }
        public double Valor { get; set; }

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
                new Produto { IdProduto = 1, Descricao = "Maça", DataCadastro = "12/06/2021", Valor = 5.99 });
            Produto.listagem.Add(
                new Produto { IdProduto = 2, Descricao = "Banana", DataCadastro = "12/06/2021", Valor = 4.99 });
            Produto.listagem.Add(
                new Produto { IdProduto = 3, Descricao = "Abacaxi", DataCadastro = "12/06/2021", Valor = 3.99 });
            Produto.listagem.Add(
                new Produto { IdProduto = 4, Descricao = "Azeitona", DataCadastro = "12/06/2021", Valor = 2.99 });
            Produto.listagem.Add(
                new Produto { IdProduto = 5, Descricao = "Acerola", DataCadastro = "12/06/2021", Valor = 1.99 });
        }

        public static void Salvar(Produto produto)
        {
            var produtoExistente = Produto.listagem.Find(u => u.IdProduto == produto.IdProduto);
            if (produtoExistente != null)
            {
                produtoExistente.Descricao = produto.Descricao;
                produtoExistente.Valor = produto.Valor;
                produtoExistente.DataCadastro = DateTime.Today.ToString("dd/MM/yyyy");
            }
            else
            {
                int maiorId = Produto.Listagem.Max(u => u.IdProduto);
                produto.IdProduto = maiorId + 1;
                produto.DataCadastro = DateTime.Today.ToString("dd/MM/yyyy");
                Produto.listagem.Add(produto);
            }
        }

        public static void Excluir(int idProduto)
        {
            var produtoExistente = Produto.listagem.Find(u => u.IdProduto == idProduto);
            if (produtoExistente != null)
            {
                Produto.listagem.Remove(produtoExistente);
            }
        }

    }
}