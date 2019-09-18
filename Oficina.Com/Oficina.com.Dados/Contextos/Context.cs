using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.Entity;
using Oficina.Com.Entidades;

namespace Oficina.com.Dados.Contextos
{
    public class Context : DbContext
    {
        public Context()
            :base(ConfigurationManager.ConnectionStrings["Banco"].ConnectionString)
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //adicionar as classes de mapeamento..
            //modelBuilder.Configurations.Add(new );
        }

        public DbSet<Cliente> Cliente { get; set; } //LAMBDA..
    }
}
