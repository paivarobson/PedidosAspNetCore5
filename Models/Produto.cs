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
        public ICollection<PedidoItem> PedidoItens { get; set; }

    }
}