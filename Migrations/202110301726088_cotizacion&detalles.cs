namespace SIGEVALP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cotizaciondetalles : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.DetalleCotizacion", "idAlerta", "dbo.Alerta");
            DropIndex("dbo.DetalleCotizacion", new[] { "idAlerta" });
            AddColumn("dbo.Cotizacion", "neto", c => c.Double(nullable: false));
            AddColumn("dbo.DetalleCotizacion", "cantidad", c => c.Int(nullable: false));
            AddColumn("dbo.DetalleCotizacion", "descuento", c => c.Double(nullable: false));
            AddColumn("dbo.DetalleCotizacion", "total", c => c.Double(nullable: false));
            DropColumn("dbo.Cotizacion", "fechaFin");
            DropColumn("dbo.DetalleCotizacion", "idAlerta");
        }
        
        public override void Down()
        {
            AddColumn("dbo.DetalleCotizacion", "idAlerta", c => c.Int(nullable: false));
            AddColumn("dbo.Cotizacion", "fechaFin", c => c.DateTime(nullable: false));
            DropColumn("dbo.DetalleCotizacion", "total");
            DropColumn("dbo.DetalleCotizacion", "descuento");
            DropColumn("dbo.DetalleCotizacion", "cantidad");
            DropColumn("dbo.Cotizacion", "neto");
            CreateIndex("dbo.DetalleCotizacion", "idAlerta");
            AddForeignKey("dbo.DetalleCotizacion", "idAlerta", "dbo.Alerta", "id", cascadeDelete: true);
        }
    }
}
