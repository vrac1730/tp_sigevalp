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

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
        }

        // GET: Local/Index
        // Se ocupa de la primera interacción con el usuario
        public ActionResult Index()
        {            
            return View(db.Locales);
        }
        //En la ruta busca por defecto al controlador (Home), sino a la action (Index) y por último el id

        //GET: Local/Create
        public ActionResult Create() {
            return View();
        }

        //POST: Local/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,nombre,direccion,telefono,ruc,razon_social")] Local local) 
        {
            if (!ModelState.IsValid) 
                return View();            
            
            db.Locales.Add(local);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: Local/Edit
        public ActionResult Edit(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            
            Local local = db.Locales.Find(id);

            if (local == null)
                return HttpNotFound();
            
            return View(local);
        }

        // Post: Local/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,nombre,direccion,telefono,ruc,razon_social")] Local local)
        {
            if (!ModelState.IsValid)
                return View();

            var loc = db.Locales.Find(local.id);
            loc.nombre = local.nombre;
            loc.direccion = local.direccion;
            loc.telefono = local.telefono;
            loc.ruc = local.ruc;
            loc.razon_social = local.razon_social;
            db.SaveChanges();
            return RedirectToAction("Index");            
        }
    }
}