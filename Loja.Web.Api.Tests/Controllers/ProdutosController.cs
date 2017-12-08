using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Collections.Generic;
using Loja.Repositorios.SqlServer.EF;
using Loja.Dominio;
using System.Web.Http.Description;

namespace Loja.WebApi.Controllers
{
    public class ProdutosController : ApiController
    {
        private LojaDbContext db = new LojaDbContext();

        public ProdutosController()
        {
            db.Configuration.ProxyCreationEnabled = false;
        }

        // GET: api/Produtos
        public IQueryable<Produto> GetProdutos()
        {
            return db.Produtos.Include(p => p.Categoria);
        }

        // GET: api/Produtos/5
        [ResponseType(typeof(Produto))]
        public IHttpActionResult GetProduto(int id)
        {
            var produto = db.Produtos.Include(p => p.Categoria).SingleOrDefault(p => p.Id == id);

            if (produto == null)
            {
                return NotFound();
            }

            return Ok(produto);
        }

        [Route("api/Produtos/GetByCategoria/{id}")]
        public List<Produto> GetByCategoria(int id)
        {
            return db.Produtos.Where(p => p.Categoria.Id == id).Include(p => p.Categoria).ToList();
        }

        // PUT: api/Produtos/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutProduto(int id, Produto produto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != produto.Id)
            {
                return BadRequest();
            }

            db.Entry(produto).State = EntityState.Modified;

            produto.Categoria = db.Categorias.Single(c => c.Id == produto.Categoria.Id);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProdutoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Produtos
        [ResponseType(typeof(Produto))]
        public IHttpActionResult PostProduto(Produto produto)
        {
            if (produto == null)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            produto.Categoria = db.Categorias.Single(c => c.Id == produto.Categoria.Id);

            db.Produtos.Add(produto);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = produto.Id }, produto);
        }

        // DELETE: api/Produtos/5
        [ResponseType(typeof(Produto))]
        public IHttpActionResult DeleteProduto(int id)
        {
            Produto produto = db.Produtos.Find(id);

            if (produto == null)
            {
                return NotFound();
            }

            db.Produtos.Remove(produto);
            db.SaveChanges();

            return Ok(produto);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ProdutoExists(int id)
        {
            return db.Produtos.Count(e => e.Id == id) > 0;
        }
    }
}