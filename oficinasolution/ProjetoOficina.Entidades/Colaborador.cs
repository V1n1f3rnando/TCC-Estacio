using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoOficina.Entidades
{
    public class Colaborador
    {

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Profissão { get; set; }
        public  Turno Turno { get; set; }
        public decimal Salario { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public decimal HorasDeTarbalho { get; set; }
        public StatusFuncionario StatusFuncionario { get; set; }
        public DateTime Ferias { get; set; } // verificar se não pode virar um entidade
        public DateTime DataDesligamento { get; set; } // Criada de acordo com o status.
        public DateTime DataNascimento { get; set; }
        public DateTime DataAdmissao { get; set; }

        //Relacionamento
        public Usuario Usuario { get; set; }
        public Endereco Endereco { get; set; }
        public List<Venda> Vendas { get; set; }

        public Colaborador(int id, string nome, string profissão, Turno turno, decimal salario, string telefone, string email, decimal horasDeTarbalho, StatusFuncionario statusFuncionario, DateTime ferias, DateTime dataDesligamento, DateTime dataNascimento, DateTime dataAdmissao)
        {
            Id = id;
            Nome = nome;
            Profissão = profissão;
            Turno = turno;
            Salario = salario;
            Telefone = telefone;
            Email = email;
            HorasDeTarbalho = horasDeTarbalho;
            StatusFuncionario = statusFuncionario;
            Ferias = ferias;
            DataDesligamento = dataDesligamento;
            DataNascimento = dataNascimento;
            DataAdmissao = dataAdmissao;
        }

        public override string ToString()
        {
            return $"\n Nome:{Nome}\n Profissão:{Profissão}\n Turno:{Turno}\n Salário:{Salario}\n Telefone:{Telefone}\n E-mail:{Email}\n Jornada de trabalho:{HorasDeTarbalho}\n Aniversário:{DataNascimento}\n Admissão:{DataAdmissao}\n Status:{StatusFuncionario}\n DataDemissão:{DataDesligamento}";
        }
    }
}
