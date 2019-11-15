using Oficina.Com.Entidades;
using Oficina.Com.Entidades.Tipos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Oficina.Com.Models
{
    public class OrdemServicoViewModel
    {
        public int Id { get; set; }
        public string Motivo { get; set; }
        public DateTime DataAbertura { get; set; }
        public decimal Orçamento { get; set; }
        public StatusOrdemServico Status { get; set; }
        public string Placa { get; set; }
        public string Obs { get; set; }


        public int ColaboradorId { get; set; }

    }
}