using Loja.Dominio;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Loja.Mvc.Models
{
    public class ProdutoViewModel
    {
        public int Id { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        [Display(Name = "Categoria")]
        public string CategoriaNome { get; set; }

        [Required]
        [Display(Name = "Preço")]
        public decimal Preco { get; set; }

        [Required]
        public int Estoque { get; set; }

        public bool Ativo { get; set; }

        public int? CategoriaId { get; set; }

        public List<SelectListItem> Categorias { get; set; }

        [Required]
        [Display(Name = "Imagem do Produto")]
        public HttpPostedFileBase Imagem { get; set; }
    }
}