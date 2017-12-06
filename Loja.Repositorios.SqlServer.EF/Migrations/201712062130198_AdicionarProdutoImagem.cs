namespace Loja.Repositorios.SqlServer.EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AdicionarProdutoImagem : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ProdutoImagem",
                c => new
                    {
                        ProdutoId = c.Int(nullable: false),
                        Bytes = c.Binary(),
                        ContentType = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.ProdutoId)
                .ForeignKey("dbo.Produto", t => t.ProdutoId, cascadeDelete: true)
                .Index(t => t.ProdutoId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProdutoImagem", "ProdutoId", "dbo.Produto");
            DropIndex("dbo.ProdutoImagem", new[] { "ProdutoId" });
            DropTable("dbo.ProdutoImagem");
        }
    }
}
