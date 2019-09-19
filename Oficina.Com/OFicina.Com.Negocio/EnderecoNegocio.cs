using Oficina.com.Dados.Repositorios;
using Oficina.Com.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OFicina.Com.Negocio
{
    public class EnderecoNegocio
    {
        public void Cadastrar(Endereco e)
        {
            EnderecoRepositorio rep = new EnderecoRepositorio();
            rep.Insert(e);
        }

        public void Altualizar(Endereco e)
        {
            EnderecoRepositorio rep = new EnderecoRepositorio();
            rep.Update(e);
        }

        public void Excluir(Endereco e )
        {
            EnderecoRepositorio rep = new EnderecoRepositorio();
            rep.Delete(e);
        }

        public List<Endereco> Consulta()
        {
            EnderecoRepositorio rep = new EnderecoRepositorio();
            return rep.FindAll();
        }

        public Endereco Consulta(int id)
        {
            EnderecoRepositorio rep = new EnderecoRepositorio();
            return rep.FindById(id);
        }
    }
}
