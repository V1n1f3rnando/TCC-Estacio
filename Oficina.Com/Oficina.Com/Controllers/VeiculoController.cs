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
                    ClienteNegocio clienteNegocio = new ClienteNegocio();
                    Cliente cliente = new Cliente();
                    cliente = clienteNegocio.Consulta(veiculo.ClienteId);

                    VeiculoViewModel model = new VeiculoViewModel();
                    model.Id = veiculo.Id;
                    model.Placa = veiculo.Placa;
                    model.Modelo = veiculo.Modelo;
                    model.Motor = veiculo.Motor;
                    model.Obs = veiculo.Obs;
                    model.Tipo = veiculo.Tipo;
                    model.Ano = veiculo.Ano;
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
                ClienteNegocio clienteNegocio = new ClienteNegocio();
                Cliente cliente = new Cliente();
                string cpf = model.CpfCliente.Replace(@"\t", "").Trim();

                if (!clienteNegocio.ExisteCpf(cpf))
                    throw new Exception("O cpf informado não existe em nossas bases !");

                cliente = clienteNegocio.Consulta().Single(x => x.Cpf == cpf);
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
        [HttpPost]
        public JsonResult Edit(int id)
        {
            try
            {
                VeiculoViewModel model = new VeiculoViewModel();
                VeiculoNegocio veiculoNegocio = new VeiculoNegocio();
                Veiculo veiculo = veiculoNegocio.Consulta(id);

                ClienteNegocio clienteNegocio = new ClienteNegocio();
                Cliente cliente = clienteNegocio.Consulta().Single(x => x.Id == veiculo.ClienteId);

                model.Id = veiculo.Id;
                model.Placa = veiculo.Placa;
                model.Ano = veiculo.Ano;
                model.Tipo = veiculo.Tipo;
                model.Modelo = veiculo.Modelo;
                model.Cor = veiculo.Cor;
                model.Motor = veiculo.Motor;
                model.Obs = veiculo.Obs;
                model.CpfCliente = cliente.Cpf;
                model.IdCliente = veiculo.ClienteId;

                return Json(model);

            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpPost]
        public JsonResult Editar(VeiculoViewModel model)
        {
            try
            {
                VeiculoNegocio negocio = new VeiculoNegocio();
                Veiculo v = negocio.Consulta(model.Id);


                if (ModelState.IsValid)
                {
                    v.Placa = model.Placa;
                    v.Ano = model.Ano;
                    v.Tipo = model.Tipo;
                    v.Modelo = model.Modelo;
                    v.Cor = model.Cor;
                    v.Motor = model.Motor;
                    v.Obs = model.Obs;

                    negocio.Altualizar(v);
                }

                return Json("");
            }
            catch (Exception)
            {

                throw;
            }
        }
        public JsonResult Delete(int id)
        {
            try
            {
                VeiculoNegocio veiculoNegocio = new VeiculoNegocio();
                Veiculo veiculo = veiculoNegocio.Consulta(id);
                veiculoNegocio.Excluir(veiculo);

                return Json("");
            }
            catch (Exception)
            {

                throw;
            }
        }
        public JsonResult Detalhes(int id)
        {
            VeiculoNegocio veiculoNegocio = new VeiculoNegocio();
            Veiculo veiculo = veiculoNegocio.Consulta(id);

            ClienteNegocio cn = new ClienteNegocio();
            Cliente cliente = cn.Consulta(veiculo.ClienteId);

            VeiculoViewModel model = new VeiculoViewModel();
            model.Id = veiculo.Id;
            model.Ano = veiculo.Ano;
            model.Cor = veiculo.Cor;
            model.IdCliente = veiculo.ClienteId;
            model.Modelo = veiculo.Modelo;
            model.Motor = veiculo.Motor;
            model.Obs = veiculo.Obs;
            model.Placa = veiculo.Placa;
            model.Tipo = veiculo.Tipo;
            model.CpfCliente = cliente.Cpf;
            model.Nome = cliente.Nome;
   
            return Json(model);
        }
        [HttpPost]
        public JsonResult RetornaListaVeiculo()
        {
            List<string[]> lstplaca = new List<string[]>();
            string[] modeloPlaca;
            VeiculoNegocio negocio = new VeiculoNegocio();
            List<Veiculo> v = new List<Veiculo>();
            foreach (var veiculo in negocio.Consulta())
            {
                modeloPlaca = (veiculo.Modelo+"|"+veiculo.Placa).Split('|');
                lstplaca.Add(modeloPlaca);
            }

            return Json(lstplaca);
        }
    }
}