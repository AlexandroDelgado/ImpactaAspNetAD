using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Repositorios.SqlServer.Ado
{
    public class ProdutoRepositorio : RepositorioBase
    {
        //Todo: refatorar para usar o base.Selecionar()
        public DataTable SelecionarPorCategoria(int categoriaId)
        {
            var produtoDataTable = new DataTable();
            var stringConexao =
                ConfigurationManager.ConnectionStrings["northwindConnectionString"].ConnectionString;

            using (var conexao = new SqlConnection(stringConexao))
            {
                conexao.Open();

                var instrucao = @"SELECT 
                                              [ProductName]
                                              ,[UnitPrice]
                                              ,[UnitsInStock]
                                          FROM [Northwind].[dbo].[Products]
                                          Where CategoryID = @CategoryID";

                using (var comando = new SqlCommand(instrucao, conexao))
                {
                    comando.Parameters.AddWithValue("@CategoryID", categoriaId);

                    using (var dataAdapter = new SqlDataAdapter(comando))
                    {
                        dataAdapter.Fill(produtoDataTable);
                    }
                }

                //conexao.Close();
            }

            return produtoDataTable;
        }

        public DataTable SelecionarPorFornecedor(int fornecedorId)
        {
            var instrucao = @"SELECT 
                                              [ProductName]
                                              ,[UnitPrice]
                                              ,[UnitsInStock]
                                          FROM [Northwind].[dbo].[Products]
                                          Where SupplierId = @SupplierId";

            //var parametros = new SqlParameter[1];
            //parametros[0] = new SqlParameter("SupplierId", fornecedorId);

            return base.Selecionar(instrucao, 
                new SqlParameter("SupplierId", fornecedorId));
        }
    }
}
