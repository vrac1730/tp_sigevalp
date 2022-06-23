namespace SIGEVALP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DetallesEstadoAuthorizeRoles : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DetalleCotizacion", "estado", c => c.String());
            AddColumn("dbo.DetalleCompra", "estado", c => c.String());
            AddColumn("dbo.DetalleSolicitud", "estado", c => c.String());
            DropColumn("dbo.DetalleSolicitud", "observacion");
        }
        
        public override void Down()
        {
            AddColumn("dbo.DetalleSolicitud", "observacion", c => c.String());
            DropColumn("dbo.DetalleSolicitud", "estado");
            DropColumn("dbo.DetalleCompra", "estado");
            DropColumn("dbo.DetalleCotizacion", "estado");
        }
    }
}
