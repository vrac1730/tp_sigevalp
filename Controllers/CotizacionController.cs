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
        public ActionResult Create()
        {
            ViewBag.idProducto = new SelectList(db.Productos, "codigo", "nombre");
            ViewBag.idProveedor = new SelectList(db.Proveedores, "id", "nombre");
            ViewBag.idUsuario = new SelectList(db.Usuarios, "id", "username");
            return View();
        }

        // POST: Cotizacion/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,parcial,descuento,neto,iva,total,idUsuario,idProveedor,DetalleCotizacion")] Cotizacion cotizacion)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.idProducto = new SelectList(db.Productos, "codigo", "nombre");
                ViewBag.idProveedor = new SelectList(db.Proveedores, "id", "nombre");
                ViewBag.idUsuario = new SelectList(db.Usuarios, "id", "username");
                return View();                
            }
            //cotizacion.estado = "Pendiente";
            //cotizacion.fecha = DateTime.Now;
            //generar codigo
            db.Cotizaciones.Add(cotizacion);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: Cotizacion/Edit/5
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
        public ActionResult DeleteConfirmed(int id)
        {
            Cotizacion cotizacion = db.Cotizaciones.Find(id);
            db.Cotizaciones.Remove(cotizacion);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
