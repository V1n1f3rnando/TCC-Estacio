using Oficina.com.Dados.Repositorios;
using Oficina.Com.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OFicina.Com.Negocio
{
    public class ProdutoNegocio
    {
        public void Cadastrar(Produto p)
        {
            ProdutoRepositorio rep = new ProdutoRepositorio();
            rep.Insert(p);
        }

        public void Altualizar(Produto p)
        {
            ProdutoRepositorio rep = new ProdutoRepositorio();
            rep.Update(p);
        }

        public void Excluir(Produto p)
        {
            ProdutoRepositorio rep = new ProdutoRepositorio();
            rep.Delete(p);
        }

        public List<Produto> Consulta()
        {
            ProdutoRepositorio rep = new ProdutoRepositorio();
            return rep.FindAll();
        }

        public Produto Consulta(int id)
        {
            ProdutoRepositorio rep = new ProdutoRepositorio();
            return rep.FindById(id);
        }
    }
}
