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
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            OrdemServicoNegocio ordemServicoNegocio = new OrdemServicoNegocio();
            ColaboradorNegocio colaboradorNegocio = new ColaboradorNegocio();
            List<OrdemServicoViewModel> lstOrdem = new List<OrdemServicoViewModel>();

            foreach (OrdemServico o in ordemServicoNegocio.Consulta().Take(20))
            {
                OrdemServicoViewModel model = new OrdemServicoViewModel();
                model.ColaboradorId = o.ColaboradorId;
                model.DataAbertura = o.DataAbertura.ToString("dd/MM/yyyy"); 
                model.Id = o.Id;
                model.Motivo = o.Motivo;
                model.NomeColaborador = colaboradorNegocio.Consulta(o.ColaboradorId).Nome;
                model.Obs = o.Obs;
                model.Orcamento = o.Orçamento;
                model.Placa = o.Placa;
                model.Status = o.Status;

                lstOrdem.Add(model);
            }

            return View(lstOrdem);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}