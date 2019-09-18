using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace Oficina.com.Dados.Contextos
{
    public class Context : DbContext
    {
        public Context()
            :base(ConfigurationManager.ConnectionStrings["Banco"].ConnectionString)
        {

        }

        
    }
}
