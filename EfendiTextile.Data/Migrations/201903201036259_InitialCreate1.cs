namespace EfendiTextile.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Customers", "OfferId", "dbo.Offers");
            DropForeignKey("dbo.Offers", "CustomerId", "dbo.Customers");
            DropIndex("dbo.Offers", new[] { "CustomerId" });
            DropIndex("dbo.Customers", new[] { "OfferId" });
            AlterColumn("dbo.Offers", "CustomerId", c => c.Guid(nullable: false));
            CreateIndex("dbo.Offers", "CustomerId");
            AddForeignKey("dbo.Offers", "CustomerId", "dbo.Customers", "Id", cascadeDelete: true);
            DropColumn("dbo.Customers", "OfferId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Customers", "OfferId", c => c.Guid(nullable: false));
            DropForeignKey("dbo.Offers", "CustomerId", "dbo.Customers");
            DropIndex("dbo.Offers", new[] { "CustomerId" });
            AlterColumn("dbo.Offers", "CustomerId", c => c.Guid());
            CreateIndex("dbo.Customers", "OfferId");
            CreateIndex("dbo.Offers", "CustomerId");
            AddForeignKey("dbo.Offers", "CustomerId", "dbo.Customers", "Id");
            AddForeignKey("dbo.Customers", "OfferId", "dbo.Offers", "Id", cascadeDelete: true);
        }
    }
}
