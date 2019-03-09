using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoOficina.Entidades
{
    public class Produto
    {
        public int IdProduto { get; set; }
        public string CodigoProduto { get; set; }
        public string Nome { get; set; }
        public decimal Quantidade { get; set; }
        public decimal Valor { get; set; }
        public DateTime Validade { get; set; }
        public string Descricao { get; set; }

        //Relacionamento
        public List<Fornecedor> Fornecedors { get; set; }
    }
}
