using Oficina.com.Dados.Repositorios;
using Oficina.Com.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OFicina.Com.Negocio
{
    public class ClienteNegocio
    {
        public void Cadastrar(Cliente c)
        {
            ClienteRepositorio rep = new ClienteRepositorio();
            rep.Insert(c);
        }

        public void Altualizar(Cliente c)
        {

            ClienteRepositorio rep = new ClienteRepositorio();
            rep.Update(c);

        }

        public void Excluir(Cliente c)
        {
            ClienteRepositorio rep = new ClienteRepositorio();
            rep.Delete(c);
        }

        public List<Cliente> Consulta()
        {
            ClienteRepositorio rep = new ClienteRepositorio();
            return rep.FindAll();
        }

        public Cliente Consulta(int id)
        {
            ClienteRepositorio rep = new ClienteRepositorio();
            return rep.FindById(id);
        }

        public Cliente Consulta(string cpf)
        {
            ClienteRepositorio rep = new ClienteRepositorio();
            return rep.FindById(cpf);
        }

        public bool ExisteCpf(string cpf)
        {
            bool existe = Consulta().Any(x => x.Cpf == cpf);

            return existe;
        }
    }
}
