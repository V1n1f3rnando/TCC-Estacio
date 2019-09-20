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
    public class ClienteController : Controller
    {
        // GET: Cliente
        public ActionResult Consulta()
        {
            List<ClienteViewModel> lista = new List<ClienteViewModel>();

            try
            {
                ClienteNegocio clienteNegocio = new ClienteNegocio();
                foreach (var item in clienteNegocio.Consulta())
                {
                    ClienteViewModel model = new ClienteViewModel();

                    model.Id = item.Id;
                    model.Nome = item.Nome;
                    model.Telefone = item.Telefone;
                    model.Cpf = item.Cpf;
                    model.DataNascimento = item.DataNascimento;
                    model.Email = item.Email;
                    model.Endereco = item.Endereco;
                    model.Veiculos = item.Veiculos;

                    lista.Add(model);
                }

                return View(lista);
            }
            catch (Exception)
            {

                throw;
            }

        
        }

        public ActionResult Cadastro()
        {


            return View();
        }
        

    }
}