using Oficina.Com.Entidades.Tipos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oficina.Com.Entidades
{
    public class Veiculo
    {
        public int Id { get; set; }
        public string Placa { get; set; }
        public string Ano { get; set; }
        public TipoVeiculo Tipo { get; set; }
        public string Modelo { get; set; }
        public string Cor { get; set; }
        public string Motor { get; set; }
        public string Obs { get; set; }

        public int ClienteId { get; set; }
        public virtual Cliente Cliente { get; set; }

        public Veiculo()
        {

        }

        public override string ToString()
        {
            return $" Tipo:{Tipo.ToString()}\n Modelo:{Modelo}\n Placa:{Placa}\n Ano:{Ano}\n Cor:{Cor}\n Motor:{Motor}\n Observação:{Obs} ";
        }
    }
}
