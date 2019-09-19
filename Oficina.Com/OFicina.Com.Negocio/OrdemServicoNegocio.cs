using Oficina.com.Dados.Repositorios;
using Oficina.Com.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OFicina.Com.Negocio
{
    public class OrdemServicoNegocio
    {
        public void Cadastrar(OrdemServico o)
        {
            OrdemServicoRepositorio rep = new OrdemServicoRepositorio();
            rep.Insert(o);
        }

        public void Altualizar(OrdemServico o)
        {
            OrdemServicoRepositorio rep = new OrdemServicoRepositorio();
            rep.Update(o);
        }

        public void Excluir(OrdemServico o)
        {
            OrdemServicoRepositorio rep = new OrdemServicoRepositorio();
            rep.Delete(o);
        }

        public List<OrdemServico> Consulta()
        {
            OrdemServicoRepositorio rep = new OrdemServicoRepositorio();
            return rep.FindAll();
        }

        public OrdemServico Consulta(int id)
        {
            OrdemServicoRepositorio rep = new OrdemServicoRepositorio();
            return rep.FindById(id);
        }
    }
}
