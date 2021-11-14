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
    public class ProveedorController : Controller
    {
        private ApplicationDbContext db;

        public ProveedorController()
        {
            db = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {        
            db.Dispose();         
        }

        // GET: Proveedors
        public ActionResult Index()
        {
            return View(db.Proveedores.ToList());
        }

        // GET: Proveedors/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            
            Proveedor proveedor = db.Proveedores.Find(id);
            
            if (proveedor == null)
                return HttpNotFound();
            
            return View(proveedor);
        }

        // GET: Proveedors/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Proveedors/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,nombre,direccion,correo,telefono,ruc,razon_social")] Proveedor proveedor)
        {
            if (!ModelState.IsValid)
                return View();

            db.Proveedores.Add(proveedor);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: Proveedors/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)            
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            
            Proveedor proveedor = db.Proveedores.Find(id);
            if (proveedor == null)
                return HttpNotFound();
            
            return View(proveedor);
        }

        // POST: Proveedors/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,nombre,direccion,correo,telefono,ruc,razon_social")] Proveedor proveedor)
        {
            if (!ModelState.IsValid)
                return View(proveedor);

            var prov = db.Proveedores.Find(proveedor.id);
            prov.nombre = proveedor.nombre;
            prov.direccion = proveedor.direccion;
            prov.correo = proveedor.correo;
            prov.telefono = proveedor.telefono;
            prov.ruc = proveedor.ruc;
            prov.razon_social = proveedor.razon_social;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
