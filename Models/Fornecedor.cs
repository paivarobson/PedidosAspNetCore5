using System;
using System.Collections.Generic;
using System.Linq;

namespace PedidosAspNetCore5.Models
{
    public class Fornecedor
    {
        public int IdFornecedor { get; set; }
        public string RazaoSocial { get; set; }
        public string CNPJ { get; set; }
        public string UF { get; set; }
        public string EmailContato { get; set; }
        public string NomeContato { get; set; }

        private static List<Fornecedor> listagem = new List<Fornecedor>();
        public static IQueryable<Fornecedor> Listagem
        {
            get
            {
                return listagem.AsQueryable();
            }
        }

        static Fornecedor()
        {
            Fornecedor.listagem.Add(
                new Fornecedor { IdFornecedor = 1, RazaoSocial = "Fornecedor 1", CNPJ = "CNPJ 1", UF = "CE", EmailContato = "fornecedor1@email.com", NomeContato = "Nome Contato do Fornecedor 1" });
            Fornecedor.listagem.Add(
                new Fornecedor { IdFornecedor = 2, RazaoSocial = "Fornecedor 2", CNPJ = "CNPJ 1", UF = "CE", EmailContato = "fornecedor2@email.com", NomeContato = "Nome Contato do Fornecedor 2" });
            Fornecedor.listagem.Add(
                new Fornecedor { IdFornecedor = 3, RazaoSocial = "Fornecedor 3", CNPJ = "CNPJ 1", UF = "CE", EmailContato = "fornecedor3@email.com", NomeContato = "Nome Contato do Fornecedor 3" });
            Fornecedor.listagem.Add(
                new Fornecedor { IdFornecedor = 4, RazaoSocial = "Fornecedor 4", CNPJ = "CNPJ 1", UF = "CE", EmailContato = "fornecedor4@email.com", NomeContato = "Nome Contato do Fornecedor 4" });
            Fornecedor.listagem.Add(
                new Fornecedor { IdFornecedor = 5, RazaoSocial = "Fornecedor 5", CNPJ = "CNPJ 1", UF = "CE", EmailContato = "fornecedor5@email.com", NomeContato = "Nome Contato do Fornecedor 5" });
        }

        public static void Salvar(Fornecedor fornecedor)
        {
            var fornecedorExistente = Fornecedor.listagem.Find(u => u.IdFornecedor == fornecedor.IdFornecedor);
            if (fornecedorExistente != null)
            {
                fornecedorExistente.RazaoSocial = fornecedor.RazaoSocial;
                fornecedorExistente.CNPJ = fornecedor.CNPJ;
                fornecedorExistente.UF = fornecedor.UF;
                fornecedorExistente.EmailContato = fornecedor.EmailContato;
                fornecedorExistente.NomeContato = fornecedor.NomeContato;
            }
            else
            {
                int maiorId = Fornecedor.Listagem.Max(u => u.IdFornecedor);
                fornecedor.IdFornecedor = maiorId + 1;
                fornecedor.RazaoSocial = fornecedor.RazaoSocial;
                fornecedor.CNPJ = fornecedor.CNPJ;
                fornecedor.UF = fornecedor.UF;
                fornecedor.EmailContato = fornecedor.EmailContato;
                fornecedor.NomeContato = fornecedor.NomeContato;
                Fornecedor.listagem.Add(fornecedor);
            }
        }

        public static void Excluir(int idFornecedor)
        {
            var fornecedorExistente = Fornecedor.listagem.Find(u => u.IdFornecedor == idFornecedor);
            if (fornecedorExistente != null)
            {
                Fornecedor.listagem.Remove(fornecedorExistente);
            }
        }

    }
}