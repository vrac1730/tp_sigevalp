using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SIGEVALP.Models;

namespace SIGEVALP.Controllers
{
    public class CategoriaController : Controller
    {
        private ApplicationDbContext db;

        public CategoriaController()
        {
            db = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
        }

        // GET: Categoria
        public ActionResult Index()
        {            
            return View(db.Categorias);
        }

        [Authorize(Roles = "AdminGeneral")]
        // GET: Categoria/Create
        public ActionResult Create()
        {
            return View();
        }
        [Authorize(Roles = "AdminGeneral")]
        //POST: Categoria/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id, nombre, descripcion")]Categoria categoria)
        {
            if(!ModelState.IsValid) 
                return View();
            
            db.Categorias.Add(categoria);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [Authorize(Roles = "AdminGeneral")]
        //GET: Categoria/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null) 
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
      
            Categoria categoria = db.Categorias.Find(id);

            if (categoria == null) 
                return HttpNotFound();
            
            return View(categoria);
        }
        [Authorize(Roles = "AdminGeneral")]
        //POST: Categoria/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id, nombre, descripcion")] Categoria categoria)
        {
            if(!ModelState.IsValid)
                return View();
            
            var cat = db.Categorias.Find(categoria.id);
            cat.nombre = categoria.nombre;
            cat.descripcion = categoria.descripcion;
            db.SaveChanges();
            return RedirectToAction("Index");            
        }
    }
}