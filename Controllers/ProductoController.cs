using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SIGEVALP.Models;

namespace SIGEVALP.Controllers
{
    public class ProductoController : Controller
    {
        private ApplicationDbContext db;

        public ProductoController()
        {
            db = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
        }

        // GET: Producto
        public ActionResult Index()
        {
            var productos = db.Productos.Include(p => p.Alerta).Include(p => p.Categoria);
            return View(productos.ToList());
        }

        // GET: Producto/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var producto = db.Productos.Find(id);
            if (producto == null)
            {
                return HttpNotFound();
            }            
            producto.Categoria = db.Categorias.Find(producto.id);
            return View(producto);
        }

        // GET: Producto/Create
        public ActionResult Create()
        {
            ViewBag.idCategoria = new SelectList(db.Categorias, "id", "nombre");
            return View();
        }

        // POST: Producto/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,codigo,nombre,descripcion,marca,idCategoria")] Producto producto)
        {
            if (ModelState.IsValid)
            {
                var cat = db.Categorias.Find(producto.idCategoria);
                var codcat = cat.nombre.Substring(0, 2).ToUpper();
                var codmarca= producto.marca.Substring(0, 2).ToUpper();
                var prod = db.Productos.ToList().Last();
                int n = prod.id + 1;

                producto.codigo = codcat + codmarca + n;
                db.Productos.Add(producto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            
            ViewBag.idCategoria = new SelectList(db.Categorias, "id", "nombre", producto.idCategoria);
            return View(producto);
        }

        // GET: Producto/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Producto producto = db.Productos.Find(id);
            if (producto == null)
            {
                return HttpNotFound();
            }           
            ViewBag.idCategoria = new SelectList(db.Categorias, "id", "nombre", producto.idCategoria);
            return View(producto);
        }

        // POST: Producto/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,codigo,nombre,descripcion,marca,idCategoria")] Producto producto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(producto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }           
            ViewBag.idCategoria = new SelectList(db.Categorias, "id", "nombre", producto.idCategoria);
            return View(producto);
        } 
    }
}
