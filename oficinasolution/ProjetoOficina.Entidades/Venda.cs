using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoOficina.Entidades
{
    public class Venda
    {
        public int IdVenda { get; set; }
        public TipoVenda TipoVenda { get; set; }
        public DateTime DataVenda { get; set; }
        public decimal Quantidade { get; set; }
        public Decimal Valor { get; set; }

        // relacionamento 
        public Colaborador Colaborador { get; set; }
        public List<Produto> Produtos { get; set; }

    }
}
