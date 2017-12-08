using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AW.Wcf.Testes
{
    [TestClass]
    public class ProdutosTeste
    {
        [TestMethod]
        public void SelecionarTeste()
        {
            using (ProdutosServiceReference.ProdutosClient ws = new ProdutosServiceReference.ProdutosClient())
            {
                ProdutosServiceReference.Product product = new ProdutosServiceReference.Product();
                //var varProduto = ws.Selecionar(316);
                //Assert.AreEqual(varProduto.Name, "Blade");

                var varProduto = ws.SelecionarPorNome("mountain");
                Assert.AreEqual(varProduto.Length, 94);
            }

        }
    }
}
