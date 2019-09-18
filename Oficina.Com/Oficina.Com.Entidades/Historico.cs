using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oficina.Com.Entidades
{
    public class Historico
    {
        public int Id { get; set; }
        public string TipoVeiculo { get; set; }
        public DateTime UltimaVisita { get; set; }
        public string Motivo { get; set; }
        public string UltimoOrcamento { get; set; }

        //Relacionamentos
        public int IdVeiculo { get; set; }
        public Veiculo veiculo { get; set; }

        public int IdColaborador { get; set; }
        public Colaborador colaborador { get; set; }

    }
}
