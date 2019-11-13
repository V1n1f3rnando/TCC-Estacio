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
    public class ColaboradorController : Controller
    {
        // GET: Colaborador
        [HttpPost]
        public JsonResult Cadastro(ColaboradorViewModel model)
        {
            EnderecoNegocio enderecoNegocio = new EnderecoNegocio();
            Endereco e = new Endereco();

            e.Numero = model.Endereco.Numero;
            e.Rua = model.Endereco.Rua;
            e.UF = model.Endereco.UF;
            e.Cep = model.Endereco.Cep;
            e.Bairro = model.Endereco.Bairro;
            e.Complemento = model.Endereco.Complemento;


            enderecoNegocio.Cadastrar(e);

            ColaboradorNegocio colaboradorNegocio = new ColaboradorNegocio();
            Colaborador c = new Colaborador();

            c.Nome = model.Nome;
            c.Salario = model.Salario;
            c.Telefone = model.Telefone;
            c.EstadoCivil = model.EstadoCivil;
            c.EnderecoId = e.Id;
            c.Email = model.Email;
            c.DataNascimento = model.DataNascimento;
            c.Cpf = model.Cpf;
            c.Cargo = model.Cargo;

            colaboradorNegocio.Cadastrar(c);
            
            return Json("");
        }
        public ActionResult Consulta()
        {

            ColaboradorNegocio colaboradorNegocio = new ColaboradorNegocio();
            List<Colaborador> lstColaborador = colaboradorNegocio.Consulta();
            List<ColaboradorViewModel> lstModel = new List<ColaboradorViewModel>();

            foreach (var c in lstColaborador)
            {
                ColaboradorViewModel model = new ColaboradorViewModel();

                model.Id = c.Id;
                model.Nome = c.Nome;
                model.Salario = c.Salario;
                model.Telefone = c.Telefone;
                model.Cargo = c.Cargo;
                model.Email = c.Email;
                model.EnderecoId = c.EnderecoId;

                lstModel.Add(model);
            }

            return View(lstModel);

        }
        [HttpPost]
        public JsonResult Editar(int id)
        {
            ColaboradorViewModel model = new ColaboradorViewModel();
            ColaboradorNegocio colaboradorNegocio = new ColaboradorNegocio();
            Colaborador c = colaboradorNegocio.Consulta(id);
            EnderecoNegocio enderecoNegocio = new EnderecoNegocio();
            Endereco e = enderecoNegocio.Consulta(c.EnderecoId);

            model.Cargo = c.Cargo;
            model.Cpf = c.Cpf;
            model.DataNascimento = c.DataNascimento;
            model.Email = c.Email;
            model.EnderecoId = e.Id;
            model.Endereco = e;
            model.Nome = c.Nome;
            model.Salario = c.Salario;
            model.Telefone = c.Telefone;
            model.EstadoCivil = c.EstadoCivil;
            
            return Json(model);
        }
        public JsonResult Excluir(int id)
        {
            ColaboradorNegocio colaboradorNegocio = new ColaboradorNegocio();
            Colaborador c = colaboradorNegocio.Consulta(id);
            colaboradorNegocio.Excluir(c);
            return Json("");
        }
    }
}