using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SIGEVALP.Models;
using System.Data.Entity;
using Rotativa;
using System.Net;

namespace SIGEVALP.Controllers
{
    public class ProductoxAlmacenController : Controller
    {
        private ApplicationDbContext db;

        public ProductoxAlmacenController()
        {
            db = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
        }

        // GET: ProductoxAlmacen
        public ActionResult Index(string codigo, string nombre, string check)
        {
            var result = db.ProductosxAlmacen.Include(p => p.Producto.Categoria);
            //validar simbolos y caracteres no permitidos
            //resultados no encontrados
            if (String.IsNullOrWhiteSpace(nombre) && String.IsNullOrWhiteSpace(codigo))
                return View(check, result);

            else if (codigo.Length > 0)
                return View(check, result.Where(p => p.Producto.codigo == codigo));

            else if (nombre.Length > 0)
                return View(check, result.Where(p => p.Producto.nombre.Contains(nombre)));

            return View(check, result);
        }


        // GET: ProductoxAlmacen/Edit/5
        [AuthorizeRoles(Rol.JefeAlmacen, Rol.Almacenero)]
        public ActionResult Edit(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var producto = db.ProductosxAlmacen.Find(id);

            if (producto == null)
                return HttpNotFound();

            producto.Producto = db.Productos.Include(p => p.Categoria).First(p => p.id == producto.idProducto);
            return View(producto);
        }                
        // POST: ProductoxAlmacen/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AuthorizeRoles(Rol.JefeAlmacen, Rol.Almacenero)]
        public ActionResult Edit([Bind(Include = "id,stock_min,stock_max")] ProductoxAlmacen producto)
        {
            if (!ModelState.IsValid)
            {
                producto.Producto = db.Productos.Include(p => p.Categoria).First(p => p.id == producto.id);
                return View(producto);
            }
            
            var prod = db.ProductosxAlmacen.Find(producto.id);
            prod.stock_min = producto.stock_min;
            prod.stock_max = producto.stock_max;
            db.SaveChanges();            
            return RedirectToAction("Index");
        }

        public ActionResult Print(string codigo, string nombre, string check)
        {
            return new UrlAsPdf("/ProductoxAlmacen/Index?codigo=" + codigo + "&nombre=" + nombre + "&check=" + check) { FileName = "Reporte_Stock.pdf" };
        }
    }
}