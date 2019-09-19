using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oficina.Com.Entidades
{
    public class Cliente
    {
        public int Id{ get; set; }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Cpf { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }

        public  List<Veiculo> Veiculos { get; set; }

        public int EnderecoId { get; set; }
        public virtual Endereco Endereco { get; set; }

    }
}
