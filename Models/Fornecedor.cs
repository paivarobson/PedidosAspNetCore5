using System;
using System.Collections.Generic;
using System.Linq;

namespace PedidosAspNetCore5.Models
{
    public class Fornecedor
    {
        public int FornecedorId { get; set; }
        public string CNPJ { get; set; }
        public string RazaoSocial { get; set; }
        public string UF { get; set; }
        public string EmailContato { get; set; }
        public string NomeContato { get; set; }
        public ICollection<Pedido> Pedidos { get; set; }

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
                new Fornecedor { FornecedorId = 1, RazaoSocial = "Fornecedor 1", CNPJ = "CNPJ 1", UF = "CE", EmailContato = "fornecedor1@email.com", NomeContato = "Nome Contato do Fornecedor 1" });
            Fornecedor.listagem.Add(
                new Fornecedor { FornecedorId = 2, RazaoSocial = "Fornecedor 2", CNPJ = "CNPJ 1", UF = "CE", EmailContato = "fornecedor2@email.com", NomeContato = "Nome Contato do Fornecedor 2" });
            Fornecedor.listagem.Add(
                new Fornecedor { FornecedorId = 3, RazaoSocial = "Fornecedor 3", CNPJ = "CNPJ 1", UF = "CE", EmailContato = "fornecedor3@email.com", NomeContato = "Nome Contato do Fornecedor 3" });
            Fornecedor.listagem.Add(
                new Fornecedor { FornecedorId = 4, RazaoSocial = "Fornecedor 4", CNPJ = "CNPJ 1", UF = "CE", EmailContato = "fornecedor4@email.com", NomeContato = "Nome Contato do Fornecedor 4" });
            Fornecedor.listagem.Add(
                new Fornecedor { FornecedorId = 5, RazaoSocial = "Fornecedor 5", CNPJ = "CNPJ 1", UF = "CE", EmailContato = "fornecedor5@email.com", NomeContato = "Nome Contato do Fornecedor 5" });
        }

        public static void Salvar(Fornecedor fornecedor)
        {
            var fornecedorExistente = Fornecedor.listagem.Find(u => u.FornecedorId == fornecedor.FornecedorId);
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
                int maiorId = Fornecedor.Listagem.Max(u => u.FornecedorId);
                fornecedor.FornecedorId = maiorId + 1;
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
            var fornecedorExistente = Fornecedor.listagem.Find(u => u.FornecedorId == idFornecedor);
            if (fornecedorExistente != null)
            {
                Fornecedor.listagem.Remove(fornecedorExistente);
            }
        }

    }
}