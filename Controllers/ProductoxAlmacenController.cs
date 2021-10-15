using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SIGEVALP.Models;
using System.Data.Entity;

namespace SIGEVALP.Controllers
{
    public class ProductoxAlmacenController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ProductoxAlmacen
        public ActionResult Index(string cadena, string cod)
        {
            var result = db.ProductosxAlmacen.Include(p => p.Producto.Categoria);
            //validar simbolos y caracteres no permitidos
            //mostrar otra vista para resultados no encontrados?
            if (String.IsNullOrWhiteSpace(cadena) && String.IsNullOrWhiteSpace(cod))
            {
                return View(result.ToList());
            }

            else if (cod.Length > 0)
            {
                var r1 = result.Where(p => p.Producto.codigo == cod).ToList();
                return View(r1);
            }

            else if (cadena.Length > 0)
            {
                var r2 = result.Where(p => p.Producto.nombre.Contains(cadena)).ToList();
                return View(r2);
            }

            return View(result.ToList());
        }
    }
}