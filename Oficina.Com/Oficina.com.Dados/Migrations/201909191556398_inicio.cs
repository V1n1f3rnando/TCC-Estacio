namespace Oficina.com.Dados.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class inicio : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cliente",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(maxLength: 8000, unicode: false),
                        DataNascimento = c.DateTime(nullable: false),
                        Cpf = c.String(maxLength: 8000, unicode: false),
                        Email = c.String(maxLength: 8000, unicode: false),
                        Telefone = c.String(maxLength: 8000, unicode: false),
                        EnderecoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Endereco", t => t.EnderecoId)
                .Index(t => t.EnderecoId);
            
            CreateTable(
                "dbo.Endereco",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Rua = c.String(maxLength: 8000, unicode: false),
                        Numero = c.String(maxLength: 8000, unicode: false),
                        Bairro = c.String(maxLength: 8000, unicode: false),
                        UF = c.String(maxLength: 8000, unicode: false),
                        Cep = c.String(maxLength: 8000, unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Veiculo",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Placa = c.String(maxLength: 8000, unicode: false),
                        Ano = c.String(maxLength: 8000, unicode: false),
                        Tipo = c.Int(nullable: false),
                        Modelo = c.String(maxLength: 8000, unicode: false),
                        Cor = c.String(maxLength: 8000, unicode: false),
                        Motor = c.String(maxLength: 8000, unicode: false),
                        Obs = c.String(maxLength: 8000, unicode: false),
                        ClienteId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cliente", t => t.ClienteId)
                .Index(t => t.ClienteId);
            
            CreateTable(
                "dbo.Colaborador",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(maxLength: 8000, unicode: false),
                        Email = c.String(maxLength: 8000, unicode: false),
                        Telefone = c.String(maxLength: 8000, unicode: false),
                        Cargo = c.Int(nullable: false),
                        Salario = c.Decimal(nullable: false, precision: 18, scale: 2),
                        EnderecoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Endereco", t => t.EnderecoId)
                .Index(t => t.EnderecoId);
            
            CreateTable(
                "dbo.Fornecedor",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Razao = c.String(maxLength: 8000, unicode: false),
                        Cnpj = c.String(maxLength: 8000, unicode: false),
                        Telefone = c.String(maxLength: 8000, unicode: false),
                        Email = c.String(maxLength: 8000, unicode: false),
                        Endereco = c.String(maxLength: 8000, unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Historico",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TipoVeiculo = c.String(maxLength: 8000, unicode: false),
                        UltimaVisita = c.DateTime(nullable: false),
                        Motivo = c.String(maxLength: 8000, unicode: false),
                        UltimoOrcamento = c.String(maxLength: 8000, unicode: false),
                        VeiculoId = c.Int(nullable: false),
                        ColaboradorId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Colaborador", t => t.ColaboradorId)
                .ForeignKey("dbo.Veiculo", t => t.VeiculoId)
                .Index(t => t.VeiculoId)
                .Index(t => t.ColaboradorId);
            
            CreateTable(
                "dbo.OrdemServico",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Motivo = c.String(maxLength: 8000, unicode: false),
                        DataAbertura = c.DateTime(nullable: false),
                        Orçamento = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Status = c.Int(nullable: false),
                        Placa = c.String(maxLength: 8000, unicode: false),
                        Obs = c.String(maxLength: 8000, unicode: false),
                        ColaboradorId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Colaborador", t => t.ColaboradorId)
                .Index(t => t.ColaboradorId);
            
            CreateTable(
                "dbo.Produto",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Imagem = c.String(maxLength: 8000, unicode: false),
                        Nome = c.String(maxLength: 8000, unicode: false),
                        ValorUnitario = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Quantidade = c.Decimal(nullable: false, precision: 18, scale: 2),
                        FornecedorId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Fornecedor", t => t.FornecedorId)
                .Index(t => t.FornecedorId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Produto", "FornecedorId", "dbo.Fornecedor");
            DropForeignKey("dbo.OrdemServico", "ColaboradorId", "dbo.Colaborador");
            DropForeignKey("dbo.Historico", "VeiculoId", "dbo.Veiculo");
            DropForeignKey("dbo.Historico", "ColaboradorId", "dbo.Colaborador");
            DropForeignKey("dbo.Colaborador", "EnderecoId", "dbo.Endereco");
            DropForeignKey("dbo.Veiculo", "ClienteId", "dbo.Cliente");
            DropForeignKey("dbo.Cliente", "EnderecoId", "dbo.Endereco");
            DropIndex("dbo.Produto", new[] { "FornecedorId" });
            DropIndex("dbo.OrdemServico", new[] { "ColaboradorId" });
            DropIndex("dbo.Historico", new[] { "ColaboradorId" });
            DropIndex("dbo.Historico", new[] { "VeiculoId" });
            DropIndex("dbo.Colaborador", new[] { "EnderecoId" });
            DropIndex("dbo.Veiculo", new[] { "ClienteId" });
            DropIndex("dbo.Cliente", new[] { "EnderecoId" });
            DropTable("dbo.Produto");
            DropTable("dbo.OrdemServico");
            DropTable("dbo.Historico");
            DropTable("dbo.Fornecedor");
            DropTable("dbo.Colaborador");
            DropTable("dbo.Veiculo");
            DropTable("dbo.Endereco");
            DropTable("dbo.Cliente");
        }
    }
}
