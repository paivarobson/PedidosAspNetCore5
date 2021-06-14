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

    }
}