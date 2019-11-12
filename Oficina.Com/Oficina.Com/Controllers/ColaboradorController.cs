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
        public ActionResult Cadastro()
        {
            return View();
        }
        public ActionResult Consulta()
        {
            ColaboradorViewModel model = new ColaboradorViewModel();
            ColaboradorNegocio colaboradorNegocio = new ColaboradorNegocio();
            List<Colaborador> lstColaborador = colaboradorNegocio.Consulta();
            List<ColaboradorViewModel> lstModel = new List<ColaboradorViewModel>();

            foreach (var c in lstColaborador)
            {
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
    }
}