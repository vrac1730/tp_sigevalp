using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SIGEVALP.Models;

namespace SIGEVALP.Controllers
{
    public class CategoriaController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Categoria
        public ActionResult Index()
        {
            var categoriaInDb = db.Categorias.ToList();
            return View(categoriaInDb);
        }

        // GET: Categoria/Create
        public ActionResult Create()
        {
            return View();
        }

        //POST: Categoria/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id, nombre, descripcion")]Categoria categoria)
        {
            if(ModelState.IsValid)
            {
                db.Categorias.Add(categoria);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(categoria);
        }

        //GET: Categoria/Edit/5
        public ActionResult Edit(int? id)
        {
            if(id==null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            Categoria categoria = db.Categorias.Find(id);
            if(categoria==null)
            {
                return HttpNotFound();
            }
            return View(categoria);
        }

        //POST: Categoria/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id, nombre, descripcion")] Categoria categoria)
        {
            if(ModelState.IsValid)
            {
                db.Entry(categoria).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(categoria);
        }
    }
}