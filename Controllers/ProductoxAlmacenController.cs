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
        public ActionResult Index(string cad, string cod)
        {
            var result = db.ProductosxAlmacen.Include(p => p.Producto.Categoria);
            //validar simbolos y caracteres no permitidos
            //mostrar otra vista para resultados no encontrados?
            if (String.IsNullOrWhiteSpace(cad) && String.IsNullOrWhiteSpace(cod))
            {
                return View(result.ToList());
            }

            else if (cod.Length > 0)
            {
                var r1 = result.Where(p => p.Producto.codigo == cod).ToList();
                return View(r1);
            }

            else if (cad.Length > 0)
            {
                var r2 = result.Where(p => p.Producto.nombre.Contains(cad)).ToList();
                return View(r2);
            }

            return View(result.ToList());
        }      

        public ActionResult Report(string codigo, string cadena)
        {
            var result = db.ProductosxAlmacen.Include(p => p.Producto.Categoria);

            if (String.IsNullOrWhiteSpace(cadena) && String.IsNullOrWhiteSpace(codigo))
            {
                return View(result.ToList());
            }

            if (cadena.Length > 0)
            {
                var r2 = result.Where(p => p.Producto.nombre.Contains(cadena)).ToList();
                return View(r2);
            }
            if (codigo.Length > 0)
            {
                var r1 = result.Where(p => p.Producto.codigo == codigo).ToList();
                return View(r1);
            }

            return View(result.ToList());
        }

        public ActionResult Print()
        {
            return new ActionAsPdf("Report") { FileName = "Reporte_Stock.pdf" };
        }
    }
}