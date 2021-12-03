using SIGEVALP.Models;
using SIGEVALP.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.Net;

namespace SIGEVALP.Controllers
{
    public class HistorialMovimientoController : Controller
    {
        private ApplicationDbContext db;

        public HistorialMovimientoController()
        {
            db = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
        }

        // GET: HistorialMovimiento/
        public ActionResult Index(string codigo, string nombre)
        {
            var detalles = new HistorialMovimientoViewModel();
            var dcompra = db.DetallesCompras.Include(d => d.OrdenCompra.Proveedor).Include(d => d.Producto.Categoria).Where(d => d.cantidadRecibida != 0);
            var dsolicitud = db.DetallesSolicitudes.Include(d => d.Solicitud.Usuario.Local).Include(d => d.Producto.Categoria).Where(d => d.cantEntregada != 0);

            if (String.IsNullOrWhiteSpace(nombre) && String.IsNullOrWhiteSpace(codigo))
            {
                detalles.detalleCompra = dcompra.ToList();
                detalles.detalleSolicitud = dsolicitud.ToList();
                return View(detalles);
            }
            else if (codigo.Length > 0)
            {
                detalles.detalleCompra = dcompra.Where(p => p.Producto.codigo == codigo).ToList();
                detalles.detalleSolicitud = dsolicitud.Where(p => p.Producto.codigo == codigo).ToList();
                return View(detalles);
            }
            else if (nombre.Length > 0)
            {
                detalles.detalleCompra = dcompra.Where(p => p.Producto.nombre.StartsWith(nombre)).ToList();
                detalles.detalleSolicitud = dsolicitud.Where(p => p.Producto.nombre.StartsWith(nombre)).ToList();
                return View(detalles);
            }
            return View(detalles);
        }

        public ActionResult Details(int? id, string tipo)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            if (tipo == "Ingreso")
            {
                var dCompra = db.DetallesCompras.Include(d => d.OrdenCompra.Proveedor).Include(d => d.Producto.Categoria).Where(d => d.id == id);

                if (dCompra == null)
                    return HttpNotFound();

                var detalle1 = new HistorialMovimientoViewModel { detalleCompra = dCompra.ToList() };
                return View(detalle1);
            }
            else
            {
                var dSolicitud = db.DetallesSolicitudes.Include(d => d.Solicitud.Usuario.Local).Include(d=>d.Solicitud.Usuario.Persona).Include(d => d.Producto.Categoria).Where(d => d.id == id);

                if (dSolicitud == null)
                    return HttpNotFound();

                var detalles = new HistorialMovimientoViewModel { detalleSolicitud = dSolicitud.ToList() };
                return View(detalles);
            }
        }
    }
}