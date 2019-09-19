using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using Oficina.Com.Entidades;
using Oficina.com.Dados.Mapeamentos;
using System.Data.Entity.ModelConfiguration.Conventions;

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
            //Classe de mapeamento
            modelBuilder.Configurations.Add(new ClienteMap());
            modelBuilder.Configurations.Add(new ColaboradorMap());
            modelBuilder.Configurations.Add(new EnderecoMap());
            modelBuilder.Configurations.Add(new FornecedorMap());
            modelBuilder.Configurations.Add(new HistoricoMap());
            modelBuilder.Configurations.Add(new OrdemServicoMap());
            modelBuilder.Configurations.Add(new ProdutoMap());
            modelBuilder.Configurations.Add(new VeiculoMap());

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Properties<string>().Configure(p => p.HasColumnType("varchar"));
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        }

        public DbSet<Cliente> Cliente { get; set; } 
        public DbSet<Colaborador> Colaborador { get; set; } 
        public DbSet<Endereco> Endereco { get; set; } 
        public DbSet<Fornecedor> Fornecedor { get; set; } 
        public DbSet<Historico> Historico { get; set; } 
        public DbSet<OrdemServico> OrdemServico { get; set; } 
        public DbSet<Produto> Produto { get; set; } 
        public DbSet<Veiculo> Veiculo { get; set; } 
    }
}
