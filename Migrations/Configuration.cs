namespace SIGEVALP.Migrations
{
    using SIGEVALP.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<SIGEVALP.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(SIGEVALP.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            context.Personas.AddOrUpdate(x => x.id,
           new Persona() { id = 1, dni = 12345678, nombre = "Jose", aPaterno = "Zapata", aMaterno = "Tuñoque", celular = 123456789 },
           new Persona() { id = 2, dni = 70360207, nombre = "Victor", aPaterno = "Alarcón", aMaterno = "Campos", celular = 963109798 },
           new Persona() { id = 3, dni = 12345678, nombre = "Marco", aPaterno = "Rios", aMaterno = "Arone", celular = 123456789 },
           new Persona() { id = 4, dni = 12345678, nombre = "Cristian", aPaterno = "Osorio", aMaterno = "Suárez", celular = 123456789 },
           new Persona() { id = 5, dni = 12345678, nombre = "Arnold", aPaterno = "Alegria", aMaterno = "Pacheco", celular = 123456789 }
           );

            context.Locales.AddOrUpdate(x => x.id,
            new Local() { id = 1, nombre = "Surco", direccion = "Av: los benavides 4950", telefono = 276153485, ruc = 20501234567, razon_social = "abc" },
            new Local() { id = 2, nombre = "Miraflores", direccion = "Av: los benavides 950", telefono = 276343485, ruc = 20501254567, razon_social = "def" },
            new Local() { id = 3, nombre = "Barranco", direccion = "Av: Grau 495", telefono = 275323485, ruc = 20501235567, razon_social = "ghi" }
            );

            context.Usuarios.AddOrUpdate(x => x.id,
              new Usuario() { id = 1, username = "Jose", correo = "jose@hotmail.com", contraseña = "123", idLocal = 1, idPersona = 1 },
              new Usuario() { id = 2, username = "Victor", correo = "virualca@hotmail.com", contraseña = "123", idLocal = 1, idPersona = 2 },
              new Usuario() { id = 3, username = "Marco", correo = "marco@hotmail.com", contraseña = "123", idLocal = 1, idPersona = 3 },
              new Usuario() { id = 4, username = "Cristian", correo = "cristian@hotmail.com", contraseña = "123", idLocal = 1, idPersona = 4 },
              new Usuario() { id = 5, username = "Arnold", correo = "arnold@hotmail.com", contraseña = "123", idLocal = 1, idPersona = 5 }
              );

            context.Categorias.AddOrUpdate(x => x.id,
               new Categoria() { id = 1, nombre = "Juguetes", descripcion = "Buena calidad" },
               new Categoria() { id = 2, nombre = "Utiles Escolares", descripcion = "Buena calidad" },
               new Categoria() { id = 3, nombre = "Papeles", descripcion = "Buena calidad" },
               new Categoria() { id = 4, nombre = "Manualidades", descripcion = "Buena calidad" },
               new Categoria() { id = 5, nombre = "Regalos", descripcion = "Buena calidad" }
               );

            context.Alertas.AddOrUpdate(x => x.id,
                new Alerta() { id = 1, nombre = "Bajo Stock", descripcion = "" },
                new Alerta() { id = 2, nombre = "Punto Pedido", descripcion = "" },
                new Alerta() { id = 3, nombre = "Stock Disponible", descripcion = "" },
                new Alerta() { id = 4, nombre = "Ninguna", descripcion = "" },
                new Alerta() { id = 5, nombre = "Pendiente", descripcion = "" },
                new Alerta() { id = 6, nombre = "Entregado P.", descripcion = "" },
                new Alerta() { id = 7, nombre = "En orden", descripcion = "" },
                new Alerta() { id = 8, nombre = "Recibido P.", descripcion = "" },
                new Alerta() { id = 9, nombre = "Aprobado", descripcion = "" },
                new Alerta() { id = 10, nombre = "Rechazado", descripcion = "" }
                );

            context.Solicitudes.AddOrUpdate(x => x.id,
                new Solicitud() { id = 1, codigo = "0001", fecha = new DateTime(2021, 06, 03, 12, 19, 20), estado = "Pendiente", idUsuario = 1 },
                new Solicitud() { id = 2, codigo = "0002", fecha = new DateTime(2021, 06, 03, 12, 19, 20), estado = "Pendiente", idUsuario = 2 },
                new Solicitud() { id = 3, codigo = "0003", fecha = new DateTime(2021, 06, 03, 12, 19, 20), estado = "Pendiente", idUsuario = 3 },
                new Solicitud() { id = 4, codigo = "0004", fecha = new DateTime(2021, 06, 03, 12, 19, 20), estado = "Pendiente", idUsuario = 4 },
                new Solicitud() { id = 5, codigo = "0005", fecha = new DateTime(2021, 06, 03, 12, 19, 20), estado = "Pendiente", idUsuario = 5 }
                );

            context.DetallesSolicitudes.AddOrUpdate(x => new { x.idSolicitud, x.idProducto },
                new DetalleSolicitud() { idSolicitud = 1, idProducto = 1, cantSolicitada = 100, cantEntregada = 0, observacion = "" },
                new DetalleSolicitud() { idSolicitud = 1, idProducto = 2, cantSolicitada = 10, cantEntregada = 0, observacion = "" }
                 );

            context.Productos.AddOrUpdate(x => x.id,
                new Producto() { id = 1, codigo = "111", nombre = "Cuaderno", descripcion = "Cuaderno de buena calidad", marca = "Loro", idCategoria = 1, idAlerta = 5 },
                new Producto() { id = 2, codigo = "112", nombre = "Lapiz", descripcion = "Lapiz de buena calidad", marca = "Mongol", idCategoria = 2, idAlerta = 5 },
                new Producto() { id = 3, codigo = "113", nombre = "Borrador", descripcion = "Borrador de buena calidad", marca = "Faber Castell", idCategoria = 3, idAlerta = 4 },
                new Producto() { id = 4, codigo = "114", nombre = "Carro", descripcion = "Carro de buena calidad", marca = "Lego", idCategoria = 4, idAlerta = 4 },
                new Producto() { id = 5, codigo = "115", nombre = "Hoja Bond", descripcion = "Hoja Bond de buena calidad", marca = "Atlas", idCategoria = 5, idAlerta = 7 },
                new Producto() { id = 6, codigo = "116", nombre = "Cuaderno", descripcion = "Cuaderno de buena calidad", marca = "Atlas", idCategoria = 2, idAlerta = 7 },
                new Producto() { id = 7, codigo = "117", nombre = "Lapicero", descripcion = "Lapicero de buena calidad", marca = "Pilot", idCategoria = 2, idAlerta = 4 },
                new Producto() { id = 8, codigo = "118", nombre = "Papelografo", descripcion = "Pepelografo cuadriculado", marca = "Justus", idCategoria = 2, idAlerta = 4 },
                new Producto() { id = 9, codigo = "119", nombre = "Papelografo", descripcion = "Pepelografo en blanco", marca = "Dragon", idCategoria = 2, idAlerta = 4 }
                );

        }
    }
}
