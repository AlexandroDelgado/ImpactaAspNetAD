using Microsoft.VisualStudio.TestTools.UnitTesting;
using Northwind.Repositorios.SqlServer.Ado;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Repositorios.SqlServer.Ado.Tests
{
    [TestClass()]
    public class CategoriaRepositorioTests
    {
        [TestMethod()]
        public void SelecionarTest()
        {
            var repositorio = new CategoriaRepositorio();

            var categoriaDataTable = repositorio.Selecionar();

            Assert.AreNotEqual(0, categoriaDataTable.Rows.Count);

            foreach (DataRow registro in categoriaDataTable.Rows)
            {
                Console.WriteLine($"{registro["CategoryID"]} - {registro[1]}");
            }
        }
    }
}