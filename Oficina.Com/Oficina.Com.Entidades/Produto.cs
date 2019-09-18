using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oficina.Com.Entidades
{
    public class Produto
    {
        public int Id { get; set; }
        public string Imagem { get; set; }
        public string Nome { get; set; }
        public decimal ValorUnitario { get; set; }
        public decimal Quantidade { get; set; }

        //Relacionamento
        public int IdFornecedor { get; set; }
        public Fornecedor Fornecedor { get; set; }
    }
}
