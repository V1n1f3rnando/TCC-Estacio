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
            OrdemServicoNegocio servicoNegocio = new OrdemServicoNegocio();
            List<OrdemServicoViewModel> lstOrdem = new List<OrdemServicoViewModel>();
            OrdemServicoViewModel model = new OrdemServicoViewModel();

            foreach (var ordem in servicoNegocio.Consulta())
            {
                model.Id = ordem.Id;
                model.Motivo = ordem.Motivo;
                model.Obs = ordem.Obs;
                model.Orcamento = ordem.Orçamento;
                model.Placa = ordem.Placa;
                model.Status = ordem.Status;
                model.DataAbertura = ordem.DataAbertura.ToString("dd-MM-yyyy");
                model.ColaboradorId = ordem.ColaboradorId;

                lstOrdem.Add(model);
            }
            return View(lstOrdem);
        }
        public JsonResult Cadastrar(OrdemServicoViewModel model)
        {
            OrdemServico ordemServico = new OrdemServico();
            ColaboradorNegocio colaboradorNegocio = new ColaboradorNegocio();
            Colaborador c = colaboradorNegocio.Consulta(model.ColaboradorId);
            OrdemServico o = new OrdemServico();
            //o.Colaborador = c;
            o.ColaboradorId = c.Id;
            o.DataAbertura = DateTime.Now;
            o.Motivo = model.Motivo;
            o.Obs = model.Obs;
            o.Orçamento = model.Orcamento;
            o.Placa = model.Placa;
            o.Status = model.Status;

            OrdemServicoNegocio ordemNegocio = new OrdemServicoNegocio();
            ordemNegocio.Cadastrar(o);

            return Json("");
        }
        [HttpPost]
        public JsonResult Editar(int id)
        {
            try
            {
                OrdemServicoNegocio ordemServico = new OrdemServicoNegocio();
                OrdemServico o = ordemServico.Consulta(id);
                OrdemServicoViewModel model = new OrdemServicoViewModel();

                model.Id = o.Id;
                model.Motivo = o.Motivo;
                model.Obs = o.Obs;
                model.Orcamento = o.Orçamento;
                model.Placa = o.Placa;
                model.Status = o.Status;
                model.ColaboradorId = o.ColaboradorId;
                model.DataAbertura = o.DataAbertura.ToString("yyyy-MM-dd");

                return Json(model);
            }
            catch (Exception ex)
            {
                throw;
            }

        }
        public JsonResult Edit(OrdemServicoViewModel model)
        {
            try
            {
                OrdemServicoNegocio ordemServicoNegocio = new OrdemServicoNegocio();
                OrdemServico o = ordemServicoNegocio.Consulta(model.Id);
                o.Motivo = model.Motivo;
                o.Obs = model.Obs;
                o.Orçamento = model.Orcamento;
                o.Placa = model.Placa;
                o.Status = model.Status;
                o.ColaboradorId = model.ColaboradorId;
                o.DataAbertura = Convert.ToDateTime(model.DataAbertura);

                ordemServicoNegocio.Altualizar(o);
                return Json("");

            }
            catch (Exception ex)
            {

                throw;
            }

        }
        public JsonResult Detalhe(int id)
        {
            try
            {
                OrdemServicoNegocio ordemServico = new OrdemServicoNegocio();
                OrdemServico o = ordemServico.Consulta(id);
                OrdemServicoViewModel model = new OrdemServicoViewModel();
                ColaboradorNegocio colaboradorNegocio = new ColaboradorNegocio();
                Colaborador c = colaboradorNegocio.Consulta(o.ColaboradorId);

                model.Id = o.Id;
                model.Motivo = o.Motivo;
                model.Obs = o.Obs;
                model.Orcamento = o.Orçamento;
                model.Placa = o.Placa;
                model.Status = o.Status;
                model.NomeColaborador = c.Nome;
                model.DataAbertura = o.DataAbertura.ToString("yyyy-MM-dd");

                return Json(model);
            }
            catch (Exception ex)
            {
                throw;
            }

        }
        public JsonResult Excluir(int id)
        {
            OrdemServicoNegocio ordemServicoNegocio = new OrdemServicoNegocio();
            OrdemServico o = ordemServicoNegocio.Consulta(id);
            ordemServicoNegocio.Excluir(o);
            return Json("");
        }

    }
}