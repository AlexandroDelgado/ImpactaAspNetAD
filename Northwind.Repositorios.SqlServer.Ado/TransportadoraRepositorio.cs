using Northwind.Dominio;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace Northwind.Repositorios.SqlServer.Ado
{
    public class TransportadoraRepositorio:RepositorioListBase
    {
        private string _stringConexao = ConfigurationManager.ConnectionStrings["northwindConnectionString"].ConnectionString;

        public List<Transportadora> Selecionar()
        {
            //var transportadoras = new List<Transportadora>();

            //using (var conexao = new SqlConnection(_stringConexao))
            //{
            //    conexao.Open();

            //    using (var comando = new SqlCommand("TransportadoraSelecionar", conexao))
            //    {
            //        comando.CommandType = CommandType.StoredProcedure;

            //        using (var registro = comando.ExecuteReader())
            //        {
            //            while (registro.Read())
            //            {
            //                transportadoras.Add(Mapear(registro));
            //            }
            //        }
            //    }
            //}

            //return transportadoras;

            return base.ExecuteReader("TransportadoraSelecionar", Mapear, null);
        }

        public Transportadora Selecionar(int id)
        {
            return base.ExecuteReader("TransportadoraSelecionar", Mapear, new SqlParameter("@ShipperId", id)).SingleOrDefault();
            //Transportadora transportadora = null;

            //using (var conexao = new SqlConnection(_stringConexao))
            //{
            //    conexao.Open();

            //    using (var comando = new SqlCommand("TransportadoraSelecionar", conexao))
            //    {
            //        comando.CommandType = CommandType.StoredProcedure;
            //        comando.Parameters.Add(new SqlParameter("@shipperId", id));

            //        using (var registro = comando.ExecuteReader())
            //        {
            //            if (registro.Read())
            //            {
            //                transportadora = Mapear(registro);
            //            }
            //        }
            //    }
            //}

            //return transportadora;
            
        }

        public void Inserir(Transportadora transportadora)
        {
            //using (var conexao = new SqlConnection(_stringConexao))
            //{
            //    conexao.Open();

            //    using (var comando = new SqlCommand("TransportadoraInserir", conexao))
            //    {
            //        comando.CommandType = CommandType.StoredProcedure;
            //        comando.Parameters.AddRange(Mapear(transportadora));
            //        // retorna apenas uma celula, caso queira retornar mais registros e células, utilize o ExecuteRead
            //        transportadora.Id = Convert.ToInt32(comando.ExecuteScalar());
            //    }
            //}
            
            transportadora.Id = Convert.ToInt32(base.ExecuteScalar("TransportadoraInserir", Mapear(transportadora)));
        }
        
        public void Atualizar(Transportadora transportadora)
        {
            //using (var conexao = new SqlConnection(_stringConexao))
            //{
            //    conexao.Open();

            //    using (var comando = new SqlCommand("TransportadoraAtualizar", conexao))
            //    {
            //        comando.CommandType = CommandType.StoredProcedure;
            //        comando.Parameters.AddRange(Mapear(transportadora));
            //        comando.ExecuteNonQuery();
            //    }
            //}

            base.ExecuteNonQuery("TransportadoraAtualizar", Mapear(transportadora));
        }

        public void Excluir(int id)
        {
            //using (var conexao = new SqlConnection(_stringConexao))
            //{
            //    conexao.Open();

            //    using (var comando = new SqlCommand("TransportadoraExcluir", conexao))
            //    {
            //        comando.CommandType = CommandType.StoredProcedure;
            //        comando.Parameters.AddWithValue("@shipperID", id);
            //        comando.ExecuteNonQuery();
            //    }
            //}

            base.ExecuteNonQuery("TransportadoraExcluir", new SqlParameter("@shipperID", id));
        }

        private SqlParameter[] Mapear(Transportadora transportadora)
        {
            var parametros = new List<SqlParameter>();

            if(transportadora.Id > 0)
            {
                parametros.Add(new SqlParameter("@shipperID", transportadora.Id));
            }

            parametros.Add(new SqlParameter("@CompanyName", transportadora.Nome));
            parametros.Add(new SqlParameter("@phone", transportadora.Telefone));

            return parametros.ToArray();
        }

        private Transportadora Mapear(SqlDataReader registro)
        {
            var transportadora = new Transportadora();

            transportadora.Id = Convert.ToInt32(registro["ShipperId"]);
            transportadora.Nome = registro["CompanyName"].ToString();
            transportadora.Telefone = Convert.ToString(registro["Phone"]);

            return transportadora;
        }
    }
}
