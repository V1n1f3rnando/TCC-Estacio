using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Oficina.Com.Models
{
    public class OrdemServicoViewModels
    {
        public int Id { get; set; }
        public string Motivo { get; set; }
        public DateTime DataAbertura { get; set; }
        public decimal Orçamento { get; set; }
        public String Status { get; set; }
        public string Placa { get; set; }
        public string Obs { get; set; }
    }
}