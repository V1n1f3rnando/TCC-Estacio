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
    public class FornecedorController : Controller
    {
        // GET: Fornecedor
        public ActionResult ConsultarFornecedor()
        {
            List<FornecedorViewModel> lstFornecedor = new List<FornecedorViewModel>();
            FornecedorNegocio fornecedorNegocio = new FornecedorNegocio();
            foreach (var fornecedor in fornecedorNegocio.Consulta())
            {
                FornecedorViewModel model = new FornecedorViewModel();
                model.Cnpj = fornecedor.Cnpj;
                model.Email = fornecedor.Email;
                model.Id = fornecedor.Id;
                model.Razao = fornecedor.Razao;
                model.Endereco = fornecedor.Endereco;
                model.Telefone = fornecedor.Telefone;

                lstFornecedor.Add(model);
            }
            return View(lstFornecedor);
        }
        [HttpPost]
        public JsonResult Cadastrar(FornecedorViewModel model)
        {
            try
            {
                Fornecedor f = new Fornecedor();
                f.Id = model.Id;
                f.Cnpj = model.Cnpj;
                f.Email = model.Email;
                f.Endereco = model.Endereco;
                f.Razao = model.Razao;
                f.Telefone = model.Telefone;
                FornecedorNegocio fornecedorNegocio = new FornecedorNegocio();
                fornecedorNegocio.Cadastrar(f);

                return Json("");
            }
            catch (Exception)
            {

                throw;
            }

        }
        [HttpPost]
        public JsonResult Edit(FornecedorViewModel model)
        {
            try
            {
                FornecedorNegocio fornecedorNegocio = new FornecedorNegocio();
                Fornecedor f = fornecedorNegocio.Consulta(model.Id);

                f.Cnpj = model.Cnpj;
                f.Email = model.Email;
                f.Endereco = model.Endereco;
                f.Razao = model.Razao;
                f.Telefone = model.Telefone; 

                fornecedorNegocio.Altualizar(f);
                return Json("");
            }
            catch (Exception)
            {

                throw;
            }
        }
        public JsonResult Editar(int id)
        {
            try
            {
                FornecedorNegocio fornecedorNegocio = new FornecedorNegocio();
                Fornecedor f = fornecedorNegocio.Consulta(id);
                FornecedorViewModel model = new FornecedorViewModel();
                model.Id = f.Id;
                model.Cnpj = f.Cnpj;
                model.Email = f.Email;
                model.Endereco = f.Endereco;
                model.Razao = f.Razao;
                model.Telefone = f.Telefone;
                
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
                FornecedorNegocio fornecedorNegocio = new FornecedorNegocio();
                Fornecedor f = fornecedorNegocio.Consulta(id);
                FornecedorViewModel model = new FornecedorViewModel();
                model.Id = f.Id;
                model.Cnpj = f.Cnpj;
                model.Email = f.Email;
                model.Endereco = f.Endereco;
                model.Razao = f.Razao;
                model.Telefone = f.Telefone;

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
                FornecedorNegocio fornecedorNegocio = new FornecedorNegocio();
                Fornecedor f = fornecedorNegocio.Consulta(id);
                fornecedorNegocio.Excluir(f);
                return Json("");
            }
            catch (Exception)
            {

                throw;
            }
        }

        public JsonResult RetornaFornecedores()
        {
            List<string[]> lstFornecedor = new List<string[]>();
            string[] nomeCnpj;
            FornecedorNegocio negocio = new FornecedorNegocio();
            List<Fornecedor> f = new List<Fornecedor>();
            foreach (var fornecedor in negocio.Consulta())
            {
                nomeCnpj = (fornecedor.Razao + "|" + fornecedor.Cnpj).Split('|');
                lstFornecedor.Add(nomeCnpj);
            }

            return Json(lstFornecedor);
        }
    }
}