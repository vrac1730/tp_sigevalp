namespace SIGEVALP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fecha : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DetalleCompra", "fecha", c => c.DateTime(precision: 7, storeType: "datetime2"));
            AddColumn("dbo.DetalleSolicitud", "fecha", c => c.DateTime(precision: 7, storeType: "datetime2"));
        }
        
        public override void Down()
        {
            DropColumn("dbo.DetalleSolicitud", "fecha");
            DropColumn("dbo.DetalleCompra", "fecha");
        }
    }
}
