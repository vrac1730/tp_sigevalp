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
    public class CotizacionController : Controller
    {
        private ApplicationDbContext db;

        public CotizacionController()
        {
            db = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
        }

        // GET: Cotizacion
        public ActionResult Index()
        {
            return View(db.Cotizaciones.Include(c => c.Proveedor).Include(c => c.Usuario));
        }

        // GET: Cotizacion/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            
            Cotizacion cotizacion = db.Cotizaciones.Find(id);

            if (cotizacion == null) return HttpNotFound();

            cotizacion.Usuario = db.Usuarios.Find(cotizacion.idUsuario);
            cotizacion.Proveedor = db.Proveedores.Find(cotizacion.idProveedor);
            cotizacion.DetalleCotizacion = db.DetallesCotizaciones.Include(d => d.Producto).Where(d => d.idCotizacion == cotizacion.id).ToList();
            return View(cotizacion);
        }

        // GET: Cotizacion/Create
        [Authorize(Roles = Rol.JefeAlmacen)]
        public ActionResult Create()
        {
            ViewBag.Productos = db.Productos;
            ViewBag.Proveedores = db.Proveedores;
            ViewBag.Usuarios = db.Usuarios.Include(u => u.Persona);
            return View();
        }
        // POST: Cotizacion/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = Rol.JefeAlmacen)]
        public ActionResult Create([Bind(Exclude = "Usuario,Proveedor")] Cotizacion cotizacion)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Productos = db.Productos;
                ViewBag.Proveedores = db.Proveedores;
                ViewBag.Usuarios = db.Usuarios.Include(u => u.Persona);
                return View();                
            }
            cotizacion.estado = "Pendiente";
            cotizacion.fecha = DateTime.Now;
            var co = db.Cotizaciones.ToList().Last();
            int id = co.id + 1;
            cotizacion.codigo = "000" + id;
            foreach (var item in cotizacion.DetalleCotizacion)
            { 
                item.idProveedor = cotizacion.idProveedor; 
            }
            db.Cotizaciones.Add(cotizacion);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: Cotizacion/Edit/5
        [Authorize(Roles = Rol.JefeAlmacen)]
        public ActionResult Edit(int? id)
        {
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);            

            Cotizacion cotizacion = db.Cotizaciones.Find(id);

            if (cotizacion == null) return HttpNotFound();

            ViewBag.idProveedor = new SelectList(db.Proveedores, "id", "nombre", cotizacion.idProveedor);
            ViewBag.idUsuario = new SelectList(db.Usuarios, "id", "username", cotizacion.idUsuario);
            ViewBag.idProducto = new SelectList(db.Productos, "id", "nombre");

            cotizacion.Usuario = db.Usuarios.Find(cotizacion.idUsuario);
            cotizacion.Proveedor = db.Proveedores.Find(cotizacion.idProveedor);
            cotizacion.DetalleCotizacion = db.DetallesCotizaciones.Include(d => d.Producto).Where(d => d.idCotizacion == cotizacion.id).ToList();                        
            return View(cotizacion);
        }
        // POST: Cotizacion/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = Rol.JefeAlmacen)]
        public ActionResult Edit([Bind(Include = "id,codigo,estado,iva,total,idUsuario,idProveedor,fecha")] Cotizacion cotizacion)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.idProveedor = new SelectList(db.Proveedores, "id", "nombre", cotizacion.idProveedor);
                ViewBag.idUsuario = new SelectList(db.Usuarios, "id", "username", cotizacion.idUsuario);
                return View();                
            }
            db.Entry(cotizacion).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        
        // GET: Cotizacion/Delete/5
        [Authorize(Roles = Rol.JefeAlmacen)]
        public ActionResult Delete(int? id)
        {
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            Cotizacion cotizacion = db.Cotizaciones.Find(id);

            if (cotizacion == null) return HttpNotFound();

            cotizacion.Usuario = db.Usuarios.Find(cotizacion.idUsuario);
            cotizacion.Proveedor = db.Proveedores.Find(cotizacion.idProveedor);
            cotizacion.DetalleCotizacion = db.DetallesCotizaciones.Include(d => d.Producto).Where(d => d.idCotizacion == cotizacion.id).ToList();            
            return View(cotizacion);
        }
        // POST: Cotizacion/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = Rol.JefeAlmacen)]
        public ActionResult DeleteConfirmed(int id)
        {
            Cotizacion cotizacion = db.Cotizaciones.Find(id);
            db.Cotizaciones.Remove(cotizacion);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
