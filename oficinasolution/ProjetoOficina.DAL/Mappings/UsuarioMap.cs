using ProjetoOficina.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoOficina.DAL.Mappings
{
    public class UsuarioMap : EntityTypeConfiguration<Usuario>
    {
        public UsuarioMap()
        {

            ToTable("TBUSUARIO");

            HasKey(u => u.IdUsuario);

            Property(u => u.IdUsuario).HasColumnName("IDUSUARIO")
                                      .IsRequired();

            Property(u => u.Login).HasMaxLength(50)
                                  .HasColumnName("LOGIN")
                                  .IsRequired()
                                  .HasColumnAnnotation(IndexAnnotation.AnnotationName,
                                    new IndexAnnotation(new IndexAttribute("ix_Login") { IsUnique = true }));

            Property(u => u.Senha).HasColumnName("SENHA")
                                  .HasMaxLength(50)
                                  .IsRequired();

            Property(u => u.Foto).HasColumnName("FOTO")
                                 .HasMaxLength(50)
                                 .IsRequired()
                                 .HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(new IndexAttribute("ix_Foto") { IsUnique = true }));

            Property(u => u.Nome).HasColumnName("NOME")
                                 .IsRequired();

            Property(u => u.DataCadastro).HasColumnName("DATACADASTRO")

                                  .IsRequired();

            Property(u => u.ValidadeSenha).HasColumnName("VALIDADESENHA")

                                 .IsRequired();

            HasMany(u => u.Perfis)
                .WithMany(p => p.Usuarios)
                .Map(
                        map =>
                            {
                                 
                                 map.ToTable("TBUSUARIOPERFIL");
                                 
                                 map.MapLeftKey("IDUSUARIO");

                                map.MapRightKey("IDPERFIL");
                            }
                    );


        }

    }
}
