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
                    model.ClienteId = Convert.ToString(veiculo.ClienteId);
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

        [HttpPost]
        public JsonResult Cadastrar(VeiculoViewModel model)
        {
            try
            {
                Veiculo veiculo = new Veiculo();
                ClienteNegocio clienteNegocio =  new ClienteNegocio();
                Cliente cliente = new Cliente();
                cliente = clienteNegocio.Consulta().First(x => x.Cpf == model.ClienteId);
                veiculo.Ano = model.Ano;
                veiculo.ClienteId = cliente.Id;
                veiculo.Cor = model.Cor;
                veiculo.Modelo = model.Modelo;
                veiculo.Motor = model.Motor;
                veiculo.Obs = model.Obs;
                veiculo.Placa = model.Placa;
                veiculo.Tipo = model.Tipo;

                VeiculoNegocio veiculoNegocio = new VeiculoNegocio();
                veiculoNegocio.Cadastrar(veiculo);

            }
            catch (Exception)
            {

                throw;
            }
       
            return Json("");
        }
        public JsonResult Editar(int id)
        {
            VeiculoNegocio veiculoNegocio = new VeiculoNegocio();
            Veiculo veiculo = veiculoNegocio.Consulta(id);
            VeiculoViewModel model = new VeiculoViewModel();
            model.Id = veiculo.Id;
            model.Modelo = veiculo.Modelo;
            model.Motor = veiculo.Motor;
            model.Obs = veiculo.Obs;
            model.Placa = veiculo.Placa;
            model.Tipo = veiculo.Tipo;
            model.Ano = veiculo.Ano;
            model.ClienteId = Convert.ToString(veiculo.ClienteId);
            model.Cor = veiculo.Cor;

            return Json(model);
        }

        [HttpPost]
        public ActionResult Editar(VeiculoViewModel model)
        {
            try
            {
                VeiculoNegocio veiculoNegocio = new VeiculoNegocio();
                Veiculo veiculo = veiculoNegocio.Consulta(model.Id);

                veiculo.Ano = model.Ano;
                veiculo.Id = model.Id;
                veiculo.Cor = model.Cor;
                veiculo.Modelo = model.Modelo;
                veiculo.Motor = model.Motor;
                veiculo.Obs = model.Obs;
                veiculo.Placa = model.Placa;
                veiculo.Tipo = model.Tipo;
                veiculo.ClienteId = Convert.ToInt32(model.ClienteId);

                veiculoNegocio.Altualizar(veiculo);
            }
            catch (Exception)
            {

                throw;
            }
            return View("ConsultarVeiculo");
        }
    }
}