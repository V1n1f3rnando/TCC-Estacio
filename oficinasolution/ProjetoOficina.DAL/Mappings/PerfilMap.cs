using ProjetoOficina.Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoOficina.DAL.Mappings
{
    public class PerfilMap : EntityTypeConfiguration<Perfil>
    {
      
        public PerfilMap()
        {
            
            ToTable("TBPERFIL");
         
            HasKey(p => p.IdPerfil);
           
            Property(p => p.IdPerfil)
            .HasColumnName("IDPERFIL")
            .IsRequired();

            Property(p => p.Nome)
            .HasColumnName("NOME")
            .HasMaxLength(50)
            .IsRequired();
        }

    }
}
