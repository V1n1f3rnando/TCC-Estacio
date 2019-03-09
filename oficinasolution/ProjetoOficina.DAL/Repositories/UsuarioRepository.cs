using ProjetoOficina.DAL.Context;
using ProjetoOficina.DAL.Contracts;
using ProjetoOficina.DAL.Generics;
using ProjetoOficina.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoOficina.DAL.Repositories
{
    public class UsuarioRepository
        : GenericRepository<Usuario>, IUsuarioRepository
    {
        public Usuario Find(string login, string senha)
        {
            using (DataContext d = new DataContext())
            {
                return d.Usuario
                .FirstOrDefault(u => u.Login.Equals(login)
                && u.Senha.Equals(senha));
            }
        }

        public bool HasLogin(string login)
        {
            using (DataContext d = new DataContext())
            {
                return d.Usuario
                .Count(u => u.Login.Equals(login)) > 0;
            }
        }

    }
}
