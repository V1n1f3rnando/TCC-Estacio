using Oficina.Com.Entidades.Tipos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oficina.Com.Entidades
{
    public class OrdemServico
    {
        public int Id { get; set; }
        public string Motivo { get; set; }
        public DateTime DataAbertura { get; set; }
        public decimal Orçamento { get; set; }
        public StatusOrdemServico Status { get; set; }
        public string Placa { get; set; }
        public string Obs { get; set; }

    }
}
