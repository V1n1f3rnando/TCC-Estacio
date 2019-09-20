using Oficina.com.Dados.Repositorios;
using Oficina.Com.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OFicina.Com.Negocio
{
    public class FornecedorNegocio
    {
        public void Cadastrar(Fornecedor f)
        {
            FornecedorRepositorio rep = new FornecedorRepositorio();
            rep.Insert(f);
        }

        public void Altualizar(Fornecedor f)
        {
            FornecedorRepositorio rep = new FornecedorRepositorio();
            rep.Update(f);
        }

        public void Excluir(Fornecedor f)
        {
            FornecedorRepositorio rep = new FornecedorRepositorio();
            rep.Delete(f);
        }

        public List<Fornecedor> Consulta()
        {
            FornecedorRepositorio rep = new FornecedorRepositorio();
            return rep.FindAll();
        }

        public Fornecedor Consulta(int id)
        {
            FornecedorRepositorio rep = new FornecedorRepositorio();
            return rep.FindById(id);
        }
    }
}
