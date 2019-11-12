using Oficina.Com.Entidades.Tipos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Oficina.Com.Models
{
    public class ColaboradorViewModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public Cargo Cargo { get; set; }
        public decimal Salario { get; set; }
        public int EnderecoId { get; set; }
    }
}