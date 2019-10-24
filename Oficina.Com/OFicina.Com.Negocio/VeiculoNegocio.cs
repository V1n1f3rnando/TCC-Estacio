using Oficina.com.Dados.Repositorios;
using Oficina.Com.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OFicina.Com.Negocio
{
    public class VeiculoNegocio
    {
        public void Cadastrar(Veiculo v)
        {
            VeiculoRepositorio rep = new VeiculoRepositorio();
            rep.Insert(v);
        }

        public void Altualizar(Veiculo v)
        {
            VeiculoRepositorio rep = new VeiculoRepositorio();
            rep.Update(v);
        }

        public void Excluir(Veiculo v)
        {
            VeiculoRepositorio rep = new VeiculoRepositorio();
            rep.Delete(v);
        }

        public List<Veiculo> Consulta()
        {
            VeiculoRepositorio rep = new VeiculoRepositorio();
            return rep.FindAll();
        }

        public Veiculo Consulta(int id)
        {
            VeiculoRepositorio rep = new VeiculoRepositorio();
            return rep.FindById(id);
        }


    }
}
