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
            {
                return View(result);
            }

            else if (cod.Length > 0)
            {
                return View(result.Where(p => p.codigo == cod));
            }

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
                        
            var detalles = db.DetallesSolicitudes.Include(d => d.Producto.Alerta).Where(d => d.idSolicitud == id).ToList();
            var usuario = db.Usuarios.Include(u => u.Local).Include(u => u.Persona).Single(u => u.id == solicitud.idUsuario);
            solicitud.DetalleSolicitud = detalles;
            solicitud.Usuario = usuario;

            return View(solicitud);
        }

        // GET: Solicitud/Create
        public ActionResult Create()
        {            
            ViewBag.idUsuario = new SelectList(db.Usuarios, "id", "username");            
     
            var prod = db.ProductosxAlmacen.Include(p => p.Producto).Where(p => p.cantidad <= p.stock_min & (p.Producto.idAlerta == 4));
                // db.Productos.Where(p => p.cantidad <= p.stock_min & (p.idAlerta == 4 || p.idAlerta == 8));

            ViewData["idProducto"] = new SelectList(prod, "id", "Producto.nombre");

            List<ProductoxAlmacen> productoxAlmacens = prod.Include(d => d.Alerta).ToList();
            //List<Producto> productos = prod.Include(d => d.Alerta).ToList();
            ViewData["Productos"] = productoxAlmacens;

            return View();
        }

        // POST: Solicitud/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,fecha,codigo,estado,idUsuario,DetalleSolicitud")] Solicitud solicitud)
        {

            if (ModelState.IsValid)
            {/*
                if (ordenSalida.DetalleSalida == null)
                {
                    ViewData["idProducto"] = new SelectList(pro, "id", "nombre");
                    ViewData["Productos"] = productos;
                    ViewBag.idUsuario = new SelectList(db.Usuarios, "id", "username", ordenSalida.idUsuario);
                    return View();
                }*/
                solicitud.fecha = DateTime.Now;
                solicitud.estado = "Pendiente";
                var os = db.Solicitudes.OrderByDescending(o => o.id).FirstOrDefault(o => o.estado == "Pendiente");
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
            var pro = db.ProductosxAlmacen.Where(p => p.cantidad <= p.stock_min & p.Producto.idAlerta == 4);
            //var pro = db.Productos.Where(p => p.cantidad <= p.stock_min & p.idAlerta == 4);
            List<ProductoxAlmacen> productos = pro.Include(d => d.Producto.Alerta).ToList();
            //List<Producto> productos = pro.Include(d => d.Alerta).ToList();
            ViewData["idProducto"] = new SelectList(pro, "id", "Producto.nombre");
            ViewData["Productos"] = productos;
            ViewBag.idUsuario = new SelectList(db.Usuarios, "id", "username", solicitud.idUsuario);

            return View();
        }

        //registrar nota salida////
       
        // GET: Solicitud/Edit/5
        public ActionResult EditDetail(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            DetalleSolicitud detalleSolicitud = db.DetallesSolicitudes.Find(id);

            if (detalleSolicitud == null)
                return HttpNotFound();

            var prod = db.Productos.Include(p => p.Alerta).FirstOrDefault(p => p.id == detalleSolicitud.idProducto);
            detalleSolicitud.Producto = prod;
            //var alm = db.ProductosxAlmacen.FirstOrDefault(a => a.Producto.id == detalleSalida.idProducto);

            return View(detalleSolicitud);
        }

        // POST: Solicitud/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditDetail([Bind(Include = "id,cantEntregada,idProducto")] DetalleSolicitud detalleSolicitud)
        {
            if (ModelState.IsValid)
            {
                var prod = db.Productos.Find(detalleSolicitud.idProducto);
                var detalle = db.DetallesSolicitudes.Find(detalleSolicitud.id);
                var alm = db.ProductosxAlmacen.FirstOrDefault(a => a.idProducto == detalleSolicitud.idProducto);

                prod.idAlerta = 6;

                //prod.cantidad += (detalleSolicitud.cantEntregada - detalle.cantEntregada);

                alm.cantidad -= (detalleSolicitud.cantEntregada - detalle.cantEntregada);
                detalle.cantEntregada = detalleSolicitud.cantEntregada;
                //validar existencias en almacen
                //cambiar alerta de prodxalmacen
                db.SaveChanges();
                return RedirectToAction("Details", new { id = detalle.idSolicitud });
            }
            return View(detalleSolicitud);
        }        
    }
}