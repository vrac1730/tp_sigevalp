using SIGEVALP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Entity;
using System.Web.Mvc;
using System.Net;

namespace SIGEVALP.Controllers
{
    public class SolicitudController : Controller
    {
        private ApplicationDbContext db;

        public SolicitudController()
        {
            db = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
        }

        // GET: Solicitud
        public ActionResult Index(string cod)
        {   //busqueda por rango de fechas, estado          
            var result = db.Solicitudes.Include(p => p.Usuario.Persona).Include(p => p.Usuario.Local);

            if (String.IsNullOrWhiteSpace(cod))
                return View(result);

            else if (cod.Length > 0)
                return View(result.Where(p => p.codigo == cod));

            return View(result);
        }

        // GET: Solicitud/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var solicitud = db.Solicitudes.Find(id);               

            if (solicitud == null)
                return HttpNotFound();
                        
            solicitud.DetalleSolicitud = db.DetallesSolicitudes.Include(d => d.Producto.Alerta).Where(d => d.idSolicitud == id).ToList();
            solicitud.Usuario = db.Usuarios.Include(u => u.Local).Include(u => u.Persona).Single(u => u.id == solicitud.idUsuario);
            return View(solicitud);
        }

        // GET: Solicitud/Create
        public ActionResult Create()
        {
            ViewBag.Usuarios = db.Usuarios.Include(u => u.Persona);
            ViewBag.Productos = db.Productos.Include(p => p.Alerta);
            //db.Productos.Where(p => p.cantidad <= p.stock_min & (p.idAlerta == 4 || p.idAlerta == 8));
            ViewData["ProductosA"] = db.ProductosxAlmacen.Include(p => p.Producto.Alerta).Where(p => p.cantidad <= p.stock_min & (p.Producto.idAlerta == 4));
            return View();
        }

        // POST: Solicitud/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,fecha,codigo,estado,idUsuario,DetalleSolicitud")] Solicitud solicitud)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Productos = db.Productos.Include(p => p.Alerta);
                //var pro = db.Productos.Where(p => p.cantidad <= p.stock_min & p.idAlerta == 4);   
                ViewData["ProductosA"] = db.ProductosxAlmacen.Include(d => d.Producto.Alerta).Where(p => p.cantidad <= p.stock_min & p.Producto.idAlerta == 4);
                ViewBag.Usuarios = db.Usuarios.Include(u => u.Persona);
                return View();
            }            

            solicitud.fecha = DateTime.Now;
            solicitud.estado = "Pendiente";
            var os = db.Solicitudes.ToList().Last();
            int id = os.id + 1;
            solicitud.codigo = "000" + id;
            db.Solicitudes.Add(solicitud);
            db.SaveChanges();

            foreach (var item in solicitud.DetalleSolicitud)
            {
                var prod = db.Productos.Find(item.idProducto);
                prod.idAlerta = 5;
            }
            db.SaveChanges();
            return RedirectToAction("Index");            
        }
       
        // GET: Solicitud/Edit/5
        public ActionResult EditDetail(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            DetalleSolicitud detalleSolicitud = db.DetallesSolicitudes.Find(id);

            if (detalleSolicitud == null)
                return HttpNotFound();
            
            detalleSolicitud.Producto = db.Productos.Include(p => p.Alerta).First(p => p.id == detalleSolicitud.idProducto);
            return View(detalleSolicitud);
        }

        // POST: Solicitud/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditDetail([Bind(Include = "id,cantEntregada,idProducto")] DetalleSolicitud detalleSolicitud)
        {
            if (!ModelState.IsValid) 
            {
                detalleSolicitud.Producto = db.Productos.Include(p => p.Alerta).First(p => p.id == detalleSolicitud.idProducto);
                return View(detalleSolicitud);
            }

            var detalle = db.DetallesSolicitudes.Include(d => d.Producto).First(d => d.id == detalleSolicitud.id);
            var alm = db.ProductosxAlmacen.FirstOrDefault(a => a.idProducto == detalleSolicitud.idProducto);

            detalle.Producto.idAlerta = 6;
            detalle.cantEntregada = detalleSolicitud.cantEntregada;
            alm.cantidad -= (detalleSolicitud.cantEntregada - detalle.cantEntregada);
            detalle.fecha = DateTime.Now;
            //validar existencias en almacen
            //evaluar cambio alerta de prodxalmacen

            db.SaveChanges();
            return RedirectToAction("Details", new { id = detalle.idSolicitud });
        }        
    }
}