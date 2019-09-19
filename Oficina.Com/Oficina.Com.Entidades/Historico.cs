using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oficina.Com.Entidades
{
    public class Historico
    {
        public int IdHistorico { get; set; }
        public string TipoVeiculo { get; set; }
        public DateTime UltimaVisita { get; set; }
        public string Motivo { get; set; }
        public string UltimoOrcamento { get; set; }

        //Relacionamentos
        [ForeignKey("IdVeiculo")]
        public int IdVeiculo { get; set; }
        public virtual Veiculo Veiculo { get; set; }

        [ForeignKey("IdColaborador")]
        public int IdColaborador { get; set; }
        public virtual Colaborador Colaborador { get; set; }

    }
}
