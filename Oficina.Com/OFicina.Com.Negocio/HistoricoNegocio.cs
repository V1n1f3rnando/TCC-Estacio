using Oficina.com.Dados.Repositorios;
using Oficina.Com.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OFicina.Com.Negocio
{
    public class HistoricoNegocio
    {
        public void Cadastrar(Historico h)
        {
            HistoricoRepositorio rep = new HistoricoRepositorio();
            rep.Insert(h);
        }

        public void Altualizar(Historico h)
        {
            HistoricoRepositorio rep = new HistoricoRepositorio();
            rep.Update(h);
        }

        public void Excluir(Historico h)
        {
            HistoricoRepositorio rep = new HistoricoRepositorio();
            rep.Delete(h);
        }

        public List<Historico> Consulta()
        {
            HistoricoRepositorio rep = new HistoricoRepositorio();
            return rep.FindAll();
        }

        public Historico Consulta(int id)
        {
            HistoricoRepositorio rep = new HistoricoRepositorio();
            return rep.FindById(id);
        }
    }
}
