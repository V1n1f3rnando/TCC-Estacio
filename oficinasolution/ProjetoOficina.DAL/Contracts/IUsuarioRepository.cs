using ProjetoOficina.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoOficina.DAL.Contracts
{
    public interface IUsuarioRepository : IGenericRepository<Usuario>
    {
        Usuario Find(string login, string senha);
        bool HasLogin(string login);


    }
}
