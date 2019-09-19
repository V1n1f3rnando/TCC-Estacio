using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oficina.Com.Entidades
{
    public class Produto
    {
        public int IdProduto { get; set; }
        public string Imagem { get; set; }
        public string Nome { get; set; }
        public decimal ValorUnitario { get; set; }
        public decimal Quantidade { get; set; }

        //Relacionamento
        [ForeignKey("IdFornecedor")]
        public int IdFornecedor { get; set; }
        public virtual Fornecedor Fornecedor { get; set; }
    }
}
