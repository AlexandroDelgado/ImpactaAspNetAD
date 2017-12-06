using Microsoft.VisualStudio.TestTools.UnitTesting;
using Northwind.Repositorios.SqlServer.Ado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Repositorios.SqlServer.Ado.Tests
{
    [TestClass()]
    public class FornecedorRepositorioTests
    {
        [TestMethod()]
        public void SelecionarTest()
        {
            var repositorio = new FornecedorRepositorio();

            var dataTable = repositorio.Selecionar();

            Assert.IsTrue(dataTable.Rows.Count != 0);
        }
    }
}