using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using System.Data.Entity;

namespace lab14.Controllers
{
    public class ProductsController : Controller
    {
        // GET: Products
        #region Contexto
        private NorthwndEntities _contexto;

        public NorthwndEntities Contexto
        {
            set { _contexto = value; }
            get
            {
                if (_contexto == null)
                    _contexto = new NorthwndEntities();
                return _contexto;
            }
        }
        #endregion
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult EditProducts(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            Products ProductsEditar = Contexto.Products.Find(id);
            if (ProductsEditar == null)
                return HttpNotFound();

            return View(ProductsEditar);
        }
        [HttpPost]
        public ActionResult EditProducts(Products ProductsEditar)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Contexto.Entry(ProductsEditar).State = EntityState.Modified;
                    Contexto.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(ProductsEditar);
            }
            catch
            {
                return View();
            }
        }
    }
}