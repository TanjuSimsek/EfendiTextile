namespace EfendiTextile.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNew : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Categories", "Photo", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Categories", "Photo");
        }
    }
}
