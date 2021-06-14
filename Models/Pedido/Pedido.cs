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
        public int QtdItem { get; set; }
        public double Valor { get; set; }
        public ICollection<PedidoItem> Itens { get; set; }
    }
}