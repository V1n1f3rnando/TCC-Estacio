namespace Oficina.com.Dados.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class alteracaoColaborador : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Colaborador", "Cpf", c => c.String(maxLength: 8000, unicode: false));
            AddColumn("dbo.Colaborador", "DataNascimento", c => c.DateTime(nullable: false));
            AddColumn("dbo.Colaborador", "EstadoCivil", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Colaborador", "EstadoCivil");
            DropColumn("dbo.Colaborador", "DataNascimento");
            DropColumn("dbo.Colaborador", "Cpf");
        }
    }
}
