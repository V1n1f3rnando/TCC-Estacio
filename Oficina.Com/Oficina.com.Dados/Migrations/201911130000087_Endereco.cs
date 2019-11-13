namespace Oficina.com.Dados.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Endereco : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Endereco", "Complemento", c => c.String(maxLength: 8000, unicode: false));
            AlterColumn("dbo.Endereco", "UF", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Endereco", "UF", c => c.String(maxLength: 8000, unicode: false));
            DropColumn("dbo.Endereco", "Complemento");
        }
    }
}
