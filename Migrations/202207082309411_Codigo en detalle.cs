namespace SIGEVALP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Codigoendetalle : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DetalleCotizacion", "codigo", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.DetalleCotizacion", "codigo");
        }
    }
}
