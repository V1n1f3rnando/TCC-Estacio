namespace ProjetoOficina.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class alteracaomdf : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TBPERFIL",
                c => new
                    {
                        IDPERFIL = c.Int(nullable: false, identity: true),
                        NOME = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.IDPERFIL);
            
            CreateTable(
                "dbo.TBUSUARIO",
                c => new
                    {
                        IDUSUARIO = c.Int(nullable: false, identity: true),
                        LOGIN = c.String(nullable: false, maxLength: 50),
                        SENHA = c.String(nullable: false, maxLength: 50),
                        NOME = c.String(nullable: false),
                        Email = c.String(),
                        FOTO = c.String(nullable: false, maxLength: 50),
                        VALIDADESENHA = c.DateTime(nullable: false),
                        DATACADASTRO = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.IDUSUARIO)
                .Index(t => t.LOGIN, unique: true, name: "ix_Login")
                .Index(t => t.FOTO, unique: true, name: "ix_Foto");
            
            CreateTable(
                "dbo.TBUSUARIOPERFIL",
                c => new
                    {
                        IDUSUARIO = c.Int(nullable: false),
                        IDPERFIL = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.IDUSUARIO, t.IDPERFIL })
                .ForeignKey("dbo.TBUSUARIO", t => t.IDUSUARIO)
                .ForeignKey("dbo.TBPERFIL", t => t.IDPERFIL)
                .Index(t => t.IDUSUARIO)
                .Index(t => t.IDPERFIL);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TBUSUARIOPERFIL", "IDPERFIL", "dbo.TBPERFIL");
            DropForeignKey("dbo.TBUSUARIOPERFIL", "IDUSUARIO", "dbo.TBUSUARIO");
            DropIndex("dbo.TBUSUARIOPERFIL", new[] { "IDPERFIL" });
            DropIndex("dbo.TBUSUARIOPERFIL", new[] { "IDUSUARIO" });
            DropIndex("dbo.TBUSUARIO", "ix_Foto");
            DropIndex("dbo.TBUSUARIO", "ix_Login");
            DropTable("dbo.TBUSUARIOPERFIL");
            DropTable("dbo.TBUSUARIO");
            DropTable("dbo.TBPERFIL");
        }
    }
}
