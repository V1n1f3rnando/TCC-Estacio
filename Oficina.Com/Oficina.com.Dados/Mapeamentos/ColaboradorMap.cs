using Oficina.Com.Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oficina.com.Dados.Mapeamentos
{
    public class ColaboradorMap: EntityTypeConfiguration<Colaborador>
    {
        public ColaboradorMap()
        {
            ToTable("Colaborador")
                .HasKey(x => x.IdColaborador);
        }
    }
}
