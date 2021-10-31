using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SIGEVALP.Models;
using System.Net;

namespace SIGEVALP.Controllers
{
    public class LocalController : Controller
    {
        // Instancia definida para llamar las a clases de la tabla
        private ApplicationDbContext db;

        public LocalController()
        {
            db = new ApplicationDbContext();
        }
        
        // GET: Local/Index
        // Se ocupa de la primera interacción con el usuario
        public ActionResult Index()
        {
            var localInDb = db.Locales.ToList(); 
            return View(localInDb);
        }
        //En la ruta busca por defecto al controlador (Home), sino a la action (Index) y por último el id

        //GET: Local/Create
        public ActionResult Create() {
            return View();
        }

        //POST: Local/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Local local) {

            if (ModelState.IsValid) {
                db.Locales.Add(local);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(local);
        }

        // GET: Local/Edit
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Local local = db.Locales.Find(id);
            if (local == null)
            {
                return HttpNotFound();
            }
            return View(local);
        }

        // Post: Local/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Local local)
        {
            if (ModelState.IsValid)
            {
                var loc = db.Locales.Find(local.id);
                loc.nombre = local.nombre;
                loc.direccion = local.direccion;
                loc.telefono = local.telefono;
                loc.ruc = local.ruc;
                loc.razon_social = local.razon_social;

                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(local);
        }
    }
}