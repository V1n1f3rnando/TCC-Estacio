﻿using Oficina.Com.Entidades.Tipos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oficina.Com.Entidades
{
    public class Colaborador
    {
        public int IdColaborador { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public Cargo Cargo { get; set; }
        public decimal Salario { get; set; }

        //Relacionamento
        public int IdEndereco { get; set; }
        public Endereco Endereco { get; set; }

    }
}
