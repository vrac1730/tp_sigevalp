namespace SIGEVALP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Propiedadescotizacion : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Cotizacion", "parcial", c => c.Double(nullable: false));
            AddColumn("dbo.Cotizacion", "descuento", c => c.Double(nullable: false));
            AddColumn("dbo.Cotizacion", "fecha", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            DropColumn("dbo.Cotizacion", "fechaInicio");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Cotizacion", "fechaInicio", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            DropColumn("dbo.Cotizacion", "fecha");
            DropColumn("dbo.Cotizacion", "descuento");
            DropColumn("dbo.Cotizacion", "parcial");
        }
    }
}
