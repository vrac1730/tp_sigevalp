using SIGEVALP.Models;
using SIGEVALP.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace SIGEVALP.Controllers
{
    public class HistorialMovimientoController : Controller
    {
        private ApplicationDbContext db;

        public HistorialMovimientoController()
        {
            db = new ApplicationDbContext();
        }

        // GET: HistorialMovimiento/
        public ActionResult Index()
        {
            var detalles = new HistorialMovimientoViewModel
            {
                detalleCompra = db.DetallesCompras.Include(d => d.Producto).Where(d => d.cantidadRecibida != 0).ToList(),
                detalleSolicitud = db.DetallesSolicitudes.Include(d => d.Producto).Where(d => d.cantEntregada != 0).ToList()
            };
            return View(detalles);
        }
    }
}