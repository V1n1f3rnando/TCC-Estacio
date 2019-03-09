using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoOficina.Entidades
{
    public class Veiculo
    {
        public int IdVeiculo { get; set; }
        public string Placa { get; set; }
        public string Modelo { get; set; }
        public string Ano { get; set; }
        public string Tipo { get; set; }


        //Relacionamento
        public Cliente Cliente { get; set; }
        public List<HistoricoVeiculo> HistoricoVeiculos { get; set; }
    }
}
