using ProjetoOficina.Services.Models.Perfil;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjetoOficina.Services.Models.Usuario
{
    public class UsuarioCadastroModel
    {


        [Required(ErrorMessage = "Por favor, informe o email.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Por favor, informe a senha de acesso.")]
        public string Senha { get; set; }

        [Required(ErrorMessage = "Por favor, informe o nome.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Por favor, informe o nome.")]
        [MaxLength(ErrorMessage = "Por favor, digite no máximo 50 caracteres.")]
        public string Login { get; set; }


        public string Foto { get; set; }

        [Required(ErrorMessage = "Por favor, selecione ao menos um perfil para o usuário.")]
        public List<PerfilUsuarioModel> Perfis { get; set; }



    }
}