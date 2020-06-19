namespace BrunoTragl.CadastroFuncionario.Infrastructure.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class start : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.funcionarios",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Sobrenome = c.String(),
                        DataNascimento = c.DateTime(nullable: false),
                        Email = c.String(),
                        Sexo = c.String(),
                        Ativo = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.habilidades",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        FuncionarioID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.funcionarios", t => t.FuncionarioID, cascadeDelete: true)
                .Index(t => t.FuncionarioID);
            
            CreateTable(
                "dbo.habilidadesUnico",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Habilidade = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.habilidades", "FuncionarioID", "dbo.funcionarios");
            DropIndex("dbo.habilidades", new[] { "FuncionarioID" });
            DropTable("dbo.habilidadesUnico");
            DropTable("dbo.habilidades");
            DropTable("dbo.funcionarios");
        }
    }
}
