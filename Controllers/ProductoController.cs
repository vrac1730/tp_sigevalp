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
            return View(db.Productos.Include(p => p.Categoria));
        }

        // GET: Producto/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)            
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var producto = db.Productos.Include(p => p.Categoria).FirstOrDefault(p => p.id == id);

            if (producto == null)            
                return HttpNotFound();

            return View(producto);
        }
        [Authorize(Roles = "AdminWeb")]
        // GET: Producto/Create
        public ActionResult Create()
        {
            ViewBag.Categorias = db.Categorias;
            return View();
        }
        [Authorize(Roles = "AdminWeb")]
        // POST: Producto/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,codigo,nombre,descripcion,marca,idCategoria")] Producto producto)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Categorias = db.Categorias;
                return View();
            }          
            
            var cat = db.Categorias.Find(producto.idCategoria);
            var codcat = cat.nombre.Substring(0, 2).ToUpper();
            var codmarca = producto.marca.Substring(0, 2).ToUpper();
            var prod = db.Productos.ToList().Last();
            int n = prod.id + 1;
            producto.codigo = codcat + codmarca + n;
            db.Productos.Add(producto);

            ProductoxAlmacen pro = new ProductoxAlmacen {
                idProducto = producto.id,
                idAlmacen = 1,
                idAlerta = 4 };//stock min max pp y cant=0, idEstado=null
            db.ProductosxAlmacen.Add(pro);

            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [Authorize(Roles = "AdminWeb")]
        // GET: Producto/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)            
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var producto = db.Productos.Include(p => p.Categoria).FirstOrDefault(p => p.id == id);

            if (producto == null)           
                return HttpNotFound();

            ViewBag.Categorias = db.Categorias;
            return View(producto);
        }
        [Authorize(Roles = "AdminWeb")]
        // POST: Producto/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,codigo,nombre,descripcion,marca,idCategoria")] Producto producto)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Categorias = db.Categorias;
                return View(producto);
            }

            var prod = db.Productos.Find(producto.id);
            prod.nombre = producto.nombre;
            prod.descripcion = producto.descripcion;
            prod.marca = producto.marca;
            prod.idCategoria = producto.idCategoria;
            db.SaveChanges();
            return RedirectToAction("Index");
        } 
    }
}
