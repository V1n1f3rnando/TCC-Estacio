using Oficina.Com.Entidades.Tipos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oficina.Com.Entidades
{
    public class Endereco
    {
        public int Id { get; set; }
        public string Rua { get; set; }
        public string Numero { get; set; }
        public string Bairro { get; set; }
        public Uf UF { get; set; }
        public string Cep { get; set; }
        public string Complemento { get; set; }
    }
}
