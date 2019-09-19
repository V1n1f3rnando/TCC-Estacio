using Oficina.com.Dados.Repositorios;
using Oficina.Com.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OFicina.Com.Negocio
{
    public class ColaboradorNegocio
    {
        public void Cadastrar(Colaborador c)
        {
            ColaboradorRepositorio rep = new ColaboradorRepositorio();
            rep.Insert(c);
        }

        public void Altualizar(Colaborador c)
        {

            ColaboradorRepositorio rep = new ColaboradorRepositorio();
            rep.Update(c);

        }

        public void Excluir(Colaborador c)
        {
            ColaboradorRepositorio rep = new ColaboradorRepositorio();
            rep.Delete(c);
        }

        public List<Colaborador> Consulta()
        {
            ColaboradorRepositorio rep = new ColaboradorRepositorio();
            return rep.FindAll();
        }

        public Colaborador Consulta(int id)
        {
            ColaboradorRepositorio rep = new ColaboradorRepositorio();
            return rep.FindById(id);
        }
    }
}
