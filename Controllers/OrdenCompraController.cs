using SIGEVALP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.Entity;
using System.Net;

namespace SIGEVALP.Controllers
{
    public class OrdenCompraController : Controller
    {
        private ApplicationDbContext db;

        public OrdenCompraController()
        {
            db = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
        }

        // GET: OrdenCompra
        public ActionResult Index()
        {
            return View(db.OrdenesCompras.Include(o => o.Proveedor).Include(o => o.Usuario.Local).Include(o => o.Usuario.Persona));
        }

        // GET: OrdenCompra/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            OrdenCompra ordenCompra = db.OrdenesCompras.Find(id);

            if (ordenCompra == null)
                return HttpNotFound();
                        
            ordenCompra.Proveedor = db.Proveedores.Find(ordenCompra.idProveedor);
            ordenCompra.Usuario = db.Usuarios.Include(u => u.Local).Include(u => u.Persona).First(u => u.id == ordenCompra.idUsuario);

            var detalleCompra = db.DetallesCompras.Include(d => d.Producto.Alerta).Where(d => d.idOrdenCompra == id).ToArray();
            for (int i = 0; i < detalleCompra.Length; i++)
            {
                var prod = detalleCompra[i].idProducto;
                var detalle = db.DetallesCotizaciones.Where(dc => dc.idProducto == prod && dc.idProveedor == ordenCompra.idProveedor && dc.Cotizacion.estado=="Aprobado").ToArray();
                detalleCompra[i].Producto.DetalleCotizacion = detalle.ToList();
                detalleCompra[i].total = detalleCompra[i].cantidad * detalle[0].costo;
            }
            ordenCompra.DetalleCompras = detalleCompra.ToList();
            ordenCompra.montoTotal = detalleCompra.Sum(m => m.total); 

            return View(ordenCompra);
        }
        [Authorize(Roles = "JefeAlmacen")]
        // GET: OrdenCompra/Create        
        public ActionResult Create(int? id)//idproveedor
        {
            if (id == null)
            {
                ViewBag.Proveedores = db.Proveedores;
                return View();
            }

            var proveedor = db.Proveedores.Find(id);

            if (proveedor == null)
                return HttpNotFound();

            //Traer producto aprobados de cotizacion cuyo stock min y max sea diferente de 0
            ViewBag.Productos = db.DetallesCotizaciones.Include(o => o.Producto).Where(o => o.idProveedor == id & o.Cotizacion.estado == "Aprobado");
            ViewBag.Usuarios = db.Usuarios.Include(u => u.Persona);
            ViewData["ProductosSol"] = db.ProductosxAlmacen.Include(p => p.Producto.Alerta).Where(p => p.cantidad <= p.stock_min & (p.Producto.idAlerta == 5));
            return View(); 
        }
        [Authorize(Roles = "JefeAlmacen")]
        // POST: OrdenCompra/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(int? id, [Bind(Include = "id,codigo,fechaOrden,fechaPago,montoTotal,idUsuario,idProveedor,DetalleCompras")] OrdenCompra ordenCompra)
        {
            if (ordenCompra.idProveedor != 0)
            {
                if (Url.RequestContext.RouteData.Values.ContainsKey("id") == true)
                {
                    if (!ModelState.IsValid)
                    {
                        ViewBag.Productos = db.DetallesCotizaciones.Include(o => o.Producto).Where(o => o.idProveedor == id & o.Cotizacion.estado == "Aprobado");
                        ViewBag.Usuarios = db.Usuarios.Include(u => u.Persona);
                        ViewData["ProductosSol"] = db.ProductosxAlmacen.Include(p => p.Producto.Alerta).Where(p => p.cantidad <= p.stock_min & (p.Producto.idAlerta == 5));
                        return View();
                    }                   

                    ordenCompra.fechaOrden = DateTime.Now;
                    ordenCompra.estado = "Pendiente";
                    //ordenCompra.montoTotal = 0;
                    var os = db.OrdenesCompras.ToList().Last();
                    int idOrden = os.id + 1;
                    ordenCompra.codigo = "000" + idOrden;
                    db.OrdenesCompras.Add(ordenCompra);
                    db.SaveChanges();

                    foreach (var item in ordenCompra.DetalleCompras)
                    {
                        var prod = db.Productos.Find(item.idProducto);
                        prod.idAlerta = 7;
                    }
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return RedirectToAction("Create", new { id = ordenCompra.idProveedor });
            }
            ViewBag.Proveedores = db.Proveedores;
            return View();
        }
        [Authorize(Roles = "JefeAlmacen")]
        // GET: OrdenCompra/Edit/5
        public ActionResult EditDetail(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            DetalleCompra detalleCompra = db.DetallesCompras.Find(id);

            if (detalleCompra == null)
                return HttpNotFound();
            
            detalleCompra.Producto = db.Productos.Include(p => p.Alerta).First(p => p.id == detalleCompra.idProducto);
            return View(detalleCompra);
        }
        [Authorize(Roles = "JefeAlmacen")]
        // POST: OrdenSalida/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditDetail([Bind(Include = "id,cantidadRecibida,idProducto")] DetalleCompra detalleCompra)
        {
            if (!ModelState.IsValid) 
            {
                detalleCompra.Producto = db.Productos.Include(p => p.Alerta).First(p => p.id == detalleCompra.idProducto);
                return View(detalleCompra);
            }
            
            var detalle = db.DetallesCompras.Include(d => d.Producto).First(d => d.id == detalleCompra.id);
            var alm = db.ProductosxAlmacen.FirstOrDefault(a => a.idProducto == detalleCompra.idProducto);

            detalle.Producto.idAlerta = 8;
            alm.cantidad += (detalleCompra.cantidadRecibida - detalle.cantidadRecibida);
            detalle.cantidadRecibida = detalleCompra.cantidadRecibida;
            detalle.fecha = DateTime.Now;
            //validar existencias en almacen
            //evaluar cambio alerta de prodxalmacen

            db.SaveChanges();
            return RedirectToAction("Details", new { id = detalle.idOrdenCompra });
        }
    }
}