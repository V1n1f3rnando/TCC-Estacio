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
         

            foreach (var produto in produtoNegocio.Consulta())
            {
                ProdutoViewModel model = new ProdutoViewModel();

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
                ProdutoNegocio prodNegocio = new ProdutoNegocio();
                FornecedorNegocio fornecNegocio = new FornecedorNegocio();
                int idFornecedor = fornecNegocio.Consulta().First(x => x.Cnpj == model.CnpjFornecedor).Id;

                Produto produto = new Produto();
                produto.FornecedorId = idFornecedor;
                produto.Imagem = model.Imagem;
                produto.Nome = model.Nome;
                produto.Quantidade = model.Quantidade;
                produto.ValorUnitario = model.ValorUnitario;

                prodNegocio.Cadastrar(produto);

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
                FornecedorNegocio fornecedorNegocio = new FornecedorNegocio();
                Fornecedor f = fornecedorNegocio.Consulta(p.FornecedorId);
                model.Id = p.Id;
                model.Nome = p.Nome;
                model.Quantidade = p.Quantidade;
                model.ValorUnitario = p.ValorUnitario;
                model.NomeFornecedor = f.Razao;
                
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