using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoOficina.Entidades
{
    public class Fornecedor
    {
        public int IdFornecedor { get; set; }
        public string Nome { get; set; }
        public string CNPJ { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string Site { get; set; }
        public string Ramo { get; set; }
        public string Observacao { get; set; }
        public DateTime DataCadastro { get; set; }

        public Fornecedor(int idFornecedor, string nome, string cNPJ, string email, string telefone, string site, string ramo, DateTime dataCadastro, string observacao)
        {
            IdFornecedor = idFornecedor;
            Nome = nome;
            CNPJ = cNPJ;
            Email = email;
            Telefone = telefone;
            Site = site;
            Ramo = ramo;
            Observacao = observacao;
            DataCadastro = dataCadastro;
        }

        public override string ToString()
        {
            return $"\n Fornecedor:{Nome}\n CNPJ:{CNPJ}\n Email:{Email}\n Telefone:{Telefone}\n Site:{Site}\n Ramo:{Ramo}\n Data de Cadastro:{DataCadastro}\n Observação:{Observacao}";
        }
    }
}
