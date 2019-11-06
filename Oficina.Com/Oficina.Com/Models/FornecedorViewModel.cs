using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Oficina.Com.Models
{
    public class FornecedorViewModel
    {
        public int Id { get; set; }
        public string Razao { get; set; }
        public string Cnpj { get; set; }
        public string Telefone { get; set; }
        public string Email  { get; set; }
        public string Endereco { get; set; }
    }
}