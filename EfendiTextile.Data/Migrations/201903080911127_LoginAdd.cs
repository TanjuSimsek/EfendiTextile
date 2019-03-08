namespace EfendiTextile.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LoginAdd : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.OrderProducts", newName: "ProductIOfOrder");
            DropForeignKey("dbo.Products", "CategoryId", "dbo.Categories");
            DropIndex("dbo.Products", new[] { "CategoryId" });
            RenameColumn(table: "dbo.ProductIOfOrder", name: "Order_Id", newName: "OrderRefId");
            RenameColumn(table: "dbo.ProductIOfOrder", name: "Product_Id", newName: "ProductRefId");
            RenameIndex(table: "dbo.ProductIOfOrder", name: "IX_Product_Id", newName: "IX_ProductRefId");
            RenameIndex(table: "dbo.ProductIOfOrder", name: "IX_Order_Id", newName: "IX_OrderRefId");
            DropPrimaryKey("dbo.ProductIOfOrder");
            AlterColumn("dbo.Products", "ProductName", c => c.String(nullable: false, maxLength: 200));
            AlterColumn("dbo.Products", "CategoryId", c => c.Guid(nullable: false));
            AlterColumn("dbo.Regions", "City", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Regions", "Country", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Regions", "District", c => c.String(nullable: false, maxLength: 100));
            AddPrimaryKey("dbo.ProductIOfOrder", new[] { "ProductRefId", "OrderRefId" });
            CreateIndex("dbo.Products", "CategoryId");
            AddForeignKey("dbo.Products", "CategoryId", "dbo.Categories", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "CategoryId", "dbo.Categories");
            DropIndex("dbo.Products", new[] { "CategoryId" });
            DropPrimaryKey("dbo.ProductIOfOrder");
            AlterColumn("dbo.Regions", "District", c => c.String());
            AlterColumn("dbo.Regions", "Country", c => c.String());
            AlterColumn("dbo.Regions", "City", c => c.String(nullable: false));
            AlterColumn("dbo.Products", "CategoryId", c => c.Guid());
            AlterColumn("dbo.Products", "ProductName", c => c.String());
            AddPrimaryKey("dbo.ProductIOfOrder", new[] { "Order_Id", "Product_Id" });
            RenameIndex(table: "dbo.ProductIOfOrder", name: "IX_OrderRefId", newName: "IX_Order_Id");
            RenameIndex(table: "dbo.ProductIOfOrder", name: "IX_ProductRefId", newName: "IX_Product_Id");
            RenameColumn(table: "dbo.ProductIOfOrder", name: "ProductRefId", newName: "Product_Id");
            RenameColumn(table: "dbo.ProductIOfOrder", name: "OrderRefId", newName: "Order_Id");
            CreateIndex("dbo.Products", "CategoryId");
            AddForeignKey("dbo.Products", "CategoryId", "dbo.Categories", "Id");
            RenameTable(name: "dbo.ProductIOfOrder", newName: "OrderProducts");
        }
    }
}
