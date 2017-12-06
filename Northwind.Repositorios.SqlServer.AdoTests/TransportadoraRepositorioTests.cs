using Microsoft.VisualStudio.TestTools.UnitTesting;
using Northwind.Dominio;
using Northwind.Repositorios.SqlServer.Ado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Repositorios.SqlServer.Ado.Tests
{
    [TestClass()]
    public class TransportadoraRepositorioTests
    {
        TransportadoraRepositorio _repositorio = new TransportadoraRepositorio();

        [TestMethod()]
        public void SelecionarTest()
        {
            var transportadoras = _repositorio.Selecionar();

            Assert.AreNotEqual(0, transportadoras.Count);

            foreach (var transportadora in transportadoras)
            {
                Console.WriteLine($"{transportadora.Nome} - {transportadora.Telefone}");
            }
        }

        [TestMethod()]
        public void SelecionarPorIdTest()
        {
            var transportadora = _repositorio.Selecionar(1);
            Assert.IsNotNull(transportadora);

            transportadora = _repositorio.Selecionar(4);
            Assert.IsNull(transportadora);

        }

        [TestMethod()]
        public void CudTest()
        {
            var transportadora = new Transportadora();

            transportadora.Nome = "Correios";
            transportadora.Telefone = "(503) 555-3140";
            _repositorio.Inserir(transportadora);
            Assert.IsTrue(transportadora.Id > 0);

            //transportadora.Id = 19;
            transportadora.Nome = "Correios BR";
            transportadora.Telefone = "(11) 9999-9999";
            _repositorio.Atualizar(transportadora);

            transportadora = _repositorio.Selecionar(transportadora.Id);
            Assert.AreEqual("Correios BR", transportadora.Nome);

            _repositorio.Excluir(transportadora.Id);
            transportadora = _repositorio.Selecionar(transportadora.Id);
            Assert.IsNull(transportadora);
        }
    }
}