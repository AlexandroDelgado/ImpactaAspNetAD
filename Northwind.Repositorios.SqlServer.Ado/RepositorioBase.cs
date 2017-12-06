using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Northwind.Repositorios.SqlServer.Ado
{
    public class RepositorioBase
    {
        public DataTable Selecionar(string instrucao, params SqlParameter[] parametros)
        {
            var dataTable = new DataTable();
            var stringConexao =
                ConfigurationManager.ConnectionStrings["northwindConnectionString"].ConnectionString;

            using (var conexao = new SqlConnection(stringConexao))
            {
                conexao.Open();

                //var instrucao = @"SELECT 
                //                              [ProductName]
                //                              ,[UnitPrice]
                //                              ,[UnitsInStock]
                //                          FROM [Northwind].[dbo].[Products]
                //                          Where CategoryID = @CategoryID";

                using (var comando = new SqlCommand(instrucao, conexao))
                {
                    //comando.Parameters.AddWithValue("@CategoryID", categoriaId);
                    if (parametros != null)
                    {
                        comando.Parameters.AddRange(parametros);
                    }

                    using (var dataAdapter = new SqlDataAdapter(comando))
                    {
                        dataAdapter.Fill(dataTable);
                    }
                }

                //conexao.Close();
            }

            return dataTable;
        }
    }
}