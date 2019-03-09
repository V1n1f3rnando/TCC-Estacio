using ProjetoOficina.DAL.Repositories;
using ProjetoOficina.Entidades;
using ProjetoOficina.Services.Models.Usuario;
using ProjetoOficina.Util;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ProjetoOficina.Services.Controllers
{
    [RoutePrefix("api/usuario")]
    public class UsuarioController : ApiController
    {

        [HttpPost]
        [Route("cadastrar")]
        public HttpResponseMessage CadastrarUsuario(UsuarioCadastroModel model)
        {
            if (ModelState.IsValid)
            {

                try
                {

                    UsuarioRepository repository = new UsuarioRepository();


                    if (!repository.HasLogin(model.Login))
                    {

                        Usuario usuario = new Usuario();

                        usuario.DataCadastro = DateTime.Now;
                        usuario.ValidadeSenha = DateTime.Now.AddMonths(2);
                        usuario.Email = model.Email;
                        usuario.Nome = model.Nome;
                        usuario.Senha = Criptogragfia.EncriptarSenha(model.Senha);
                        usuario.Foto = model.Foto;
                        usuario.Perfis = new List<Perfil>();

                        foreach(var perfil in model.Perfis)
                        {
                            Perfil p = new Perfil();

                            p.IdPerfil = perfil.IdPerfil;
                            p.Nome = perfil.Nome;

                            usuario.Perfis.Add(p);
                        }
                        


                        repository.Insert(usuario);

                        return Request.CreateResponse(HttpStatusCode.OK, "Usuário Cadastrado com sucesso.");

                    }
                    else
                    {
                        return Request.CreateResponse(HttpStatusCode.BadRequest, "Login já cadastrado.");

                    }


                }
                catch (Exception e)
                {
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message);
                }

            }
            else
            {

                //armazenar a mensagens de erro..

                Hashtable erros = new Hashtable();

                foreach (var m in ModelState) //varrendo o ModelState..

                {

                    if (m.Value.Errors.Count > 0) //contem erro?

                    {

                        //adicionando a mensagem de erro

                        erros[m.Key] = m.Value.Errors.Select

                        (e => e.ErrorMessage);

                    }

                }

                //retornando um status 400 (BadRequest) com

                //as mensagens de erro..

                return Request.CreateResponse(HttpStatusCode.BadRequest, erros);

            }


        }


    }
}
