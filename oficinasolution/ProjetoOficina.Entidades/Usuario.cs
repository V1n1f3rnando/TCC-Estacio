using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoOficina.Entidades
{
    public class Usuario
    {
        public int IdUsuario { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Foto { get; set; }
        public DateTime ValidadeSenha { get; set; }
        public DateTime DataCadastro { get; set; }



        //Relacionamento...
        public List<Perfil> Perfis { get; set; }
        public Colaborador Colaborador { get; set; }
        public Cliente Clientes { get; set; }


    }
}
