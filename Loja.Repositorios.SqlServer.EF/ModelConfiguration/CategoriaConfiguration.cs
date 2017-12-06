using Loja.Dominio;
using System.Data.Entity.ModelConfiguration;

namespace Loja.Repositorios.SqlServer.EF.ModelConfiguration
{
    internal class CategoriaConfiguration : EntityTypeConfiguration<Categoria>
    {
        public CategoriaConfiguration()
        {
            // configuração para o campo nome na tabela categoria no banco de dados
            Property(x => x.Nome).IsRequired().HasMaxLength(50).HasColumnType("nvarchar");
        }
    }
}