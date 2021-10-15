namespace SIGEVALP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModeloBase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Alerta",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        nombre = c.String(),
                        descripcion = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Almacen",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        nombre = c.String(),
                        direccion = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Categoria",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        nombre = c.String(),
                        descripcion = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Cotizacion",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        codigo = c.String(),
                        fechaFin = c.DateTime(nullable: false),
                        estado = c.String(),
                        iva = c.Double(nullable: false),
                        total = c.Double(nullable: false),
                        idUsuario = c.Int(nullable: false),
                        idProveedor = c.Int(nullable: false),
                        fechaInicio = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Usuario", t => t.idUsuario, cascadeDelete: true)
                .ForeignKey("dbo.Proveedor", t => t.idProveedor, cascadeDelete: true)
                .Index(t => t.idUsuario)
                .Index(t => t.idProveedor);
            
            CreateTable(
                "dbo.DetalleCotizacion",
                c => new
                    {
                        idProducto = c.Int(nullable: false),
                        idProveedor = c.Int(nullable: false),
                        costo = c.Double(nullable: false),
                        idAlerta = c.Int(nullable: false),
                        idCotizacion = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.idProducto, t.idProveedor })
                .ForeignKey("dbo.Alerta", t => t.idAlerta, cascadeDelete: true)
                .ForeignKey("dbo.Cotizacion", t => t.idCotizacion, cascadeDelete: true)
                .ForeignKey("dbo.Producto", t => t.idProducto, cascadeDelete: true)
                .ForeignKey("dbo.Proveedor", t => t.idProveedor, cascadeDelete: false)
                .Index(t => t.idProducto)
                .Index(t => t.idProveedor)
                .Index(t => t.idAlerta)
                .Index(t => t.idCotizacion);
            
            CreateTable(
                "dbo.Producto",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        codigo = c.String(),
                        nombre = c.String(nullable: false),
                        descripcion = c.String(nullable: false),
                        marca = c.String(nullable: false),
                        idCategoria = c.Int(nullable: false),
                        idAlerta = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Alerta", t => t.idAlerta, cascadeDelete: false)
                .ForeignKey("dbo.Categoria", t => t.idCategoria, cascadeDelete: true)
                .Index(t => t.idCategoria)
                .Index(t => t.idAlerta);
            
            CreateTable(
                "dbo.Proveedor",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        nombre = c.String(nullable: false),
                        direccion = c.String(nullable: false),
                        correo = c.String(nullable: false),
                        telefono = c.Long(nullable: false),
                        ruc = c.Long(nullable: false),
                        razon_social = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.OrdenCompra",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        codigo = c.String(),
                        fechaOrden = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        fechaPago = c.DateTime(nullable: false),
                        estado = c.String(),
                        montoTotal = c.Double(),
                        idUsuario = c.Int(nullable: false),
                        idProveedor = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Proveedor", t => t.idProveedor, cascadeDelete: true)
                .ForeignKey("dbo.Usuario", t => t.idUsuario, cascadeDelete: true)
                .Index(t => t.idUsuario)
                .Index(t => t.idProveedor);
            
            CreateTable(
                "dbo.DetalleCompra",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        cantidad = c.Int(nullable: false),
                        cantidadRecibida = c.Int(nullable: false),
                        total = c.Double(nullable: false),
                        idOrdenCompra = c.Int(nullable: false),
                        idProducto = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.OrdenCompra", t => t.idOrdenCompra, cascadeDelete: true)
                .ForeignKey("dbo.Producto", t => t.idProducto, cascadeDelete: true)
                .Index(t => t.idOrdenCompra)
                .Index(t => t.idProducto);
            
            CreateTable(
                "dbo.Usuario",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        username = c.String(),
                        correo = c.String(),
                        contraseña = c.String(),
                        idLocal = c.Int(nullable: false),
                        idPersona = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Local", t => t.idLocal, cascadeDelete: true)
                .ForeignKey("dbo.Persona", t => t.idPersona, cascadeDelete: true)
                .Index(t => t.idLocal)
                .Index(t => t.idPersona);
            
            CreateTable(
                "dbo.Local",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        nombre = c.String(nullable: false),
                        direccion = c.String(nullable: false, maxLength: 30),
                        telefono = c.Long(nullable: false),
                        ruc = c.Long(nullable: false),
                        razon_social = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Persona",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        dni = c.Long(nullable: false),
                        aPaterno = c.String(),
                        aMaterno = c.String(),
                        celular = c.Long(nullable: false),
                        nombre = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Solicitud",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        codigo = c.String(),
                        fecha = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        estado = c.String(),
                        idUsuario = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Usuario", t => t.idUsuario, cascadeDelete: true)
                .Index(t => t.idUsuario);
            
            CreateTable(
                "dbo.DetalleSolicitud",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        cantSolicitada = c.Int(nullable: false),
                        cantEntregada = c.Int(nullable: false),
                        observacion = c.String(),
                        idProducto = c.Int(nullable: false),
                        idSolicitud = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Producto", t => t.idProducto, cascadeDelete: true)
                .ForeignKey("dbo.Solicitud", t => t.idSolicitud, cascadeDelete: true)
                .Index(t => t.idProducto)
                .Index(t => t.idSolicitud);
            
            CreateTable(
                "dbo.Estado",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        nombre = c.String(),
                        descripcion = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.HistorialMovimientoes",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        cantidad = c.Int(nullable: false),
                        fecha = c.DateTime(nullable: false),
                        tipo = c.String(),
                        idProductoxAlmacen = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.ProductoAlmacen", t => t.idProductoxAlmacen, cascadeDelete: true)
                .Index(t => t.idProductoxAlmacen);
            
            CreateTable(
                "dbo.ProductoAlmacen",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        punto_pedido = c.Int(nullable: false),
                        cantidad = c.Int(nullable: false),
                        stock_min = c.Int(nullable: false),
                        stock_max = c.Int(nullable: false),
                        idProducto = c.Int(nullable: false),
                        idEstado = c.Int(nullable: false),
                        idAlmacen = c.Int(nullable: false),
                        idAlerta = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Alerta", t => t.idAlerta, cascadeDelete: true)
                .ForeignKey("dbo.Almacen", t => t.idAlmacen, cascadeDelete: true)
                .ForeignKey("dbo.Estado", t => t.idEstado, cascadeDelete: true)
                .ForeignKey("dbo.Producto", t => t.idProducto, cascadeDelete: true)
                .Index(t => t.idProducto)
                .Index(t => t.idEstado)
                .Index(t => t.idAlmacen)
                .Index(t => t.idAlerta);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProductoAlmacen", "idProducto", "dbo.Producto");
            DropForeignKey("dbo.HistorialMovimientoes", "idProductoxAlmacen", "dbo.ProductoAlmacen");
            DropForeignKey("dbo.ProductoAlmacen", "idEstado", "dbo.Estado");
            DropForeignKey("dbo.ProductoAlmacen", "idAlmacen", "dbo.Almacen");
            DropForeignKey("dbo.ProductoAlmacen", "idAlerta", "dbo.Alerta");
            DropForeignKey("dbo.Cotizacion", "idProveedor", "dbo.Proveedor");
            DropForeignKey("dbo.Solicitud", "idUsuario", "dbo.Usuario");
            DropForeignKey("dbo.DetalleSolicitud", "idSolicitud", "dbo.Solicitud");
            DropForeignKey("dbo.DetalleSolicitud", "idProducto", "dbo.Producto");
            DropForeignKey("dbo.Usuario", "idPersona", "dbo.Persona");
            DropForeignKey("dbo.OrdenCompra", "idUsuario", "dbo.Usuario");
            DropForeignKey("dbo.Usuario", "idLocal", "dbo.Local");
            DropForeignKey("dbo.Cotizacion", "idUsuario", "dbo.Usuario");
            DropForeignKey("dbo.OrdenCompra", "idProveedor", "dbo.Proveedor");
            DropForeignKey("dbo.DetalleCompra", "idProducto", "dbo.Producto");
            DropForeignKey("dbo.DetalleCompra", "idOrdenCompra", "dbo.OrdenCompra");
            DropForeignKey("dbo.DetalleCotizacion", "idProveedor", "dbo.Proveedor");
            DropForeignKey("dbo.DetalleCotizacion", "idProducto", "dbo.Producto");
            DropForeignKey("dbo.Producto", "idCategoria", "dbo.Categoria");
            DropForeignKey("dbo.Producto", "idAlerta", "dbo.Alerta");
            DropForeignKey("dbo.DetalleCotizacion", "idCotizacion", "dbo.Cotizacion");
            DropForeignKey("dbo.DetalleCotizacion", "idAlerta", "dbo.Alerta");
            DropIndex("dbo.ProductoAlmacen", new[] { "idAlerta" });
            DropIndex("dbo.ProductoAlmacen", new[] { "idAlmacen" });
            DropIndex("dbo.ProductoAlmacen", new[] { "idEstado" });
            DropIndex("dbo.ProductoAlmacen", new[] { "idProducto" });
            DropIndex("dbo.HistorialMovimientoes", new[] { "idProductoxAlmacen" });
            DropIndex("dbo.DetalleSolicitud", new[] { "idSolicitud" });
            DropIndex("dbo.DetalleSolicitud", new[] { "idProducto" });
            DropIndex("dbo.Solicitud", new[] { "idUsuario" });
            DropIndex("dbo.Usuario", new[] { "idPersona" });
            DropIndex("dbo.Usuario", new[] { "idLocal" });
            DropIndex("dbo.DetalleCompra", new[] { "idProducto" });
            DropIndex("dbo.DetalleCompra", new[] { "idOrdenCompra" });
            DropIndex("dbo.OrdenCompra", new[] { "idProveedor" });
            DropIndex("dbo.OrdenCompra", new[] { "idUsuario" });
            DropIndex("dbo.Producto", new[] { "idAlerta" });
            DropIndex("dbo.Producto", new[] { "idCategoria" });
            DropIndex("dbo.DetalleCotizacion", new[] { "idCotizacion" });
            DropIndex("dbo.DetalleCotizacion", new[] { "idAlerta" });
            DropIndex("dbo.DetalleCotizacion", new[] { "idProveedor" });
            DropIndex("dbo.DetalleCotizacion", new[] { "idProducto" });
            DropIndex("dbo.Cotizacion", new[] { "idProveedor" });
            DropIndex("dbo.Cotizacion", new[] { "idUsuario" });
            DropTable("dbo.ProductoAlmacen");
            DropTable("dbo.HistorialMovimientoes");
            DropTable("dbo.Estado");
            DropTable("dbo.DetalleSolicitud");
            DropTable("dbo.Solicitud");
            DropTable("dbo.Persona");
            DropTable("dbo.Local");
            DropTable("dbo.Usuario");
            DropTable("dbo.DetalleCompra");
            DropTable("dbo.OrdenCompra");
            DropTable("dbo.Proveedor");
            DropTable("dbo.Producto");
            DropTable("dbo.DetalleCotizacion");
            DropTable("dbo.Cotizacion");
            DropTable("dbo.Categoria");
            DropTable("dbo.Almacen");
            DropTable("dbo.Alerta");
        }
    }
}
