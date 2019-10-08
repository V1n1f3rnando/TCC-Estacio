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
    public class VeiculoController : Controller
    {
        // GET: Veiculo
        public ActionResult ConsultarVeiculo()
        {
            try
            {
                List<VeiculoViewModel> lstVeiculos = new List<VeiculoViewModel>();
                VeiculoNegocio veiculoNegocio = new VeiculoNegocio();

                foreach (Veiculo veiculo in veiculoNegocio.Consulta())
                {
                    VeiculoViewModel model = new VeiculoViewModel();
                    model.Id = veiculo.Id;
                    model.Placa = veiculo.Placa;
                    model.Modelo = veiculo.Modelo;
                    model.Motor = veiculo.Motor;
                    model.Obs = veiculo.Obs;
                    model.Tipo = veiculo.Tipo;
                    model.Ano = veiculo.Ano;
                    model.ClienteId = veiculo.ClienteId;
                    model.Cor = veiculo.Cor;

                    lstVeiculos.Add(model);
                }

                return View(lstVeiculos);
            }
            catch (Exception)
            {

                throw;
            }
           

        }
    }
}