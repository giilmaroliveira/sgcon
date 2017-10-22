namespace SgCon.API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Condominio",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Descricao = c.String(unicode: false),
                        Cnpj = c.String(unicode: false),
                        NumPredios = c.Int(nullable: false),
                        Active = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Predio",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Descricao = c.String(unicode: false),
                        IdCondominio = c.Int(nullable: false),
                        Active = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Condominio", t => t.IdCondominio, cascadeDelete: true)
                .Index(t => t.IdCondominio);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Predio", "IdCondominio", "dbo.Condominio");
            DropIndex("dbo.Predio", new[] { "IdCondominio" });
            DropTable("dbo.Predio");
            DropTable("dbo.Condominio");
        }
    }
}
