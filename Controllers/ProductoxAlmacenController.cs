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
                return View(result);

            else if (cod.Length > 0)
                return View(result.Where(p => p.Producto.codigo == cod));   
            
            else if (cad.Length > 0)            
                return View(result.Where(p => p.Producto.nombre.Contains(cad)));            

            return View(result);
        }      

        public ActionResult Report(string codigo, string cadena)
        {
            var result = db.ProductosxAlmacen.Include(p => p.Producto.Categoria);

            if (String.IsNullOrWhiteSpace(cadena) && String.IsNullOrWhiteSpace(codigo))            
                return View(result);
            
            else if (cadena.Length > 0)                            
                return View(result.Where(p => p.Producto.nombre.Contains(cadena)));
            
            else if (codigo.Length > 0)            
                return View(result.Where(p => p.Producto.codigo == codigo));            

            return View(result);
        }

        public ActionResult Print()
        {
            return new ActionAsPdf("Report") { FileName = "Reporte_Stock.pdf" };
        }
    }
}