using System;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;


namespace SIGEVALP.Models
{
    // Para agregar datos de perfil del usuario, agregue más propiedades a su clase ApplicationUser. Visite https://go.microsoft.com/fwlink/?LinkID=317594 para obtener más información.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Tenga en cuenta que el valor de authenticationType debe coincidir con el definido en CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Agregar aquí notificaciones personalizadas de usuario
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<DetalleCompra> DetallesCompras { get; set; }
        public DbSet<OrdenCompra> OrdenesCompras { get; set; }
        public DbSet<Solicitud> Solicitudes { get; set; }
        public DbSet<DetalleSolicitud> DetallesSolicitudes { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<DetalleCotizacion> DetallesCotizaciones { get; set; }
        public DbSet<Cotizacion> Cotizaciones { get; set; }
        public DbSet<Local> Locales { get; set; }
        public DbSet<Proveedor> Proveedores { get; set; }
        public DbSet<Estado> Estados { get; set; }
        public DbSet<Alerta> Alertas { get; set; }
        public DbSet<Almacen> Almacenes { get; set; }
        public DbSet<ProductoxAlmacen> ProductosxAlmacen { get; set; }
        public DbSet<Persona> Personas { get; set; }
        public DbSet<HistorialMovimiento> HistorialMovimientos { get; set; }
        public ApplicationDbContext() : base("DefaultConnection", throwIfV1Schema: false)
        {
        }        
        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DetalleCotizacion>().HasKey(x => new { x.idProducto, x.idProveedor });
            base.OnModelCreating(modelBuilder);
        }
        public override int SaveChanges()
        {
            try
            {
                return base.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {                
                var sb = new StringBuilder();

                foreach (var item in e.EntityValidationErrors)
                {
                    sb.AppendFormat("Entity of type {0} in state {1} has validation errors:", item.Entry.Entity.GetType().Name, item.Entry.State);
                    foreach (var error in item.ValidationErrors)
                    {
                        sb.AppendFormat(" {0} : {1}", error.PropertyName, error.ErrorMessage);
                        sb.AppendLine();
                    }
                }
                throw new DbEntityValidationException("Entity Validation Failed:\n" + sb.ToString(), e);
            }
        }
        
    }
}