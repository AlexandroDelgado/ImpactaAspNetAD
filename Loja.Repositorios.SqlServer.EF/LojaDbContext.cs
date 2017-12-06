using Loja.Dominio;
using Loja.Repositorios.SqlServer.EF.Migrations;
using Loja.Repositorios.SqlServer.EF.ModelConfiguration;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loja.Repositorios.SqlServer.EF
{
    public class LojaDbContext: DbContext
    {
        public LojaDbContext() : base("name=lojaConnectionString")
        {
            //Database.SetInitializer(new LojaDbInitializer());

            // Para migrar o banco para a ultima versão faça
            // Enable_migrations - digitar no consolde do Nuget.
            // Update-Database

            Database.SetInitializer(new MigrateDatabaseToLatestVersion<LojaDbContext, Configuration>());
        }

        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Categoria> Categorias { get; set; }

        // efetua as configurações para a geração do banco
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // cria o objeto model
            base.OnModelCreating(modelBuilder);

            // remove as pluralidades do banco
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            // cria os modelos das tabelas
            modelBuilder.Configurations.Add(new ProdutoConfiguration());
            modelBuilder.Configurations.Add(new ProdutoImagemConfiguration());
            modelBuilder.Configurations.Add(new CategoriaConfiguration());

        }
    }
}
