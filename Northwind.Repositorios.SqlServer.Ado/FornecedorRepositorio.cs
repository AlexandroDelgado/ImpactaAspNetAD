using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Repositorios.SqlServer.Ado
{
    public class FornecedorRepositorio : RepositorioBase
    {
        public DataTable Selecionar()
        {
            var instrucao = @"SELECT [SupplierID]
                                          ,[CompanyName]
                                      FROM [Northwind].[dbo].[Suppliers]
                                      Order by CompanyName";

            return base.Selecionar(instrucao);
        }
    }
}
