namespace SIGEVALP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Alertanula : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Producto", "idAlerta", "dbo.Alerta");
            DropIndex("dbo.Producto", new[] { "idAlerta" });
            AlterColumn("dbo.Producto", "idAlerta", c => c.Int(nullable: true));
            CreateIndex("dbo.Producto", "idAlerta");
            AddForeignKey("dbo.Producto", "idAlerta", "dbo.Alerta", "id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Producto", "idAlerta", "dbo.Alerta");
            DropIndex("dbo.Producto", new[] { "idAlerta" });
            AlterColumn("dbo.Producto", "idAlerta", c => c.Int(nullable: false));
            CreateIndex("dbo.Producto", "idAlerta");
            AddForeignKey("dbo.Producto", "idAlerta", "dbo.Alerta", "id", cascadeDelete: true);
        }
    }
}
