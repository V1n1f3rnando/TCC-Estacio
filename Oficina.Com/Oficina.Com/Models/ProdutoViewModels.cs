using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Oficina.Com.Models
{
    public class ProdutoViewModels
    {
        public int Id { get; set; }
        public string Imagem { get; set; }
        public string Nome { get; set; }
        public decimal ValorUnitario { get; set; }
        public decimal Quantidade { get; set; }
    }
}