using Oficina.Com.Entidades;
using Oficina.Com.Models;
using OFicina.Com.Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Oficina.Com.Controllers
{
    public class ProdutoController : Controller
    {
        // GET: Produto
        public ActionResult ConsultarProduto()
        {
            ProdutoNegocio produtoNegocio = new ProdutoNegocio();
            List<ProdutoViewModel> lstproduto = new List<ProdutoViewModel>();
            ProdutoViewModel model = new ProdutoViewModel();

            foreach (var produto in produtoNegocio.Consulta())
            {
                model.Id = produto.Id;
                model.Imagem = produto.Imagem;
                model.Nome = produto.Nome;
                model.Quantidade = produto.Quantidade;
                model.ValorUnitario = produto.ValorUnitario;

                lstproduto.Add(model);
            }
            return View(lstproduto);
        }
        [HttpPost]
        public JsonResult Cadastrar(ProdutoViewModel model)
        {
            try
            {
                Produto p = new Produto();
                p.Id = model.Id;
                p.Imagem = model.Imagem;
                p.Nome = model.Nome;
                p.Quantidade = model.Quantidade;
                p.ValorUnitario = model.ValorUnitario;
                FornecedorNegocio fornecedorNegocio = new FornecedorNegocio();
                Fornecedor f = fornecedorNegocio.Consulta().Single(x => x.Cnpj == model.CnpjFornecedor);
                p.FornecedorId = f.Id;

                ProdutoNegocio produtoNegocio = new ProdutoNegocio();
                produtoNegocio.Cadastrar(p);

                return Json("");
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpPost]
        public JsonResult Editar(ProdutoViewModel model)
        {
            try
            {
                ProdutoNegocio produtoNegocio  = new ProdutoNegocio();
                Produto p = produtoNegocio.Consulta(model.Id);

                p.Id = model.Id;
                p.Imagem = model.Imagem;
                p.Nome = model.Nome;
                p.Quantidade = model.Quantidade;
                p.ValorUnitario = model.ValorUnitario;
                p.FornecedorId = model.FornecedorId;

                produtoNegocio.Altualizar(p);

                return Json("");
            }
            catch (Exception)
            {

                throw;
            }
        }

        public JsonResult Edit(int id)
        {
            try
            {
                ProdutoNegocio produtoNegocio = new ProdutoNegocio();
                Produto p = produtoNegocio.Consulta(id);
                ProdutoViewModel model = new ProdutoViewModel();

                model.Id = p.Id;
                model.Imagem = p.Imagem;
                model.Nome = p.Nome;
                model.Quantidade = p.Quantidade;
                model.ValorUnitario = p.ValorUnitario;
                model.FornecedorId = p.FornecedorId;

                return Json(model);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public JsonResult Detalhe(int id)
        {
            try
            {
                ProdutoNegocio produtoNegocio = new ProdutoNegocio();
                Produto p = produtoNegocio.Consulta(id);
                ProdutoViewModel model = new ProdutoViewModel();

                model.Id = p.Id;
                model.Imagem = p.Imagem;
                model.Nome = p.Nome;
                model.Quantidade = p.Quantidade;
                model.ValorUnitario = p.ValorUnitario;
                model.FornecedorId = p.FornecedorId;
                
                return Json(model);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public JsonResult Excluir(int id)
        {
            try
            {
                ProdutoNegocio produtoNegocio = new ProdutoNegocio();
                Produto p = produtoNegocio.Consulta(id);
                produtoNegocio.Excluir(p);

                return Json("");
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}