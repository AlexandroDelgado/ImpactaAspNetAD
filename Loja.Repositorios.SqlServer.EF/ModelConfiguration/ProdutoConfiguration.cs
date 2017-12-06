using Loja.Dominio;
using System.Data.Entity.ModelConfiguration;

namespace Loja.Repositorios.SqlServer.EF.ModelConfiguration
{
    internal class ProdutoConfiguration : EntityTypeConfiguration<Produto>
    {
        public ProdutoConfiguration()
        {
            // configuração para o campo nome na tabela produto no banco de dados
            Property(x => x.Nome).IsRequired().HasMaxLength(200).HasColumnType("nvarchar");
            // configuração do campo preço
            Property(x => x.Preco).IsRequired().HasPrecision(9,2);
            // configuração do campo categoria, que é um campo referêncial da tabela categoria
            HasRequired(x => x.Categoria);

            HasOptional(x => x.Imagem).WithRequired(pi => pi.Produto).WillCascadeOnDelete(true);

        }
    }
}