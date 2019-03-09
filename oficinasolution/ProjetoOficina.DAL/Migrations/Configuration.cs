namespace ProjetoOficina.DAL.Migrations
{
    using ProjetoOficina.Entidades;
    using ProjetoOficina.Util;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ProjetoOficina.DAL.Context.DataContext>
    {
        public Configuration()
        {
            //permissão para CREATE ou ALTER na base de dados
            AutomaticMigrationsEnabled = true;
            //permissão para DROP..
            AutomaticMigrationDataLossAllowed = true;
        }

      
        protected override void Seed(ProjetoOficina.DAL.Context.DataContext context)
        {
            context.Perfil.AddOrUpdate(
                new Perfil { IdPerfil = 1, Nome = "Administrador" },
                new Perfil { IdPerfil = 2, Nome = "Colaborador" }
                
            );


            context.Usuario.AddOrUpdate(
            new Usuario
            {
                IdUsuario = 1,
                Nome = "Administrador",
                Login = "adm",
                Senha = Criptogragfia.EncriptarSenha("projetooficinati"),
                Foto = "adm.jpg",
                Email = "oficinaprojetoti@gmail.com",
                DataCadastro = DateTime.Now,
                ValidadeSenha = DateTime.Now.AddMonths(2),
                Perfis = new List<Perfil> {
                    context.Perfil.Find(1) 
                }
            }
            );
        }
    }
}
