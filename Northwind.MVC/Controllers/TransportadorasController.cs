using Northwind.Dominio;
using Northwind.Repositorios.SqlServer.Ado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Northwind.MVC.Controllers
{
    public class TransportadorasController : Controller
    {
        TransportadoraRepositorio _repositorio = new TransportadoraRepositorio();

        // GET: Produtos
        public ActionResult Index()
        {
            return View(_repositorio.Selecionar());
        }

        // GET: Produtos/Details/5
        public ActionResult Details(int id)
        {
            return View(_repositorio.Selecionar(id));
        }

        // GET: Produtos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Produtos/Create
        [HttpPost]
        public ActionResult Create(Transportadora tranportadora)
        {
            try
            {
                _repositorio.Inserir(tranportadora);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Produtos/Edit/5
        public ActionResult Edit(int id)
        {
            return View(_repositorio.Selecionar(id));
        }

        // POST: Produtos/Edit/5
        [HttpPost]
        public ActionResult Edit(Transportadora transportadora)
        {
            try
            {
                _repositorio.Atualizar(transportadora);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Produtos/Delete/5
        public ActionResult Delete(int id)
        {
            return View(_repositorio.Selecionar(id));
        }

        // POST: Produtos/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Transportadora transportadora)
        {
            try
            {
                _repositorio.Excluir(id);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
