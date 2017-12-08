using Loja.Repositorios.SqlServer.EF;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Loja.Mvc.Controllers
{
    public class ProdutoImagemController : Controller
    {
        private LojaDbContext _db = new LojaDbContext();

        // GET: ProdutoImagem
        public ActionResult Index(int produtoId)
        {
            var imagem = _db.Produtos.Select(p => p.Imagem).SingleOrDefault(pi => pi.ProdutoId == produtoId);
            return File(imagem.Bytes, imagem.ContentType);
        }

        public static byte[] ObterMiniatura(byte[] imagem, int largura, int altura)
        {
            using (var stream = new MemoryStream())
            {
                using (var miniatura = Image.FromStream(new MemoryStream(imagem)).GetThumbnailImage(largura, altura, null, new IntPtr()))
                {
                    miniatura.Save(stream, ImageFormat.Png);
                    return stream.ToArray();
                }
            }
        }

        public ActionResult Miniatura(int produtoId, int largura = 25, int altura = 25)
        {
            var imagem = _db.Produtos.Select(p => p.Imagem).SingleOrDefault(pi => pi.ProdutoId == produtoId);
            return File(ObterMiniatura(imagem.Bytes, largura, altura), imagem.ContentType);
        }

    }
}