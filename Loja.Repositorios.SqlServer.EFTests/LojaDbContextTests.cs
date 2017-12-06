using Microsoft.VisualStudio.TestTools.UnitTesting;
using Loja.Repositorios.SqlServer.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Loja.Dominio;
using System.Diagnostics;
using System.Data.Entity;

namespace Loja.Repositorios.SqlServer.EF.Tests
{
    [TestClass()]
    public class LojaDbContextTests
    {
        // instância a classe do banco de dados
        private static LojaDbContext _db = new LojaDbContext();

        // método para inicialização dos testes
        [ClassInitialize]
        public static void InicializarTestes(TestContext contexto)
        {
            _db.Database.Log = LogarQueries;
        }

        // printa as queris na tela
        private static void LogarQueries(string query)
        {
            Debug.WriteLine(query);
        }

        [TestMethod()]
        public void InserirPapelariaTest()
        {
            using (var db = new LojaDbContext())
            {
                if (!db.Categorias.Any(x => x.Nome == "Papelaria"))
                {
                    // instânciei o objeto
                    Categoria papelaria = new Categoria();

                    // seta a propriedade para a papelaria
                    papelaria.Nome = "Papelaria";

                    // adicionei o objeto da classe categoria ao banco
                    db.Categorias.Add(papelaria);

                    // mandei savar o objeto
                    db.SaveChanges(); 
                }
            }

            InserirProdutoTeste();
            EditarProdutoTest();
            ExcluirProdutoTest();
        }

        // inserir produto teste
        //[TestMethod()]
        public void InserirProdutoTeste()
        {
            Produto produto = new Produto();
            produto.Estoque = 5;
            produto.Nome = "Caneta";
            produto.Preco = 22.06m;
            produto.Categoria = _db.Categorias.Where(x => x.Nome == "Papelaria").Single();
            _db.Produtos.Add(produto);
            _db.SaveChanges();
        }

        [TestMethod]
        public void InserirProdutoComNovaCategoriaTest()
        {
            if (!_db.Produtos.Any(x => x.Nome == "Barbeador"))
            {
                Produto produto = new Produto();
                produto.Estoque = 15;
                produto.Nome = "Barbeador";
                produto.Preco = 15.00m;
                produto.Categoria = new Categoria { Nome = "Perfumaria" };
                _db.Produtos.Add(produto);
                _db.SaveChanges(); 
            }
        }

        //[TestMethod]
        public void EditarProdutoTest()
        {
            Produto produto = _db.Produtos.Single(x => x.Nome == "Caneta");
            produto.Preco = 10.50m;
            _db.SaveChanges();

        }

        //[TestMethod]
        public void ExcluirProdutoTest()
        {
            if(_db.Produtos.Any(x => x.Nome == "Caneta"))
            {
                Produto produto = _db.Produtos.Single(x => x.Nome == "Caneta");
                _db.Produtos.Remove(produto);
                _db.SaveChanges();
            }

            Assert.IsFalse(_db.Produtos.Any(x => x.Nome == "Caneta"));
        }

        // carregamento tardio (ele busca o produto no banco e depois retorna ao banco para buscar a categoria
        [TestMethod]
        public void LazyLoadDesligadoTeste()
        {
            //// não usar o virtual para a propriedade categoria deixa o LazyLoad desligado
            //var produto = _db.Produtos.Single(x => x.Nome == "Barbeador");
            //Assert.IsNull(produto.Categoria);
        }

        [TestMethod]
        public void LazyLoadLigadoTeste()
        {
            // usar modificador virtual para a propriedade categoria liga o LazyLoad
            var produto = _db.Produtos.Single(p => p.Nome == "Barbeador");
            Assert.AreEqual(produto.Categoria.Nome, "Perfumaria");
        }

        // metodo com inner join
        [TestMethod]
        public void IncludeTeste()
        {
            // faz o mesmo que o LazyLoadLigado só que utiliza um inner join ao invés de fazer duas buscas
            // onde p.Categoria é a tabela de inner com com a Produto, caso queira inserir outro inner,
            // adcione mais Include(p => p.Categoria)
            var produto = _db.Produtos.Include(p => p.Categoria).Single(p => p.Nome == "Barbeador");
            Assert.AreEqual(produto.Categoria.Nome, "Perfumaria");
        }

        [TestMethod]
        public void QueryableTeste()
        {
            // concatena a string de conexão com o banco sem fazer a execução
            var query = _db.Produtos.Where(p => p.Preco > 10);

            if (true)
            {
                query = query.Where(p => p.Estoque > 5);
            }

            query = query.OrderBy(p => p.Preco);

            var primeiro = query.First();
            //var ultimo = query.Last();
            //var unico = query.Single();
            var todos = query.ToList();
        }

        // limpa a memória
        [ClassCleanup]
        public static void FinalizarTestes()
        {
            _db.Dispose();
        }
    }
}