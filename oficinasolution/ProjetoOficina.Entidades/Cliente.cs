using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoOficina.Entidades
{
    public class Cliente
    {
        public int IdCliente { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public DateTime DataNascimento { get; set; }

        //Relacionamento
        public Endereco Endereco { get; set; }
        public Usuario Usuario { get; set; }
        public List<Veiculo> Veiculos { get; set; }
    }
}
