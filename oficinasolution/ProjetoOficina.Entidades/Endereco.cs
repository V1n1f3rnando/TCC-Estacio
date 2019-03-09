using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoOficina.Entidades
{
    public class Endereco
    {
 
        public int IdEndereco { get; set; }
        public string Rua { get; set; }
        public string Numero { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Cep { get; set; }
        public string Estado { get; set; }
        public string Complemento { get; set; }

        //Relacionamento
        public Usuario Usuario { get; set; }

        public Endereco(int idEndereco, string rua, string numero, string bairro, string cidade, string cep, string estado, string complemento)
        {
            IdEndereco = idEndereco;
            Rua = rua;
            Numero = numero;
            Bairro = bairro;
            Cidade = cidade;
            Cep = cep;
            Estado = estado;
            Complemento = complemento;
        }
    }
}
