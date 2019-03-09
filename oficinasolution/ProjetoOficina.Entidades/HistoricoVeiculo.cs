using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoOficina.Entidades
{
    public class HistoricoVeiculo
    {
        public int IdHistoricoVeiculo { get; set; }
        public string CausaDaVisita { get; set; }
        public string Solucao { get; set; }
        public decimal Orcamento { get; set; }
        public DateTime DataEntrada{ get; set; }
        public DateTime DataSaida { get; set; }

        //Relacionamento
        public List<Veiculo> Veiculos { get; set; }
        public List<Colaborador> Colaboradors { get; set; }
    }
}
