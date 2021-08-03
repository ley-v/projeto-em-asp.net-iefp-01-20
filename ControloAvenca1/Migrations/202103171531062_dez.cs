namespace ControloAvenca1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dez : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Avencas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Valor = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ClienteId = c.Int(nullable: false),
                        Data = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Clientes", t => t.ClienteId, cascadeDelete: true)
                .Index(t => t.ClienteId);
            
            CreateTable(
                "dbo.Clientes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Referencia = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.RegistoPagamentoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Data = c.DateTime(nullable: false),
                        Descricao = c.String(),
                        Valor = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ClienteId = c.Int(nullable: false),
                        MesId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Clientes", t => t.ClienteId, cascadeDelete: true)
                .ForeignKey("dbo.Mes", t => t.MesId, cascadeDelete: true)
                .Index(t => t.ClienteId)
                .Index(t => t.MesId);
            
            CreateTable(
                "dbo.Mes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MesDesginacao = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Logins",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Utilizador = c.String(),
                        Senha = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Avencas", "ClienteId", "dbo.Clientes");
            DropForeignKey("dbo.RegistoPagamentoes", "MesId", "dbo.Mes");
            DropForeignKey("dbo.RegistoPagamentoes", "ClienteId", "dbo.Clientes");
            DropIndex("dbo.RegistoPagamentoes", new[] { "MesId" });
            DropIndex("dbo.RegistoPagamentoes", new[] { "ClienteId" });
            DropIndex("dbo.Avencas", new[] { "ClienteId" });
            DropTable("dbo.Logins");
            DropTable("dbo.Mes");
            DropTable("dbo.RegistoPagamentoes");
            DropTable("dbo.Clientes");
            DropTable("dbo.Avencas");
        }
    }
}
