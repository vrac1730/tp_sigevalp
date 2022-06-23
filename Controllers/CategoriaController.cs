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

        // GET: Categoria/Create
        [AuthorizeRoles(Rol.AdminGeneral, Rol.AdminWeb)]
        public ActionResult Create()
        {
            return View();
        }
        //POST: Categoria/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AuthorizeRoles(Rol.AdminGeneral, Rol.AdminWeb)]
        public ActionResult Create([Bind(Include = "id, nombre, descripcion")]Categoria categoria)
        {
            if(!ModelState.IsValid) 
                return View();
            
            db.Categorias.Add(categoria);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        
        //GET: Categoria/Edit/5
        [AuthorizeRoles(Rol.AdminGeneral, Rol.AdminWeb)]
        public ActionResult Edit(int? id)
        {
            if (id == null) 
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
      
            Categoria categoria = db.Categorias.Find(id);

            if (categoria == null) 
                return HttpNotFound();
            
            return View(categoria);
        }
        //POST: Categoria/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AuthorizeRoles(Rol.AdminGeneral, Rol.AdminWeb)]
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