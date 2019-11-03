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
    public class OrdemController : Controller
    {
        // GET: Ordem
        public ActionResult ConsultarOrdem()
        {
            
            return View();
        }
        public JsonResult Cadastrar(OrdemServicoViewModel model)
        {
            OrdemServico ordemServico = new OrdemServico();
            ColaboradorNegocio negocio = new ColaboradorNegocio();
            ordemServico.Colaborador = negocio.Consulta(1);
            ordemServico.DataAbertura = DateTime.Now;
            ordemServico.Motivo = model.Motivo;
            ordemServico.Orçamento = model.Orçamento;
            ordemServico.Placa = model.Placa;
            ordemServico.Status = model.Status;

            OrdemServicoNegocio ordemNegocio = new OrdemServicoNegocio();
            ordemNegocio.Cadastrar(ordemServico);

            return Json("");
        }
    }
}