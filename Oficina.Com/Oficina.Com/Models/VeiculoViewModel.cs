using Oficina.Com.Entidades.Tipos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Oficina.Com.Models
{
    public class VeiculoViewModel
    {
        public int Id { get; set; }
        public string Placa { get; set; }
        public string Ano { get; set; }
        public TipoVeiculo Tipo { get; set; }
        public string Modelo { get; set; }
        public string Cor { get; set; }
        public string Motor { get; set; }
        public string Obs { get; set; }

        public int IdCliente { get; set; }
        public string CpfCliente { get; set; }
        public string Nome { get; set; }
    }
}