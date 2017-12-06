using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Repositorios.SqlServer.Ado
{
    public class CategoriaRepositorio
    {
        public DataTable Selecionar()
        {
            var categoriaDataTable = new DataTable();
            var stringConexao = @"Server=.\SqlExpress; Database=Northwind; Trusted_Connection=True";

            using (var conexao = new SqlConnection(stringConexao))
            {
                conexao.Open();

                var instrucao = @"SELECT [CategoryID]
                                              ,[CategoryName]
                                          FROM [Northwind].[dbo].[Categories]";

                using (var comando = new SqlCommand(instrucao, conexao))
                {
                    using (var dataAdapter = new SqlDataAdapter(comando))
                    {
                        dataAdapter.Fill(categoriaDataTable);
                    }
                }

                //conexao.Close();
            }

            return categoriaDataTable;
        }
    }
}
