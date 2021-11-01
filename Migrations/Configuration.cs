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
            context.Database.Delete();
            context.Database.CreateIfNotExists();

            context.Personas.AddOrUpdate(x => x.id,               
            new Persona() { id = 1, dni = 12345678, nombre = "Sebastián", aPaterno = "Rodríguez", aMaterno = "De La Torre Ugarte", celular = 123456789 },
            new Persona() { id = 2, dni = 70360207, nombre = "Victor", aPaterno = "Alarcón", aMaterno = "Campos", celular = 963109798 },
            new Persona() { id = 3, dni = 12345678, nombre = "Jairo", aPaterno = "Meléndez", aMaterno = "Alvarado", celular = 123456789 },
            new Persona() { id = 4, dni = 12345678, nombre = "Luis", aPaterno = "Sánchez", aMaterno = "Tupia", celular = 123456789 },
            new Persona() { id = 5, dni = 12345678, nombre = "Arnold", aPaterno = "Alegria", aMaterno = "Pacheco", celular = 123456789 }
            );
            context.Almacenes.AddOrUpdate(x => x.id,
            new Almacen() { id = 1, nombre = "Centro #1", direccion = "Av Peru" },
            new Almacen() { id = 2, nombre = "Centro #2", direccion = "Av Brasil" },
            new Almacen() { id = 3, nombre = "Centro #3", direccion = "Av Proceres" },
            new Almacen() { id = 4, nombre = "Centro #4", direccion = "Av Loreto" },
            new Almacen() { id = 5, nombre = "Centro #5", direccion = "Av Larco" }
            );
            context.Categorias.AddOrUpdate(x => x.id,
            new Categoria() { id = 1, nombre = "Pastas", descripcion = "Buena calidad" },
            new Categoria() { id = 2, nombre = "Condimentos", descripcion = "Buena calidad" },
            new Categoria() { id = 3, nombre = "Licor", descripcion = "Buena calidad" },
            new Categoria() { id = 4, nombre = "Aceites", descripcion = "Buena calidad" },
            new Categoria() { id = 5, nombre = "Embutidos", descripcion = "Buena calidad" },
            new Categoria() { id = 6, nombre = "Lacteos", descripcion = "Buena calidad" },
            new Categoria() { id = 7, nombre = "Verduras", descripcion = "Buena calidad" },
            new Categoria() { id = 8, nombre = "Abarrotes", descripcion = "Buena calidad" }
            );
            context.Estados.AddOrUpdate(x => x.id,
            new Estado() { id = 1, nombre = "Defectuoso", descripcion = "Buena calidad" },
            new Estado() { id = 2, nombre = "Malo", descripcion = "Buena calidad" },
            new Estado() { id = 3, nombre = "Regular", descripcion = "Mala calidad" },
            new Estado() { id = 4, nombre = "Bueno", descripcion = "Buena calidad" },
            new Estado() { id = 5, nombre = "Óptimo", descripcion = "Mala calidad" }
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
            context.Locales.AddOrUpdate(x => x.id,
            new Local() { id = 1, nombre = "Surco", direccion = "Av: los benavides 4950", telefono = 276153485, ruc = 20501234567, razon_social = "abc" },
            new Local() { id = 2, nombre = "Miraflores", direccion = "Av: los benavides 950", telefono = 276343485, ruc = 20501254567, razon_social = "def" },
            new Local() { id = 3, nombre = "Barranco", direccion = "Av: Grau 495", telefono = 275323485, ruc = 20501235567, razon_social = "ghi" }
            );                   
            context.Proveedores.AddOrUpdate(x => x.id,
            new Proveedor() { id = 1, nombre = "Mario Salas", correo = "mariosalas@gmail.com", direccion = "villa el salvador", razon_social = "abc", ruc = 42143557923, telefono = 981232131 },
            new Proveedor() { id = 2, nombre = "Jorge Luna", correo = "jorgeluna@gmail.com", direccion = "villa Maria del triunfo", razon_social = "def", ruc = 41212435351, telefono = 986463231 },
            new Proveedor() { id = 3, nombre = "Luis Gonzales", correo = "lgonzales@hotmail.com", direccion = "Surco", razon_social = "ghi", ruc = 94454143564, telefono = 991212123 },
            new Proveedor() { id = 4, nombre = "Jose Avalos", correo = "javalos@gmail.com", direccion = "Lima", razon_social = "jkl", ruc = 89948423248, telefono = 991232332 },
            new Proveedor() { id = 5, nombre = "Ricardo Huerta", correo = "ricardoh@hotmail.com", direccion = "Chorrillos", razon_social = "mno", ruc = 12993123351, telefono = 992312316 }
            );

            context.Usuarios.AddOrUpdate(x => x.id,
            new Usuario() { id = 1, username = "Sebastián", correo = "sebas@hotmail.com", contraseña = "123", idLocal = 1, idPersona = 1 },
            new Usuario() { id = 2, username = "Victor", correo = "virualca@hotmail.com", contraseña = "123", idLocal = 1, idPersona = 2 },
            new Usuario() { id = 3, username = "Jairo", correo = "jairo@hotmail.com", contraseña = "123", idLocal = 1, idPersona = 3 },
            new Usuario() { id = 4, username = "Luis", correo = "luis@hotmail.com", contraseña = "123", idLocal = 1, idPersona = 4 },
            new Usuario() { id = 5, username = "Arnold", correo = "arnold@hotmail.com", contraseña = "123", idLocal = 1, idPersona = 5 }
            );
            context.Productos.AddOrUpdate(x => x.id,
            new Producto() { id = 1, codigo = "PANI1", nombre = "Spaghetti Bolsa 1Kg", descripcion = "Spaghetti de buena calidad", marca = "Nicollini", idCategoria = 1, idAlerta = 5 },
            new Producto() { id = 2, codigo = "PADO2", nombre = "Spaghetti Bolsa 1Kg", descripcion = "Spaghetti de buena calidad", marca = "Don Vitorio", idCategoria = 1, idAlerta = 5 },
            new Producto() { id = 3, codigo = "ACEL3", nombre = "Aceite de Oliva Garrafa 5L", descripcion = "Aceite de Oliva de buena calidad", marca = "El Trujal de Guillermo", idCategoria = 4, idAlerta = 4 },
            new Producto() { id = 4, codigo = "ACOL4", nombre = "Aceite de Oliva extravirgen Garrafa 5L", descripcion = "Aceite de Oliva de buena calidad", marca = "Olivos del Sur", idCategoria = 4, idAlerta = 4 },
            new Producto() { id = 5, codigo = "ACCO5", nombre = "Aceite Bote 20L", descripcion = "Aceite de buena calidad", marca = "Cocinero", idCategoria = 4, idAlerta = 7 },
            new Producto() { id = 6, codigo = "COMA6", nombre = "Sal de Mesa Bolsa 1kg", descripcion = "Sal de Mesa de buena calidad", marca = "Marina", idCategoria = 2, idAlerta = 7 },
            new Producto() { id = 7, codigo = "COMA7", nombre = "Sal de Cocina Bolsa 1Kg", descripcion = "Sal de Cocina de buena calidad", marca = "Marina", idCategoria = 2, idAlerta = 4 },
            new Producto() { id = 8, codigo = "COLO8", nombre = "Sal de Cocina Gruesa Bolsa 1Kg", descripcion = "Sal de Cocina cuadriculado", marca = "Lobos", idCategoria = 2, idAlerta = 4 },
            new Producto() { id = 9, codigo = "LIHE9", nombre = "Cognac Botella 700ml", descripcion = "Cognac en blanco", marca = "Hennessy", idCategoria = 3, idAlerta = 4 },
            new Producto() { id = 10, codigo = "LIGA10", nombre = "Vino Tinto Botella 1L", descripcion = "Vino Tinto en blanco", marca = "Gato", idCategoria = 3, idAlerta = 4 },
            new Producto() { id = 11, codigo = "COBA11", nombre = "Pimienta Negra Frasco 198.4g", descripcion = "Pimienta Negra en blanco", marca = "Badia", idCategoria = 2, idAlerta = 4 },
            new Producto() { id = 12, codigo = "COBA12", nombre = "Pimienta Blanca Frasco 198.4g", descripcion = "Pimienta Blanca en blanco", marca = "Badia", idCategoria = 2, idAlerta = 4 },
            new Producto() { id = 13, codigo = "COBA13", nombre = "Pimienta Roja Frasco 198.4g ", descripcion = "Pimienta Roja en blanco", marca = "Badia", idCategoria = 2, idAlerta = 4 },
            new Producto() { id = 14, codigo = "COKA14", nombre = "Oregano Molido Frasco 35g ", descripcion = "Oregano Molido en blanco", marca = "Kariño", idCategoria = 2, idAlerta = 4 },
            new Producto() { id = 15, codigo = "COKA15", nombre = "Comino Molido Frasco 40g", descripcion = "Comino Molido  en blanco", marca = "Kariño", idCategoria = 2, idAlerta = 4 },
            new Producto() { id = 16, codigo = "ABLA16", nombre = "Huevos Paq. 30 Unid.", descripcion = "Huevos en blanco", marca = "La Calera", idCategoria = 8, idAlerta = 4 },
            new Producto() { id = 17, codigo = "CO4E17", nombre = "Tomillo Bolsa 5g ", descripcion = "Tomillo en blanco", marca = "4 Estaciones", idCategoria = 2, idAlerta = 4 }
            );
            
            context.Solicitudes.AddOrUpdate(x => x.id,
            new Solicitud() { id = 1, codigo = "0001", fecha = new DateTime(2021, 06, 03, 12, 19, 20), estado = "Pendiente", idUsuario = 1 },
            new Solicitud() { id = 2, codigo = "0002", fecha = new DateTime(2021, 06, 03, 12, 19, 20), estado = "Pendiente", idUsuario = 2 },
            new Solicitud() { id = 3, codigo = "0003", fecha = new DateTime(2021, 06, 03, 12, 19, 20), estado = "Pendiente", idUsuario = 3 },
            new Solicitud() { id = 4, codigo = "0004", fecha = new DateTime(2021, 06, 03, 12, 19, 20), estado = "Pendiente", idUsuario = 4 },
            new Solicitud() { id = 5, codigo = "0005", fecha = new DateTime(2021, 06, 03, 12, 19, 20), estado = "Pendiente", idUsuario = 5 }
            );
            context.OrdenesCompras.AddOrUpdate(x => x.id,
            new OrdenCompra() { id = 1, codigo = "0001", fechaOrden = new DateTime(2021, 06, 03, 12, 19, 20), fechaPago = new DateTime(2021, 06, 03, 15, 19, 20), estado = "Pendiente", montoTotal = 1500, idUsuario = 1, idProveedor = 3 },
            new OrdenCompra() { id = 2, codigo = "0002", fechaOrden = new DateTime(2021, 06, 03, 12, 19, 20), fechaPago = new DateTime(2021, 06, 03, 15, 19, 20), estado = "Pendiente", montoTotal = 500, idUsuario = 2, idProveedor = 2 },
            new OrdenCompra() { id = 3, codigo = "0003", fechaOrden = new DateTime(2021, 06, 03, 12, 19, 20), fechaPago = new DateTime(2021, 06, 03, 15, 19, 20), estado = "Pendiente", montoTotal = 1200, idUsuario = 3, idProveedor = 1 },
            new OrdenCompra() { id = 4, codigo = "0004", fechaOrden = new DateTime(2021, 06, 03, 12, 19, 20), fechaPago = new DateTime(2021, 06, 03, 15, 19, 20), estado = "Pendiente", montoTotal = 1000, idUsuario = 4, idProveedor = 4 },
            new OrdenCompra() { id = 5, codigo = "0005", fechaOrden = new DateTime(2021, 06, 03, 12, 19, 20), fechaPago = new DateTime(2021, 06, 03, 15, 19, 20), estado = "Pendiente", montoTotal = 000, idUsuario = 5, idProveedor = 5 }
            );
            context.Cotizaciones.AddOrUpdate(x => x.id,
            new Cotizacion() { id = 1, codigo = "0001", fecha = new DateTime(2021, 06, 03, 12, 19, 20), estado = "Aprobado", parcial = 284.5, descuento = 14.23, neto = 270.27, iva = 48.65, total = 318.92, idUsuario = 2, idProveedor = 3 },
            new Cotizacion() { id = 2, codigo = "0002", fecha = new DateTime(2021, 06, 03, 12, 20, 20), estado = "Pendiente", parcial = 277.5, descuento = 13.88, neto = 263.62, iva = 0.00, total = 263.62, idUsuario = 2, idProveedor = 1 },
            new Cotizacion() { id = 3, codigo = "0003", fecha = new DateTime(2021, 06, 03, 12, 21, 20), estado = "Aprobado", parcial = 279.5, descuento = 0.00, neto = 279.5, iva = 50.31, total = 329.81, idUsuario = 2, idProveedor = 2 }
            );

            context.DetallesSolicitudes.AddOrUpdate(x => new { x.idSolicitud, x.idProducto },
            new DetalleSolicitud() { idSolicitud = 1, idProducto = 1, cantSolicitada = 100, cantEntregada = 0, observacion = "" },
            new DetalleSolicitud() { idSolicitud = 1, idProducto = 2, cantSolicitada = 10, cantEntregada = 0, observacion = "" }
            );
            context.DetallesCompras.AddOrUpdate(x => x.id,
            new DetalleCompra() { id = 1, cantidad = 20, total = 410, cantidadRecibida = 0, idProducto = 5, idOrdenCompra = 1 },
            new DetalleCompra() { id = 2, cantidad = 20, total = 470, cantidadRecibida = 0, idProducto = 6, idOrdenCompra = 1 }
            );
            context.DetallesCotizaciones.AddOrUpdate(x => new { x.idProveedor, x.idProducto },
            new DetalleCotizacion() { idProducto = 1, idProveedor = 1, costo = 22.7, cantidad = 5, descuento = 5.68, total = 113.50, idCotizacion = 2 },
            new DetalleCotizacion() { idProducto = 1, idProveedor = 2, costo = 21.5, cantidad = 10, descuento = 0.00, total = 215.00, idCotizacion = 3 },
            new DetalleCotizacion() { idProducto = 1, idProveedor = 3, costo = 20.5, cantidad = 8, descuento = 8.20, total = 164.00, idCotizacion = 2 },
            new DetalleCotizacion() { idProducto = 2, idProveedor = 2, costo = 21.5, cantidad = 3, descuento = 0.00, total = 64.50, idCotizacion = 3 },
            new DetalleCotizacion() { idProducto = 5, idProveedor = 3, costo = 20.5, cantidad = 7, descuento = 7.18, total = 143.50, idCotizacion = 1 },
            new DetalleCotizacion() { idProducto = 6, idProveedor = 3, costo = 23.5, cantidad = 6, descuento = 7.05, total = 141.00, idCotizacion = 1 }
            );            
              
            context.ProductosxAlmacen.AddOrUpdate(x => x.id,
            new ProductoxAlmacen() { id = 1, cantidad = 47, idAlmacen = 1, stock_min = 10, stock_max = 60, idProducto = 1, idEstado = 1, idAlerta = 3 },
            new ProductoxAlmacen() { id = 2, cantidad = 45, idAlmacen = 1, stock_min = 10, stock_max = 50, idProducto = 2, idEstado = 2, idAlerta = 3 },
            new ProductoxAlmacen() { id = 3, cantidad = 10, idAlmacen = 1, stock_min = 10, stock_max = 50, idProducto = 3, idEstado = 2, idAlerta = 4 },
            new ProductoxAlmacen() { id = 4, cantidad = 7, idAlmacen = 1, stock_min = 5, stock_max = 40, idProducto = 4, idEstado = 3, idAlerta = 2 },
            new ProductoxAlmacen() { id = 5, cantidad = 10, idAlmacen = 1, stock_min = 10, stock_max = 60, idProducto = 5, idEstado = 3, idAlerta = 4 },
            new ProductoxAlmacen() { id = 6, cantidad = 7, idAlmacen = 1, stock_min = 10, stock_max = 50, idProducto = 6, idEstado = 3, idAlerta = 1 },
            new ProductoxAlmacen() { id = 7, cantidad = 9, idAlmacen = 1, stock_min = 10, stock_max = 50, idProducto = 7, idEstado = 3, idAlerta = 4 },
            new ProductoxAlmacen() { id = 8, cantidad = 10, idAlmacen = 1, stock_min = 10, stock_max = 50, idProducto = 8, idEstado = 3, idAlerta = 4 },
            new ProductoxAlmacen() { id = 9, cantidad = 49, idAlmacen = 1, stock_min = 10, stock_max = 50, idProducto = 9, idEstado = 3, idAlerta = 3 }
            );
        }
    }
}
