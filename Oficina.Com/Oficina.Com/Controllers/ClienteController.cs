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
                EnderecoNegocio enderecoNegocio = new EnderecoNegocio();
                VeiculoNegocio veiculoNegocio = new VeiculoNegocio();

                foreach (var item in clienteNegocio.Consulta())
                {
                    ClienteViewModel model = new ClienteViewModel();

                    model.Id = item.Id;
                    model.Nome = item.Nome;
                    model.Telefone = item.Telefone;
                    model.Cpf = item.Cpf;
                    model.DataNascimento = item.DataNascimento.ToString("dd/mm/yyyy");
                    model.Email = item.Email;
                    model.Endereco = enderecoNegocio.Consulta(item.EnderecoId);
                    model.Veiculos = veiculoNegocio.Consulta().Where(x => x.ClienteId == item.Id).ToList();
                    lista.Add(model);
                }

                return View(lista);
            }
            catch (Exception)
            {

                throw;
            }        
        }
        
        [HttpPost]
        public JsonResult Editar(int id)
        {
            ClienteViewModel model = new ClienteViewModel();
            ClienteNegocio clienteNegocio = new ClienteNegocio();
            EnderecoNegocio enderecoNegocio = new EnderecoNegocio();
            Endereco e = new Endereco();
            Cliente c = new Cliente();
            c = clienteNegocio.Consulta(id);

            e = enderecoNegocio.Consulta(c.EnderecoId);

            model.Id = c.Id;
            model.Nome = c.Nome;
            model.Telefone = c.Telefone;
            model.Veiculos = c.Veiculos;
            model.Cpf = c.Cpf;
            model.DataNascimento = c.DataNascimento.ToString("yyyy-MM-dd");
            model.Email = c.Email;
            model.Endereco = e;
            
           
            return Json(model);
        }

        
        [HttpPost]
        public JsonResult Edita(ClienteViewModel model)
        {
            try
            {
                Cliente c = new Cliente();
                ClienteNegocio clienteNegocio = new ClienteNegocio();

                c = clienteNegocio.Consulta(model.Id);
                c.Nome = model.Nome;
                c.Telefone = model.Telefone;
                c.DataNascimento = Convert.ToDateTime(model.DataNascimento);
                c.Cpf = model.Cpf;
                c.Email = model.Email;

                clienteNegocio.Altualizar(c);
            }
            catch (Exception)
            {

                throw;
            }
    

            return Json("");
        }

        public JsonResult Detalhes(int id)
        {
            Cliente cliente = new Cliente();
            ClienteNegocio negocio = new ClienteNegocio();
            cliente = negocio.Consulta(id);

            EnderecoNegocio enderecoNegocio = new EnderecoNegocio();
            cliente.Endereco = enderecoNegocio.Consulta(cliente.EnderecoId);

            VeiculoNegocio veiculoNegocio = new VeiculoNegocio();
            cliente.Veiculos = veiculoNegocio.Consulta().Where(x => x.ClienteId == id).ToList();

            ClienteViewModel model = new ClienteViewModel();
            model.Id = cliente.Id;
            model.Nome = cliente.Nome;
            model.Telefone = cliente.Telefone;
            model.Cpf = cliente.Cpf;
            model.DataNascimento = cliente.DataNascimento.ToString("yyyy-MM-dd");
            model.Email = cliente.Email;
            model.Endereco = cliente.Endereco;
            
            return Json(model);
        }

        [HttpPost]
        public JsonResult Cadastrar(ClienteViewModel model)
        {
            try
            {
                ClienteNegocio clienteNegocio = new ClienteNegocio();
                EnderecoNegocio enderecoNegocio = new EnderecoNegocio();

                Endereco e = new Endereco();
                e.Numero = model.Endereco.Numero;
                e.Rua = model.Endereco.Rua;
                e.UF = model.Endereco.UF;
                e.Cep = model.Endereco.Cep;
                e.Bairro = model.Endereco.Bairro;
                enderecoNegocio.Cadastrar(e);

                Cliente c = new Cliente();
                c.Nome = model.Nome;
                c.Telefone = model.Telefone;
                c.Cpf = model.Cpf;
                c.DataNascimento = Convert.ToDateTime(model.DataNascimento);
                c.Email = model.Email;
                c.EnderecoId = e.Id;

                clienteNegocio.Cadastrar(c);
            }
            catch (Exception)
            {
                throw;
            }          

            return Json("Cliente cadastrado com sucesso!!");
        }
        
        [HttpPost]
        public JsonResult Delete(int id)
        {
            try
            {
                Cliente c = new Cliente();
                ClienteNegocio clienteNegocio = new ClienteNegocio();

                Endereco e = new Endereco();
                EnderecoNegocio enderecoNegocio = new EnderecoNegocio();

                Veiculo v = new Veiculo();
                VeiculoNegocio veiculoNegocio = new VeiculoNegocio();


                c = clienteNegocio.Consulta(id);

                List<Veiculo> veiculos = new List<Veiculo>();
                veiculos = veiculoNegocio.Consulta().Where(x => x.ClienteId == c.Id).ToList();

                if (veiculos != null)
                {
                    foreach (var veic in veiculos)
                        veiculoNegocio.Excluir(veic);
                }

                e = enderecoNegocio.Consulta(c.EnderecoId);

                if (c != null)
                {
                    clienteNegocio.Excluir(c);
                    enderecoNegocio.Excluir(e);
                }
            }
            catch (Exception)
            {

                throw;
            }

            return Json("");
        }

        [HttpPost]
        public JsonResult RetornaListaCliente()
        {
            List<string> lstCliente = new List<string>();
            ClienteNegocio negocio = new ClienteNegocio();
            List<Cliente> c = new List<Cliente>();
            foreach (var cliente in negocio.Consulta())
            {
                lstCliente.Add(cliente.Nome);
            }
            return Json(lstCliente);
        }
    }
}