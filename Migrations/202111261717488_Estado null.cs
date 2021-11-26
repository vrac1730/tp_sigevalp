namespace SIGEVALP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Estadonull : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ProductoAlmacen", "idEstado", "dbo.Estado");
            DropIndex("dbo.ProductoAlmacen", new[] { "idEstado" });
            AlterColumn("dbo.ProductoAlmacen", "idEstado", c => c.Int());
            CreateIndex("dbo.ProductoAlmacen", "idEstado");
            AddForeignKey("dbo.ProductoAlmacen", "idEstado", "dbo.Estado", "id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProductoAlmacen", "idEstado", "dbo.Estado");
            DropIndex("dbo.ProductoAlmacen", new[] { "idEstado" });
            AlterColumn("dbo.ProductoAlmacen", "idEstado", c => c.Int(nullable: false));
            CreateIndex("dbo.ProductoAlmacen", "idEstado");
            AddForeignKey("dbo.ProductoAlmacen", "idEstado", "dbo.Estado", "id", cascadeDelete: true);
        }
    }
}
