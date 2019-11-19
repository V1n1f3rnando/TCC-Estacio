﻿using Oficina.Com.Entidades;
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
                model.Orçamento = ordem.Orçamento;
                model.Placa = ordem.Placa;
                model.Status = ordem.Status;
                model.DataAbertura = ordem.DataAbertura;
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
            o.Orçamento = model.Orçamento;
            o.Placa = model.Placa;
            o.Status = model.Status;

            OrdemServicoNegocio ordemNegocio = new OrdemServicoNegocio();
            ordemNegocio.Cadastrar(o);

            return Json("");
        }
    }
}