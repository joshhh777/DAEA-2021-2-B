using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using System.Data.Entity;

namespace Practica4.Models
{
    public class PrestamosController : Controller
    {
        // GET: Prestamos
        #region Contexto
        private BibliotecaEntities _contexto;

        public BibliotecaEntities Contexto
        {
            set { _contexto = value; }
            get
            {
                if (_contexto == null)
                    _contexto = new BibliotecaEntities();
                return _contexto;
            }
        }
        #endregion
        public ActionResult Index()
        {
            return View(Contexto.Prestamos.ToList());
        }
        public ActionResult Details(int id)
        {
            var PrestamosLista = from p in Contexto.Prestamos
                                        select p;
            return View(PrestamosLista.ToList());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Prestamos nuevoPrestamo)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Contexto.Prestamos.Add(nuevoPrestamo);
                    Contexto.SaveChanges();

                    return RedirectToAction("Index");
                }
                return View(nuevoPrestamo);
            }
            catch
            {
                return View();
            }
        }
        public ActionResult Edit(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            Prestamos PrestamoEditar = Contexto.Prestamos.Find(id);
            if (PrestamoEditar == null)
                return HttpNotFound();

            return View(PrestamoEditar);
        }
        [HttpPost]
        public ActionResult Edit(Prestamos PrestamoEditar)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Contexto.Entry(PrestamoEditar).State = EntityState.Modified;
                    Contexto.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(PrestamoEditar);
            }
            catch
            {
                return View();
            }
        }
        public ActionResult Delete(int id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            Prestamos PrestamoEliminar = Contexto.Prestamos.Find(id);

            if (PrestamoEliminar == null)
                return HttpNotFound();
            return View(PrestamoEliminar);
        }

        [HttpPost]
        public ActionResult Delete(int? id, Prestamos Prestamo)
        {
            try
            {
                Prestamos PrestamoEliminar = new Prestamos();
                if (ModelState.IsValid)
                {
                    if (id == null)
                        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                    PrestamoEliminar = Contexto.Prestamos.Find(id);
                    if (PrestamoEliminar == null)
                        return HttpNotFound();
                    Contexto.Prestamos.Remove(PrestamoEliminar);
                    Contexto.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(PrestamoEliminar);
            }
            catch
            {
                return View();
            }
        }
    }
}