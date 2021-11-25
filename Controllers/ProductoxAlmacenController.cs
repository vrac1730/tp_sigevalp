using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SIGEVALP.Models;
using System.Data.Entity;
using Rotativa;

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
            //mostrar otra vista para resultados no encontrados?
            if (String.IsNullOrWhiteSpace(nombre) && String.IsNullOrWhiteSpace(codigo))
                return View(check, result);

            else if (codigo.Length > 0)
                return View(check, result.Where(p => p.Producto.codigo == codigo));

            else if (nombre.Length > 0)
                return View(check, result.Where(p => p.Producto.nombre.Contains(nombre)));

            return View(check, result);
        }      

        public ActionResult Print(string codigo, string nombre, string check)
        {
            return new UrlAsPdf("/ProductoxAlmacen/Index?codigo=" + codigo + "&nombre=" + nombre + "&check=" + check) { FileName = "Reporte_Stock.pdf" };
        }
    }
}