using Northwind.Dominio;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Northwind.Repositorios.SqlServer.Ado
{
    public abstract class RepositorioListBase
    {
        private string _stringConexao = ConfigurationManager.ConnectionStrings["northwindConnectionString"].ConnectionString;

        protected delegate T MapearDelegate<T>(SqlDataReader registro);

        protected void ExecuteNonQuery(string nomeProcedure, params SqlParameter[] parametros)
        {
            using (var conexao = new SqlConnection(_stringConexao))
            {
                conexao.Open();

                using (var comando = new SqlCommand(nomeProcedure, conexao))
                {
                    comando.CommandType = CommandType.StoredProcedure;
                    if (parametros != null)
                    {
                        comando.Parameters.AddRange(parametros); 
                    }
                    comando.ExecuteNonQuery();
                }
            }
        }

        protected object ExecuteScalar(string nomeProcedure, params SqlParameter[] parametros)
        {
            using (var conexao = new SqlConnection(_stringConexao))
            {
                conexao.Open();

                using (var comando = new SqlCommand(nomeProcedure, conexao))
                {
                    comando.CommandType = CommandType.StoredProcedure;

                    if (parametros != null)
                    {
                        comando.Parameters.AddRange(parametros);
                    }

                    return comando.ExecuteScalar();
                }
            }
        }

        protected List<T> ExecuteReader<T>(string nomeProcedure, MapearDelegate<T> metodoMapeamento, params SqlParameter[] parametros)
        {
            var lista = new List<T>();

            using (var conexao = new SqlConnection(_stringConexao))
            {
                conexao.Open();

                using (var comando = new SqlCommand(nomeProcedure, conexao))
                {
                    comando.CommandType = CommandType.StoredProcedure;

                    if (parametros != null)
                    {
                        comando.Parameters.AddRange(parametros);
                    }

                    using (var registro = comando.ExecuteReader())
                    {
                        while (registro.Read())
                        {
                            lista.Add(metodoMapeamento(registro));
                        }
                    }
                }
            }

            return lista;
        }
    }
}