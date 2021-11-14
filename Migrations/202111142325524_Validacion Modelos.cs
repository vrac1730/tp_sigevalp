namespace SIGEVALP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ValidacionModelos : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Categoria", "nombre", c => c.String(nullable: false));
            AlterColumn("dbo.Categoria", "descripcion", c => c.String(nullable: false, maxLength: 55));
            AlterColumn("dbo.Producto", "nombre", c => c.String(nullable: false, maxLength: 45));
            AlterColumn("dbo.Producto", "descripcion", c => c.String(nullable: false, maxLength: 55));
            AlterColumn("dbo.Producto", "marca", c => c.String(nullable: false, maxLength: 45));
            AlterColumn("dbo.Proveedor", "direccion", c => c.String(nullable: false, maxLength: 55));
            AlterColumn("dbo.Proveedor", "razon_social", c => c.String(nullable: false, maxLength: 55));
            AlterColumn("dbo.Local", "nombre", c => c.String(nullable: false, maxLength: 45));
            AlterColumn("dbo.Local", "direccion", c => c.String(nullable: false, maxLength: 55));
            AlterColumn("dbo.Local", "razon_social", c => c.String(nullable: false, maxLength: 45));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Local", "razon_social", c => c.String(nullable: false));
            AlterColumn("dbo.Local", "direccion", c => c.String(nullable: false, maxLength: 30));
            AlterColumn("dbo.Local", "nombre", c => c.String(nullable: false));
            AlterColumn("dbo.Proveedor", "razon_social", c => c.String(nullable: false));
            AlterColumn("dbo.Proveedor", "direccion", c => c.String(nullable: false));
            AlterColumn("dbo.Producto", "marca", c => c.String(nullable: false));
            AlterColumn("dbo.Producto", "descripcion", c => c.String(nullable: false));
            AlterColumn("dbo.Producto", "nombre", c => c.String(nullable: false));
            AlterColumn("dbo.Categoria", "descripcion", c => c.String());
            AlterColumn("dbo.Categoria", "nombre", c => c.String());
        }
    }
}
